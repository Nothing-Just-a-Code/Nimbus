Imports System.Threading
Imports FluentFTP
Imports Nimbus_FTP_Client.NimbusX
Public Class FileSearcher
    Private ReadOnly ftpclient As AsyncFtpClient
    Private IsSearching As Boolean = False
    Private CanToken As CancellationTokenSource

    Sub New(ByVal client As AsyncFtpClient)
        InitializeComponent()
        ftpclient = client
    End Sub
    Private Sub FileSearcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not ftpclient.IsConnected Then
            MBox("Connection Broken", "The FTP client is not connected to server to perform this action.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If IsEmpty(Dirtxt.Text) Then
            MBox("Directory required", "Please mention the directory where you want to search for a file.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dirtxt.Focus()
            Exit Sub
        End If

        If IsSearching = False Then ' Start Search
            'add slash at start if doesnt exist
            If Not Dirtxt.Text.StartsWith("/") Then Dirtxt.Text = Dirtxt.Text.Insert(0, "/")
            If Await ftpclient.DirectoryExists(Dirtxt.Text) Then
                CanToken = New CancellationTokenSource()
                Button1.Text = "Cancel"

                IsSearching = True
                PictureBox1.Visible = True
                filekeyword.Enabled = False
                pbar.Visible = True
                Dirtxt.Enabled = False
                fileslist.Items.Clear()
                Dim enu = ftpclient.GetListingEnumerable(path:=Dirtxt.Text, options:=FtpListOption.Recursive, token:=CanToken.Token).GetAsyncEnumerator(CanToken.Token)
                Try
                    While Await enu.MoveNextAsync()
                        If Not ftpclient.IsConnected Then MsgBox("Disconnected")
                        Dim item As FtpListItem = enu.Current
                        If item.Name.Contains(filekeyword.Text, StringComparison.OrdinalIgnoreCase) Then
                            Dim fItem As New ListViewItem() With {
                                .Text = item.Name, .ImageIndex = 0}
                            fItem.SubItems.Add(GetFtpDirectory(item.FullName))
                            fItem.SubItems.Add(FormatBytes(item.Size))
                            fItem.SubItems.Add(item.Chmod.ToString())
                            fItem.Tag = item
                            fileslist.Items.Add(fItem)
                        End If
                    End While
                    Button1.Text = "Start"
                    IsSearching = False
                    PictureBox1.Visible = False
                    filekeyword.Enabled = True
                    MBox("Completed", "File searching operation has been completed.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch canEx As OperationCanceledException
                    Button1.Text = "Start"
                    IsSearching = False
                    PictureBox1.Visible = False
                    filekeyword.Enabled = True
                    Dirtxt.Enabled = True
                    pbar.Visible = False
                    MBox("Cancalled", "File searching operation has been cancalled.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    If ex.InnerException IsNot Nothing Then NLogger.Log(ex.InnerException) Else NLogger.Log(ex)
                    Button1.Text = "Start"
                    IsSearching = False
                    pbar.Visible = False
                    Dirtxt.Enabled = True
                    PictureBox1.Visible = False
                    filekeyword.Enabled = True
                    MBox("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    CanToken.Dispose()
                    enu.DisposeAsync()
                End Try
            Else
                MBox("Error", $"The directory '{Dirtxt.Text}' doesn't exist.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            If Not CanToken.IsCancellationRequested Then
                Button1.Text = "Please wait"
                Await CanToken.CancelAsync()
            End If
        End If
    End Sub

    Private Sub FileSearcher_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub filekeyword_TextChanged(sender As Object, e As EventArgs) Handles filekeyword.TextChanged
        Button1.Enabled = Not IsEmpty(filekeyword.Text)
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening
        If fileslist.SelectedItems.Count = 0 Or IsSearching = True Then e.Cancel = True
    End Sub

    Private Async Sub EditFieToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditFieToolStripMenuItem.Click
        Try
            Dim ftpitem As FtpListItem = CType(fileslist.SelectedItems(0).Tag, FtpListItem)
            Dim fileitem As New FTPFile() With {
                .CreatedOn = ftpitem.Created,
                .Extension = IO.Path.GetExtension(ftpitem.Name),
                .Filename = ftpitem.Name,
                .FileSize = ftpitem.Size,
                .FullPath = ftpitem.FullName,
                .LastModifiedOn = ftpitem.Modified,
                .Permission = ftpitem.Chmod}
            Dim randomname As String = IO.Path.GetTempFileName()
            Await ftpclient.DownloadFile(randomname, fileitem.FullPath, FtpLocalExists.Overwrite, FtpVerify.None)
            Dim editform As New NEditor(randomname, fileitem)
            editform.ShowDialog(Me)
        Catch ex As Exception
            If ex.InnerException IsNot Nothing Then NLogger.Log(ex.InnerException) Else NLogger.Log(ex)
            MBox("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CopyNameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyNameToolStripMenuItem.Click
        Clipboard.SetText(fileslist.SelectedItems(0).Text)
    End Sub

    Private Sub CopyPathToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyPathToolStripMenuItem.Click
        Dim ftpitem As FtpListItem = CType(fileslist.SelectedItems(0).Tag, FtpListItem)
        Clipboard.SetText($"ftp://{ftpclient.Credentials.UserName}@{ftpclient.Host}/{ftpitem.FullName}")
    End Sub

    Private Async Sub DeleteFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteFileToolStripMenuItem.Click
        Try
            If MBox("Deleting File", "Do you really want to delete this file? This action cannot be undone.", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) = DialogResult.Yes Then
                Await ftpclient.DeleteFile(CType(fileslist.SelectedItems(0).Tag, FtpListItem).FullName)
                fileslist.SelectedItems(0).Remove()
            End If
        Catch ex As Exception
            If ex.InnerException IsNot Nothing Then NLogger.Log(ex.InnerException) Else NLogger.Log(ex)
            MBox("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class