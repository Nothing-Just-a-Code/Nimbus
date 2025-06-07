Imports FluentFTP
Imports System.ComponentModel
Imports System.IO
Imports Microsoft.WindowsAPICodePack.Shell
Imports System.Threading
Imports Nimbus_FTP_Client.NimbusX
Imports System.Collections.Concurrent
Imports System.Windows.Documents
Imports Ookii.Dialogs.WinForms
Imports FluentFTP.Helpers
Imports System.Net.WebRequestMethods

Public Class MainForm
    Public WithEvents NimbFTP As AsyncFtpClient
    Public UploadCancelToken As CancellationTokenSource
    Public IsUploading As Boolean = False
    Private pauseUpload As Boolean = False
    Private UploadPauseEvent As New ManualResetEventSlim(True) ' Initially not paused
    Private WithEvents DownloadProgDld As New ProgressDialog()
    Public TaskInProgress As Boolean = False
    Public WithEvents AutoConnector As Threading.Timer
    Private AutoConnecting As Boolean = False
    Private Async Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        If NimbFTP IsNot Nothing Then servername.Text = $"Connected to {NimbFTP.Host}"
        Await LoadFtpFolders("/")
        TaskInProgress = False
        AutoConnector = New Threading.Timer(New TimerCallback(AddressOf AutoConnectClient), Nothing, 0, 1000)
    End Sub

    Sub New(ByVal _ftp As AsyncFtpClient)
        InitializeComponent()
        Me.NimbFTP = _ftp
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        SplitContainer1.Panel2Collapsed = Not SplitContainer1.Panel2Collapsed
    End Sub

#Region "FTP Directory and Files"
    Private Async Function LoadFtpFolders(path As String, Optional parentNode As TreeNode = Nothing) As Task
        Try
            Dim items = Await NimbFTP.GetListing(path)
            If parentNode Is Nothing Then
                For Each item In items
                    If item.Type = FtpObjectType.Directory Then
                        Dim Dir As New FTPDirectory() With {
                            .CreatedOn = item.Created,
                            .FolderName = item.Name,
                            .FullPath = item.FullName,
                            .LastModifiedOn = item.Modified,
                            .Permission = item.Chmod}
                        Dim node = Dirs.Nodes.Add(key:=item.Name, text:=item.Name)
                        node.Tag = Dir
                        If Await NimbFTP.IsRoot() Then
                            node.ImageIndex = 1
                            node.SelectedImageIndex = 1
                        Else
                            node.ImageIndex = 2
                            node.SelectedImageIndex = 2
                        End If
                    End If
                Next
            Else
                For Each item In items
                    If item.Type = FtpObjectType.Directory AndAlso Not NimbusX.ChildNodeExistsLinq(parentNode, item.Name) Then
                        Dim Dir As New FTPDirectory() With {
                            .CreatedOn = item.Created,
                            .FolderName = item.Name,
                            .FullPath = item.FullName,
                            .LastModifiedOn = item.Modified,
                            .Permission = item.Chmod}
                        Dim node = parentNode.Nodes.Add(key:=item.Name, text:=item.Name, imageIndex:=2)
                        node.SelectedImageIndex = 2
                        node.Tag = Dir
                    End If
                Next
                If Not parentNode.IsExpanded Then parentNode.Expand()
            End If
        Catch ex As Exception
            MBox("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Public Async Function GetFiles(ByVal path As String) As Task
        If Not ftpfiles.Items.Count = 0 Then ftpfiles.Items.Clear()
        If NimbusX.NConfig.FilesLoadMethod = "advanced" Then ' load files one by one without waiting for all files to load.
            Dim files As IAsyncEnumerator(Of FtpListItem) = NimbFTP.GetListingEnumerable(path).GetAsyncEnumerator()
            Try
                While Await files.MoveNextAsync()
                    Dim item As FtpListItem = files.Current
                    If item.Type = FtpObjectType.File Then
                        Dim fFile As New FTPFile() With {.Extension = System.IO.Path.GetExtension(item.Name),
                            .CreatedOn = item.Created,
                            .Filename = item.Name,
                            .FileSize = item.Size,
                            .FullPath = item.FullName,
                            .LastModifiedOn = item.Modified,
                            .Permission = item.Chmod}
                        Dim fileitem As New ListViewItem() With {.Text = item.Name}
                        fileitem.SubItems.Add(FormatBytes(item.Size))
                        fileitem.SubItems.Add(item.Created.ToString())
                        fileitem.SubItems.Add(item.Modified.ToString())
                        fileitem.SubItems.Add(item.Chmod.ToString())
                        fileitem.ImageIndex = GetImageForExtension(fFile.Extension)
                        fileitem.Tag = fFile
                        ftpfiles.Items.Add(fileitem)
                    End If
                End While
            Catch ex As Exception
                NLogger.Log(ex)
                MBox("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                files.DisposeAsync()
            End Try
        ElseIf NConfig.FilesLoadMethod = "basic" Then
            Dim files = Await NimbFTP.GetListing(path)
            If files.Count = 0 Then
                MBox("No Files Found", "This directory have no file(s).", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            Else
                For Each item As FtpListItem In files
                    If item.Type = FtpObjectType.File Then
                        Dim fFile As New FTPFile() With {.Extension = System.IO.Path.GetExtension(item.Name),
                            .CreatedOn = item.Created,
                            .Filename = item.Name,
                            .FileSize = item.Size,
                            .FullPath = item.FullName,
                            .LastModifiedOn = item.Modified,
                            .Permission = item.Chmod}
                        Dim fileitem As New ListViewItem() With {.Text = item.Name}
                        fileitem.SubItems.Add(FormatBytes(item.Size))
                        fileitem.SubItems.Add(item.Created.ToString())
                        fileitem.SubItems.Add(item.Modified.ToString())
                        fileitem.SubItems.Add(item.Chmod.ToString())
                        fileitem.ImageIndex = GetImageForExtension(fFile.Extension)
                        fileitem.Tag = fFile
                        ftpfiles.Items.Add(fileitem)
                    End If
                Next
            End If
        Else
            MBox("Error", "Config file is corrupted.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Environment.Exit(0)
        End If
    End Function

    Private Function GetImageForExtension(ByVal ext As String) As Integer
        If ImageList2.Images.ContainsKey(ext) Then
            Return ImageList2.Images.IndexOfKey(ext)
        Else
            ImageList2.Images.Add(key:=ext, image:=IconHelper.GetFileIconByExtension(ext))
            Return ImageList2.Images.IndexOfKey(ext)
        End If
    End Function
#End Region

    Private Async Sub Dirs_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles Dirs.NodeMouseDoubleClick
        If TaskInProgress Then
            MBox("Another Task in Progress", "Another task is in progress. Let it finish before starting the next task.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        TaskInProgress = True
        Dim node As TreeNode = e.Node
        Dirs.Enabled = False
        Await LoadFtpFolders(CType(node.Tag, FTPDirectory).FullPath, node)
        If Not ftpfiles.Items.Count = 0 Then ftpfiles.Items.Clear()
        Await GetFiles(CType(node.Tag, FTPDirectory).FullPath)
        Dirs.Enabled = True
        TaskInProgress = False
    End Sub

    Private Async Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If TaskInProgress Then
            MBox("Another Task in Progress", "Another task is in progress. Let it finish before starting the next task.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        TaskInProgress = True
        ToolStripButton3.Enabled = False
        Dirs.Nodes.Clear()
        Dirs.Enabled = False
        Await LoadFtpFolders("/")
        ToolStripButton3.Enabled = True
        Dirs.Enabled = True
        TaskInProgress = False
    End Sub

    Private Async Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If TaskInProgress Then
            MBox("Another Task in Progress", "Another task is in progress. Let it finish before starting the next task.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If Dirs.SelectedNode IsNot Nothing Then
            TaskInProgress = True
            ToolStripButton2.Enabled = False
            Await GetFiles(CType(Dirs.SelectedNode.Tag, FTPDirectory).FullPath)
            ToolStripButton2.Enabled = True
            TaskInProgress = False
        End If
    End Sub

    Private Sub Dirs_CM_Opening(sender As Object, e As CancelEventArgs) Handles Dirs_CM.Opening
        If Dirs.SelectedNode Is Nothing Then e.Cancel = True ' Cancel the CM if there is no node selected.
    End Sub

    Private Sub getfiles_TS_Click(sender As Object, e As EventArgs) Handles getfiles_TS.Click
        ToolStripButton2.PerformClick()
    End Sub

    Private Sub copyname_TS_Click(sender As Object, e As EventArgs) Handles copyname_TS.Click
        Dim node = Dirs.SelectedNode
        If node IsNot Nothing AndAlso Not IsEmpty(node.Text) Then Clipboard.SetText(node.Text)
    End Sub

    Private Sub rename_TS_Click(sender As Object, e As EventArgs) Handles rename_TS.Click
        If TaskInProgress Then
            MBox("Another Task in Progress", "Another task is in progress. Let it finish before starting the next task.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim node = Dirs.SelectedNode
        Dirs.LabelEdit = True
        node.BeginEdit()
    End Sub

    Private Async Sub Dirs_AfterLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles Dirs.AfterLabelEdit
        Try
            If e.CancelEdit OrElse IsEmpty(e.Label) Then Return
            Dim ftpdir As FTPDirectory = CType(e.Node.Tag, FTPDirectory)
            Dim originalpath As String = ftpdir.FullPath
            Dim lastSlash As Integer = originalpath.LastIndexOf("/"c)
            Dim updatedPath As String = originalpath.Substring(0, lastSlash + 1) & e.Label
            Dim result = Await NimbFTP.MoveDirectory(originalpath, updatedPath)
            If result = True Then
                ftpdir.FullPath = updatedPath
                ftpdir.FolderName = e.Label
            Else
                e.Node.Text = ftpdir.FolderName
                MBox("Error", "There is an unknown error while renaming the directory. Please try again.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            NLogger.Log(ex)
            MBox(title:="Error", text:=ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error, Me)
        Finally
            'Disable the label edit
            Dirs.LabelEdit = False
        End Try
    End Sub

    Private Sub changeperm_TS_Click(sender As Object, e As EventArgs) Handles changeperm_TS.Click
        If TaskInProgress Then
            MBox("Another Task in Progress", "Another task is in progress. Let it finish before starting the next task.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim node = Dirs.SelectedNode
        If node IsNot Nothing Then
            Dim perm As New ChangePermission(CType(node.Tag, FTPDirectory))
            perm.ShowDialog(Me)
        End If
    End Sub

#Region "SAVE CHMOD"
    Public Async Sub SaveCHMODPermsCall(ByVal perms As Integer, isdirectory As Boolean)
        Dim node = Dirs.SelectedNode
        If isdirectory Then
            If node IsNot Nothing AndAlso Not CType(node.Tag, FTPDirectory).Permission = perms Then
                Await SaveCHMOD(perms, isdirectory)
            End If
        Else
            If node IsNot Nothing AndAlso Not CType(node.Tag, FTPFile).Permission = perms Then
                Await SaveCHMOD(perms, isdirectory)
            End If
        End If
    End Sub

    Private Async Function SaveCHMOD(ByVal perms As Integer, Optional ByVal isdirectory As Boolean = False) As Task
        TaskInProgress = True
        Try
            If isdirectory Then
                Await NimbFTP.Chmod(CType(Dirs.SelectedNode.Tag, FTPDirectory).FullPath, perms)
                CType(Dirs.SelectedNode.Tag, FTPDirectory).Permission = perms
            Else
                Await NimbFTP.Chmod(CType(Dirs.SelectedNode.Tag, FTPFile).FullPath, perms)
                CType(Dirs.SelectedNode.Tag, FTPFile).Permission = perms
            End If
        Catch ex As Exception
            NLogger.Log(ex)
            MBox("Cannot Save Permission", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            TaskInProgress = False
        End Try
    End Function
#End Region

    Private Async Sub delete_TS_Click(sender As Object, e As EventArgs) Handles delete_TS.Click
        If TaskInProgress Then
            MBox("Another Task in Progress", "Another task is in progress. Let it finish before starting the next task.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim node = Dirs.SelectedNode
        If node IsNot Nothing Then
            If MBox("WARNING!!", $"This action will delete the directory, it's files and all sub-directories (If have any).{Environment.NewLine}This action cannot be undone. Do you want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Try
                    Dirs.Enabled = False
                    ftpfiles.Enabled = False
                    TaskInProgress = True
                    stslbl.Image = My.Resources.NimbusResources._91
                    stslbl.Text = "Deleting in process.."
                    sts_pb.Visible = True
                    sts_pb.Style = System.Windows.Forms.ProgressBarStyle.Marquee
                    Await NimbFTP.DeleteDirectory(CType(node.Tag, FTPDirectory).FullPath, options:=FtpListOption.Recursive)
                    Dirs.Enabled = True
                    ftpfiles.Enabled = True
                    TaskInProgress = False
                    Dirs.Nodes.Remove(node)
                    sts_pb.Visible = False
                    stslbl.Text = "Directory Deleted successfully."
                    stslbl.Image = My.Resources.NimbusResources.check_4_
                    Await Task.Delay(TimeSpan.FromSeconds(3))
                    stslbl.Text = "I'm IDLE."
                    stslbl.Image = My.Resources.NimbusResources.sleep
                Catch ex As Exception
                    NLogger.Log(ex)
                    MBox("Cannot Delete Directory", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End If
    End Sub

    Private Sub createdir_TS_Click(sender As Object, e As EventArgs) Handles createdir_TS.Click
        If TaskInProgress Then
            MBox("Another Task in Progress", "Another task is in progress. Let it finish before starting the next task.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim newdir As New CreateNewDirectory()
        newdir.ShowDialog(Me)
    End Sub

    Public Async Sub CreateDirectoryCall(ByVal newdirname As String)
        Await CreateNewDirectory(newdirname)
    End Sub

    Public Async Function CreateNewDirectory(ByVal dirname As String) As Task
        TaskInProgress = True
        Dim node = Dirs.SelectedNode
        If node Is Nothing OrElse IsEmpty(dirname) Then Exit Function
        'First we will check if directory already exist or not
        Dim newdirpath As String = CombineFtpPath(New String() {CType(node.Tag, FTPDirectory).FullPath, dirname})
        Dim exist = Await NimbFTP.DirectoryExists(newdirpath)
        If exist Then
            TaskInProgress = False
            MBox("Directory Exist", $"The directory '{dirname}' is already exist. Please choose a different name for your new directory.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim result = Await NimbFTP.CreateDirectory(newdirpath)
            TaskInProgress = False
            If result = True Then
                Dim newdirfile As New FTPDirectory() With {.CreatedOn = DateTime.Now, .FolderName = dirname, .FullPath = newdirpath}
                Dim newnode As New TreeNode() With {
                    .Text = dirname,
                    .Tag = newdirfile,
                    .ImageIndex = 2,
                    .SelectedImageIndex = 2}
                node.Nodes.Add(newnode)
                MBox("Success", "Your new directory created successfully.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MBox("Error", "Cannot create directory. Please try again. Check logs for more information.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Function

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        If TaskInProgress Then
            MBox("Another Task in Progress", "Another task is in progress. Let it finish before starting the next task.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If OpenFileDialog1.ShowDialog(Me) = DialogResult.OK Then
            If IsUploading Then
                MBox("Uploading already running", "One uploading task is already running and cannot run more than one upload task. Let the first task complete or you can cancel it.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                UploadFilesCall(OpenFileDialog1.FileNames)
            End If
        End If
    End Sub

    Private Async Sub UploadFilesCall(ByVal files() As String)
        If files.Length = 1 Then
            Dim DirPath As String = CType(Dirs.SelectedNode.Tag, FTPDirectory).FullPath
            Await AddFilesToList(files(0), DirPath)
            Await UploadFile(files(0), DirPath)
        Else
            If Not upfileslist.Items.Count = 0 Then upfileslist.Items.Clear()
            'multiple files upload
            Dim DirPath As String = CType(Dirs.SelectedNode.Tag, FTPDirectory).FullPath
            For Each item As String In files
                Await AddFilesToList(item, DirPath)
            Next
            UploadCancelToken = New CancellationTokenSource()
            pauseresume_upload.Enabled = True
            cancel_upload.Enabled = True
            For Each item As String In files
                Await UploadMultipleFiles(item, DirPath)
            Next
            ShowBalloon("Upload Completed", "Your upload task has been completed.", ToolTipIcon.Info)
            IsUploading = False
            Dirs.Enabled = True
            ftpfiles.Enabled = True
            pauseresume_upload.Enabled = False
            stslbl.Text = "I'm IDLE"
            stslbl.Image = My.Resources.NimbusResources.sleep
            sts_pb.Value = 0
            sts_pb.Visible = False
            speedtime.Text = "..."
            cancel_upload.Enabled = False
            pauseUpload = False
            upfileslist.Items.Clear()
            Await GetFiles(DirPath)
        End If
    End Sub

    Private Async Sub UploadFolderCall(ByVal folder As String)
        If Dirs.SelectedNode Is Nothing Then
            MBox("Error", "Please select a directory where you want to upload the files.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim node = Dirs.SelectedNode
        Dim DirPath As String = CType(Dirs.SelectedNode.Tag, FTPDirectory).FullPath
        Dirs.Enabled = False
        ftpfiles.Enabled = False
        If Not upfileslist.Items.Count = 0 Then upfileslist.Items.Clear()
        'add files to queue list
        For Each file As String In Directory.GetFiles(FolderBrowserDialog1.SelectedPath, "*.*", SearchOption.AllDirectories)
            Await AddFilesToList(file, DirPath)
        Next
        pauseresume_upload.Enabled = True
        cancel_upload.Enabled = True
        IsUploading = True
        sts_pb.Value = 0
        sts_pb.Visible = True
        stslbl.Image = My.Resources.NimbusResources._91
        stslbl.Text = "Upload Started.."
        pauseresume_upload.Enabled = False
        cancel_upload.Enabled = True
        Await UploadFolder(folder, DirPath)
        IsUploading = False
        ShowBalloon("Upload Completed", "Your upload task has been completed.", ToolTipIcon.Info)
        cancel_upload.Enabled = False
        sts_pb.Value = 0
        sts_pb.Visible = False
        stslbl.Text = "I'm IDLE"
        stslbl.Image = My.Resources.NimbusResources.sleep
        speedtime.Text = "..."
        Dirs.Enabled = True
        ftpfiles.Enabled = True
        node.Nodes.Clear()
        Await LoadFtpFolders(DirPath, node)
    End Sub

#Region "Files Uploading"

    Public Async Function UploadFile(ByVal filename As String, ByVal ftppath As String) As Task
        If Not IO.File.Exists(filename) Then
            Throw New Exception(message:="File not found in your system.")
        End If
        Try
            'disable the directory and files list to prevent user make changes while uploading in progress
            Dirs.Enabled = False
            ftpfiles.Enabled = False
            stslbl.Image = My.Resources.NimbusResources._91
            UploadCancelToken = New CancellationTokenSource()
            sts_pb.Visible = True
            sts_pb.Value = 0
            sts_pb.Style = System.Windows.Forms.ProgressBarStyle.Blocks
            stslbl.Text = $"Uploading {filename}"
            Dim item As ListViewItem = GetFileItem(filename)
            item.SubItems(4).Text = "Uploading"
            IsUploading = True
            Dim prog As New Progress(Of FtpProgress)(Sub(p)
                                                         Invoke(New MethodInvoker(Sub()
                                                                                      Me.speedtime.Text = $"Speed: {p.TransferSpeedToString()}  |  Estimate: {FormatTimeSpanReadable(p.ETA)}"
                                                                                      sts_pb.Value = CInt(p.Progress)
                                                                                      item.SubItems(3).Text = $"{CInt(p.Progress)}%"
                                                                                  End Sub))
                                                     End Sub)
            Dim result = Await NimbFTP.UploadFile(localPath:=filename, remotePath:=CombineFtpPath(New String() {ftppath, IO.Path.GetFileName(filename)}), existsMode:=NConfig.UploadOverwriteType,
createRemoteDir:=True, verifyOptions:=FtpVerify.None, progress:=prog, token:=UploadCancelToken.Token)
            IsUploading = False
            If result = FtpStatus.Success Then
                upfileslist.Items.Remove(item)
                Await GetFiles(ftppath)
                ShowBalloon("Upload Complete", "Upload has been successfully done.", ToolTipIcon.Info)
            ElseIf result = FtpStatus.Skipped Then
                item.SubItems(3).Text = "100%"
                item.SubItems(4).Text = "Already Exists"
                item.ImageIndex = 2
                IsUploading = False
                ShowBalloon("Upload Skipped", $"The file {IO.Path.GetFileName(filename)} already exists in the directory.", ToolTipIcon.Warning)
            ElseIf result = FtpStatus.Failed Then
                item.SubItems(3).Text = "0%"
                item.SubItems(4).Text = "Error"
                item.ImageIndex = 1
                IsUploading = False
                ShowBalloon("Upload Failed", "File uploading failed. Check logs for more information.", ToolTipIcon.Error)
            End If

        Catch ex As Exception
            NLogger.Log(ex.InnerException)
            MBox("Error while uploading", ex.InnerException.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            stslbl.Text = "I'm IDLE"
            stslbl.Image = My.Resources.NimbusResources.sleep
            sts_pb.Value = 0
            sts_pb.Visible = False
            speedtime.Text = "..."
            Dirs.Enabled = True
            ftpfiles.Enabled = True
        End Try
    End Function

    Public Async Function UploadMultipleFiles(ByVal filename As String, ByVal ftppath As String) As Task
        Try
            'disable the directory and files list to prevent user make changes while uploading in progress
            Dirs.Enabled = False
            ftpfiles.Enabled = False
            stslbl.Image = My.Resources.NimbusResources._91
            sts_pb.Visible = True
            sts_pb.Value = 0
            sts_pb.Style = System.Windows.Forms.ProgressBarStyle.Blocks
            stslbl.Text = $"Uploading {filename}"
            Dim item As ListViewItem = GetFileItem(filename)
            item.Selected = True
            item.SubItems(4).Text = "Uploading"
            IsUploading = True
            Dim prog As New Progress(Of FtpProgress)(Sub(p)
                                                         Invoke(New MethodInvoker(Sub()
                                                                                      Me.speedtime.Text = $"Speed: {p.TransferSpeedToString()}  |  Estimate: {FormatTimeSpanReadable(p.ETA)}"
                                                                                      sts_pb.Value = CInt(p.Progress)
                                                                                      item.SubItems(3).Text = $"{CInt(p.Progress)}%"
                                                                                  End Sub))
                                                     End Sub)
            UploadPauseEvent.Wait()
            Dim result = Await NimbFTP.UploadFile(localPath:=filename, remotePath:=CombineFtpPath(New String() {ftppath, IO.Path.GetFileName(filename)}), existsMode:=NConfig.UploadOverwriteType,
createRemoteDir:=True, verifyOptions:=FtpVerify.None, progress:=prog, token:=UploadCancelToken.Token)
            IsUploading = False
            If result = FtpStatus.Success Then
                item.SubItems(4).Text = "Completed"
                item.ImageIndex = 1
            ElseIf result = FtpStatus.Skipped Then
                item.SubItems(3).Text = "100%"
                item.SubItems(4).Text = "Already Exists"
                item.ImageIndex = 2
            ElseIf result = FtpStatus.Failed Then
                item.SubItems(3).Text = "0%"
                item.SubItems(4).Text = "Error"
                item.ImageIndex = 2
            End If
        Catch ex As Exception
            NLogger.Log(ex.InnerException)
            MBox("Error while uploading", ex.InnerException.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            UploadCancelToken.Cancel()
            IsUploading = False
        End Try
    End Function

    Private Async Function UploadFolder(ByVal folder As String, ByVal FtpDir As String) As Task
        Try
            UploadCancelToken = New CancellationTokenSource()
            Dim prog As New Progress(Of FtpProgress)(Sub(p)
                                                         Dim item As ListViewItem = GetFileItem(p.LocalPath)
                                                         item.SubItems(3).Text = $"{CInt(p.Progress)}%"
                                                         item.SubItems(4).Text = "Uploading"
                                                         sts_pb.Value = CInt(p.Progress)
                                                         Me.speedtime.Text = $"Speed: {p.TransferSpeedToString()}  |  Estimate: {FormatTimeSpanReadable(p.ETA)}"
                                                         stslbl.Text = $"Uploading {p.LocalPath}"
                                                         If CInt(p.Progress) = 100 Then
                                                             item.SubItems(4).Text = "Completed"
                                                             item.ImageIndex = 1
                                                         End If
                                                     End Sub)
            Dim result = Await NimbFTP.UploadDirectory(localFolder:=folder, remoteFolder:=FtpDir, mode:=FtpFolderSyncMode.Update, existsMode:=NConfig.UploadOverwriteType,
                 verifyOptions:=FtpVerify.None, rules:=Nothing, progress:=prog, token:=UploadCancelToken.Token)
            For Each item As FtpResult In result
                Dim Litem As ListViewItem = GetFileItem(item.LocalPath)
                If Litem IsNot Nothing Then
                    If item.IsSuccess Then
                        Litem.SubItems(4).Text = "Uploaded"
                        Litem.ImageIndex = 1
                    ElseIf item.IsFailed Then
                        Litem.SubItems(4).Text = "Failed"
                        Litem.ImageIndex = 2
                    End If
                End If
            Next
        Catch ex As Exception
            NLogger.Log(ex.InnerException)
        End Try

    End Function



    Public Sub PauseUploading()
        UploadPauseEvent.Reset() ' Pauses uploading
        pauseresume_upload.Text = "Resume Uploading"
        pauseresume_upload.Image = My.Resources.NimbusResources.play_2_
        pauseUpload = True
    End Sub

    Public Sub ResumeUploading()
        UploadPauseEvent.Set() ' Resumes uploading
        pauseresume_upload.Text = "Pause Uploading"
        pauseresume_upload.Image = My.Resources.NimbusResources.pause_2_
        pauseUpload = False
    End Sub

    Public Async Sub CancelUploading()
        If UploadCancelToken IsNot Nothing AndAlso IsUploading Then
            Await UploadCancelToken.CancelAsync()
            IsUploading = False
            upfileslist.Items.Clear()
            Dirs.Enabled = True
            ftpfiles.Enabled = True
            cancel_upload.Enabled = False
            pauseresume_upload.Enabled = False
            pauseUpload = False
        End If
    End Sub

    Private Async Function AddFilesToList(ByVal file As String, ByVal dir As String) As Task
        Await Task.Run(Sub()
                           If IO.File.Exists(file) Then
                               Dim item As New ListViewItem() With {
                                     .Text = file,
                                     .ImageIndex = 0,
                                     .UseItemStyleForSubItems = True}
                               item.SubItems.AddRange(New String() {FormatBytes(New FileInfo(file).Length), dir, "0%", "In queue"})
                               Me.upfileslist.Items.Add(item)
                           Else
                               MBox("File not found", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                           End If
                       End Sub)
    End Function


    Private Function GetFileItem(ByVal filename As String) As ListViewItem
        Return upfileslist.Items.Cast(Of ListViewItem)().FirstOrDefault(Function(x) x.Text.Equals(filename, StringComparison.OrdinalIgnoreCase), Nothing)
    End Function

    Private Sub UpdateUploadUI(p As FtpProgress, ByVal item As ListViewItem)
        If item IsNot Nothing Then item.SubItems(3).Text = $"{CInt(p.Progress)}"
        sts_pb.Value = CInt(p.Progress)
        stslbl.Text = $"Uploading {p.LocalPath }"
        speedtime.Text = $"Uploading Speed: {p.TransferSpeedToString()}  |  Estimate Time: {FormatTimeSpanReadable(p.ETA)}"
    End Sub
#End Region

    Public Sub ShowBalloon(ByVal title As String, ByVal text As String, ByVal icon As ToolTipIcon)
        NotIcon.ShowBalloonTip(6000, tipTitle:=title, tipText:=text, tipIcon:=icon)
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        If TaskInProgress Then
            MBox("Another Task in Progress", "Another task is in progress. Let it finish before starting the next task.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If FolderBrowserDialog1.ShowDialog(Me) = DialogResult.OK Then
            If IsUploading Then
                MBox("Uploading already running", "One uploading task is already running and cannot run more than one upload task. Let the first task complete or you can cancel it.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                UploadFolderCall(FolderBrowserDialog1.SelectedPath)
            End If
        End If
    End Sub

    Private Async Sub RefreshDirectoriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshDirectoriesToolStripMenuItem.Click
        If TaskInProgress Then
            MBox("Another Task in Progress", "Another task is in progress. Let it finish before starting the next task.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If Dirs.SelectedNode Is Nothing Then Exit Sub
        Dim node = Dirs.SelectedNode
        node.Nodes.Clear()
        Dirs.Enabled = False
        Await LoadFtpFolders(CType(node.Tag, FTPDirectory).FullPath, node)
        Dirs.Enabled = True
    End Sub

    Private Sub Dirs_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles Dirs.NodeMouseClick
        If e.Button = MouseButtons.Right Then Dirs.SelectedNode = e.Node
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        ToolStripMenuItem2.PerformClick()
    End Sub

    Private Sub ToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem6.Click
        ToolStripMenuItem3.PerformClick()
    End Sub

    Private Sub pauseresume_upload_Click(sender As Object, e As EventArgs) Handles pauseresume_upload.Click
        If IsUploading Then
            If pauseUpload = True Then PauseUploading() Else ResumeUploading()
        End If
    End Sub

    Private Sub cancel_upload_Click(sender As Object, e As EventArgs) Handles cancel_upload.Click
        CancelUploading()
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        Process.Start(New ProcessStartInfo() With {.FileName = NLogger.logFile, .UseShellExecute = True})
    End Sub

    Private Sub download_dirTS_Click(sender As Object, e As EventArgs) Handles download_dirTS.Click
        If TaskInProgress Then
            MBox("Another Task in Progress", "Another task is in progress. Let it finish before starting the next task.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim node = Dirs.SelectedNode
        If node Is Nothing Then Exit Sub
        If DownloadFolderDlg.ShowDialog(Me) = DialogResult.OK Then
            TaskInProgress = True
            Dim ftpdir As FTPDirectory = CType(node.Tag, FTPDirectory)
            Dim downForm As New DownloadFolder(Me.NimbFTP, ftpdir, DownloadFolderDlg.SelectedPath)
            If downForm.ShowDialog(Me) = DialogResult.OK Then TaskInProgress = False
        End If
    End Sub

    Private Sub FtpFiles_CM_Opening(sender As Object, e As CancelEventArgs) Handles FtpFiles_CM.Opening
        'cancel if no items selected or no items in list
        If ftpfiles.Items.Count = 0 OrElse ftpfiles.SelectedItems.Count = 0 Then e.Cancel = True

    End Sub

#Region "Download Files"
    Private WithEvents DownDlg As ProgressDialog
    Private DownloadCancelToken As CancellationTokenSource
    Public Sub DownloadFilesCall()
        If TaskInProgress Then
            MBox("Another Task in Progress", "Another task is in progress. Let it finish before starting the next task.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim files As New List(Of FTPFile)()
        For Each item As ListViewItem In Me.ftpfiles.SelectedItems
            files.Add(CType(item.Tag, FTPFile))
        Next
        DownDlg = New ProgressDialog() With {
            .CancellationText = "Cancelling Download...",
            .Description = "Starting Download..",
            .MinimizeBox = False,
            .ProgressBarStyle = ProgressBarStyle.ProgressBar,
            .ShowCancelButton = True,
            .ShowTimeRemaining = False,
            .WindowTitle = "Downloading Files"}
        TaskInProgress = True
        DownloadCancelToken = New CancellationTokenSource()
        DownDlg.ShowDialog(owner:=Me, argument:=files)
    End Sub

    Private Sub DownDlg_DoWork(sender As Object, e As DoWorkEventArgs) Handles DownDlg.DoWork
        Dim Dlg As ProgressDialog = CType(sender, ProgressDialog)
        Dim files As List(Of FTPFile) = CType(e.Argument, List(Of FTPFile))

        Try
            For Each item As FTPFile In files
                ' Monitor for dialog cancellation
                If Dlg.CancellationPending Then
                    DownloadCancelToken.Cancel()
                    e.Cancel = True
                    Exit For
                End If
                Dim prog As New Progress(Of FtpProgress)(Sub(p)
                                                             If Dlg.CancellationPending Then
                                                                 DownloadCancelToken.Cancel()
                                                                 e.Cancel = True
                                                             Else
                                                                 If Not p.Progress = -1 Then
                                                                     Dlg.ReportProgress(CInt(p.Progress), $"Downloading {IO.Path.GetFileName(p.LocalPath)}", $"Estimate Time: {FormatTimeSpanReadable(p.ETA)}       {p.TransferSpeedToString()}")
                                                                     Dlg.WindowTitle = $"Downloading File(s) {p.FileIndex}/{p.FileCount}"
                                                                 End If
                                                             End If
                                                         End Sub)
                NimbFTP.DownloadFile(localPath:=Path.Combine(NConfig.DownloadDirectory, item.Filename), remotePath:=item.FullPath, existsMode:=NConfig.DownloadOverwriteType,
    verifyOptions:=FtpVerify.None, progress:=prog, token:=DownloadCancelToken.Token).GetAwaiter().GetResult()
            Next
        Catch ex As OperationCanceledException
            e.Cancel = True
        Catch ex As Exception
            NLogger.Log(ex)
        End Try
    End Sub

    Private Sub DownDlg_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles DownDlg.RunWorkerCompleted
        Dim dlg As ProgressDialog = CType(sender, ProgressDialog)
        If e.Error IsNot Nothing Then
            ShowBalloon(title:="Download Error", e.Error.Message, ToolTipIcon.Error)
            TaskInProgress = False
            dlg.Dispose()
        ElseIf e.Cancelled Then
            ShowBalloon(title:="Download Cancelled", "Download task has been cancelled.", ToolTipIcon.Warning)
            TaskInProgress = False
            dlg.Dispose()
        Else
            ShowBalloon(title:="Download Completed", "Download task has been completed.", ToolTipIcon.Info)
            TaskInProgress = False
            dlg.Dispose()
        End If
    End Sub

    Private Sub ToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem10.Click
        DownloadFilesCall()
    End Sub
#End Region

    Private Sub ToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem12.Click
        If ftpfiles.SelectedItems.Count = 1 Then
            Clipboard.SetText(ftpfiles.SelectedItems(0).Text)
        Else
            Dim str As New Text.StringBuilder()
            For Each item As ListViewItem In ftpfiles.SelectedItems
                str.AppendLine(item.Text)
            Next
            Clipboard.SetText(str.ToString())
        End If
    End Sub

    Private Sub ToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem13.Click
        If ftpfiles.SelectedItems.Count = 1 Then
            Dim ftpitem As FTPFile = CType(ftpfiles.SelectedItems(0).Tag, FTPFile)
            Clipboard.SetText($"ftp://{NimbFTP.Credentials.UserName}@{NimbFTP.Host}{ftpitem.FullPath}")
        Else
            Dim str As New Text.StringBuilder()
            For Each item As ListViewItem In ftpfiles.SelectedItems
                Dim ftpitem As FTPFile = CType(item.Tag, FTPFile)
                str.AppendLine($"ftp://{NimbFTP.Credentials.UserName}@{NimbFTP.Host}{ftpitem.FullPath}")
            Next
            Clipboard.SetText(str.ToString())
        End If
    End Sub

    Private Async Sub ToolStripMenuItem14_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem14.Click
        If TaskInProgress Then
            MBox("Another Task in Progress", "Another task is in progress. Let it finish before starting the next task.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        TaskInProgress = True
        stslbl.Text = "Duplicating the file(s).."
        stslbl.Image = My.Resources.NimbusResources._91
        sts_pb.Visible = True
        sts_pb.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        For Each item As ListViewItem In ftpfiles.SelectedItems
            Dim ftpitem As FTPFile = CType(item.Tag, FTPFile)
            Dim newfilename As String = Await GenerateUniqueFtpFilename(ftpitem.FullPath)
            Using readStream As Stream = Await NimbFTP.OpenRead(ftpitem.FullPath)
                Using writeStream As Stream = Await NimbFTP.OpenWrite(newfilename, NConfig.TransferDataType, FtpRemoteExists.Overwrite)
                    Await readStream.CopyToAsync(writeStream)
                End Using
            End Using
            Await Task.Delay(500)
        Next
        TaskInProgress = False
        stslbl.Text = "I'm IDLE"
        stslbl.Image = My.Resources.NimbusResources.sleep
        sts_pb.Visible = False
        sts_pb.Style = System.Windows.Forms.ProgressBarStyle.Blocks
    End Sub
    Private Async Function GenerateUniqueFtpFilename(remotePath As String) As Task(Of String)
        Dim directory As String = GetFtpDirectory(remotePath)
        Dim filename As String = Path.GetFileNameWithoutExtension(remotePath)
        Dim extension As String = Path.GetExtension(remotePath)

        Dim newName As String = $"{filename}_copy{extension}"
        Dim index As Integer = 1

        While Await NimbFTP.FileExists($"{directory}/{newName}")
            newName = $"{filename}_copy({index}){extension}"
            index += 1
            Await Task.Delay(1000)
        End While

        Return $"{directory}/{newName}"
    End Function

    Private Async Sub ToolStripMenuItem20_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem20.Click
        If TaskInProgress Then
            MBox("Another Task in Progress", "Another task is in progress. Let it finish before starting the next task.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If ftpfiles.SelectedItems.Count = 1 Then
            If MBox("Delete File", "Do you really want to delete this file from your FTP directory?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                TaskInProgress = True
                Dim ftpitem As FTPFile = CType(ftpfiles.SelectedItems(0).Tag, FTPFile)
                Await NimbFTP.DeleteFile(ftpitem.FullPath)
                ftpfiles.Items.Remove(ftpfiles.SelectedItems(0))
                ShowBalloon("File Deleted", "File has been deleted successfully.", ToolTipIcon.Info)
                TaskInProgress = False
            End If
        Else
            If MBox("Delete Files", "Do you really want to delete selected files from your FTP directory?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                TaskInProgress = True
                stslbl.Text = "Deleting files.."
                stslbl.Image = My.Resources.NimbusResources._91
                sts_pb.Visible = True
                sts_pb.Style = System.Windows.Forms.ProgressBarStyle.Marquee
                For Each item As ListViewItem In ftpfiles.SelectedItems
                    Dim ftpitem As FTPFile = CType(item.Tag, FTPFile)
                    Await NimbFTP.DeleteFile(ftpitem.FullPath)
                    ftpfiles.Items.Remove(item)
                    Await Task.Delay(200)
                Next
                ShowBalloon("Files Deleted", "All selected files has been deleted successfully.", ToolTipIcon.Info)
                TaskInProgress = False
                stslbl.Text = "I'm IDLE"
                stslbl.Image = My.Resources.NimbusResources.sleep
                sts_pb.Visible = False
                sts_pb.Style = System.Windows.Forms.ProgressBarStyle.Blocks
            End If
        End If
    End Sub

    Private Sub ToolStripMenuItem19_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem19.Click
        If TaskInProgress Then
            MBox("Another Task in Progress", "Another task is in progress. Let it finish before starting the next task.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim permF As New ChangePermission(CType(ftpfiles.SelectedItems(0).Tag, FTPFile))
        permF.ShowDialog(Me)
    End Sub

    Private Sub ToolStripMenuItem18_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem18.Click
        If TaskInProgress Then
            MBox("Another Task in Progress", "Another task is in progress. Let it finish before starting the next task.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim item As ListViewItem = ftpfiles.SelectedItems(0)
        If item IsNot Nothing Then
            ftpfiles.LabelEdit = True
            item.BeginEdit()
        End If
    End Sub

    Private Async Sub Ftpfiles_AfterLabelEdit(sender As Object, e As LabelEditEventArgs) Handles ftpfiles.AfterLabelEdit
        If e.CancelEdit Then
            ftpfiles.LabelEdit = False
            Exit Sub
        End If
        Dim ftpitem As FTPFile = CType(ftpfiles.Items.Item(e.Item).Tag, FTPFile)
        If ftpitem.Filename.Equals(e.Label) Then
            ftpfiles.LabelEdit = False
            Exit Sub
        Else
            TaskInProgress = True
            stslbl.Text = "Renaming the file.."
            sts_pb.Visible = True
            sts_pb.Style = System.Windows.Forms.ProgressBarStyle.Marquee
            stslbl.Image = My.Resources.NimbusResources._91
            Try
                Dim result = Await NimbFTP.MoveFile(ftpitem.FullPath, CombineFtpPath(New String() {GetFtpDirectory(ftpitem.FullPath), e.Label}), FtpRemoteExists.Overwrite)
                If result = True Then
                    ShowBalloon("File Renamed", "The file has been renamed successfully.", ToolTipIcon.Info)
                Else
                    ShowBalloon("Cannot Renamed", "There is an error while renaming the file. Check logs for more info.", ToolTipIcon.Error)
                End If
            Catch ex As Exception
                If ex.InnerException IsNot Nothing Then NLogger.Log(ex.InnerException) Else NLogger.Log(ex)
            Finally
                TaskInProgress = False
                stslbl.Text = "I'm IDLE"
                sts_pb.Visible = False
                sts_pb.Style = System.Windows.Forms.ProgressBarStyle.Blocks
                stslbl.Image = My.Resources.NimbusResources.sleep
            End Try
        End If

    End Sub

    Private Async Sub ToolStripMenuItem17_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem17.Click
        If Dirs.SelectedNode Is Nothing Then
            MBox("Select a Directory", "Please select a directory to Get/Refresh files.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If TaskInProgress Then
            MBox("Another Task in Progress", "Another task is in progress. Let it finish before starting the next task.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        TaskInProgress = True
        Dim Dir As FTPDirectory = CType(Dirs.SelectedNode.Tag, FTPDirectory)
        ftpfiles.Items.Clear()
        Await GetFiles(Dir.FullPath)
        TaskInProgress = False
    End Sub

    Private Async Sub ToolStripMenuItem16_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem16.Click
        If Dirs.SelectedNode Is Nothing Then
            MBox("Select a Directory", "Please select a directory to create a new file.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If TaskInProgress Then
            MBox("Another Task in Progress", "Another task is in progress. Let it finish before starting the next task.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim ftpitem As FTPDirectory = CType(Dirs.SelectedNode.Tag, FTPDirectory)
        Dim Dlg As New InputDialog() With {.Content = $"Please write a name of your new file with extension.{Environment.NewLine}Ex.: mynewfile.php", .MainInstruction = "Creating a New File", .Multiline = False, .WindowTitle = "New File"}
        If Dlg.ShowDialog(Me) = DialogResult.OK Then
            TaskInProgress = True
            Dim newfilename As String = Dlg.Input
            Dim newfilepath As String = CombineFtpPath(New String() {ftpitem.FullPath, Dlg.Input})
            If Await IsFileExist(newfilepath) Then
                MBox("File already Exists", $"The file '{Dlg.Input}' is already exist. Please choose another name.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TaskInProgress = False
                Exit Sub
            Else
                Using stream As Stream = Await NimbFTP.OpenWrite(newfilepath, FtpDataType.ASCII, FtpRemoteExists.Skip)
                End Using
                Dim reply = Await NimbFTP.GetReply()
                If reply.Success Then
                    ShowBalloon("New File Created", "Your file has been created successfully.", ToolTipIcon.Info)
                    Dim fFile As New FTPFile() With {.Extension = System.IO.Path.GetExtension(newfilepath),
                            .CreatedOn = DateTime.Now,
                            .Filename = Dlg.Input,
                            .FileSize = Await NimbFTP.GetFileSize(newfilepath),
                            .FullPath = newfilepath,
                            .LastModifiedOn = DateTime.Now,
                            .Permission = Await NimbFTP.GetChmod(newfilepath)}
                    Dim fileitem As New ListViewItem() With {.Text = fFile.Filename}
                    fileitem.SubItems.Add(FormatBytes(fFile.FileSize))
                    fileitem.SubItems.Add(fFile.CreatedOn.ToString())
                    fileitem.SubItems.Add(fFile.LastModifiedOn.ToString())
                    fileitem.SubItems.Add(fFile.Permission.ToString())
                    fileitem.ImageIndex = GetImageForExtension(fFile.Extension)
                    fileitem.Tag = fFile
                    ftpfiles.Items.Add(fileitem)
                Else
                    ShowBalloon("File Created Failed", reply.Message, ToolTipIcon.Error)
                End If
            End If
            TaskInProgress = False
        End If
    End Sub

    Public Async Function IsFileExist(ByVal filepath As String) As Task(Of Boolean)
        Dim result = Await NimbFTP.FileExists(filepath)
        Return result
    End Function

#Region " OPEN, EDIT AND SAVE FILE "
    Private Async Sub ToolStripMenuItem15_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem15.Click
        If TaskInProgress Then
            MBox("Another Task in Progress", "Another task is in progress. Let it finish before starting the next task.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        TaskInProgress = True
        Dim fileitem As FTPFile = CType(ftpfiles.SelectedItems(0).Tag, FTPFile)
        Dim randomname As String = IO.Path.GetTempFileName()
        Await NimbFTP.DownloadFile(randomname, fileitem.FullPath, FtpLocalExists.Overwrite, FtpVerify.None)
        Dim editform As New NEditor(randomname, fileitem)
        If editform.ShowDialog(Me) = DialogResult.OK Then TaskInProgress = False
    End Sub

    Public Async Function SaveStreamCall(ByVal filetext As String, ByVal remotepath As String) As Task(Of Boolean)
        Try
            Dim result = Await NimbFTP.UploadFile(filetext, remotepath, FtpRemoteExists.Overwrite, False, FtpVerify.None)
            IO.File.Delete(filetext)
            If result = FtpStatus.Success Then Return True Else Return False
        Catch ex As Exception
            If ex.InnerException IsNot Nothing Then NLogger.Log(ex.InnerException) Else NLogger.Log(ex)
            MBox("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

#End Region

    Private Sub CompareFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompareFileToolStripMenuItem.Click
        If TaskInProgress Then
            MBox("Another Task in Progress", "Another task is in progress. Let it finish before starting the next task.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim OFD As New OpenFileDialog() With {.Title = "Select a file to compare", .Multiselect = False}
        If OFD.ShowDialog(Me) = DialogResult.OK Then
            TaskInProgress = True
            Dim Dlg As New ProgressDialog() With {
    .ShowCancelButton = False,
    .Description = $"Comparing {IO.Path.GetFileName(OFD.FileName)}",
    .MinimizeBox = False,
    .ProgressBarStyle = ProgressBarStyle.MarqueeProgressBar,
    .ShowTimeRemaining = False,
    .Text = "Comparing both files",
    .WindowTitle = "File Comparing"}

            AddHandler Dlg.DoWork, AddressOf CompareFileDoWork
            Dlg.ShowDialog(Me, OFD.FileName)
        End If
    End Sub

    Private Sub CompareFileDoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs)
        Dim localfile As String = CType(e.Argument, String)
        Dim ftpfile As String = CType(ftpfiles.SelectedItems(0).Tag, FTPFile).FullPath
        Dim Dlg As ProgressDialog = CType(sender, ProgressDialog)
        Dim result = CompareFile(localfile, ftpfile).GetAwaiter().GetResult()
        Select Case result
            Case FtpCompareResult.ChecksumNotSupported
                ShowBalloon("Cannot Support", "Your server doesn't support any hash algorithm.", ToolTipIcon.Warning)
            Case FtpCompareResult.Equal
                ShowBalloon("File are Same", "Your local file and FTP file are same.", ToolTipIcon.Info)
            Case FtpCompareResult.FileNotExisting
                ShowBalloon("File doesn't Exist", "Either the local file or FTP file doesn't exist.", ToolTipIcon.Error)
            Case FtpCompareResult.NotEqual
                ShowBalloon("File not Same", "Your local file is different from yout FTP file.", ToolTipIcon.Info)
        End Select
        TaskInProgress = False
        RemoveHandler Dlg.DoWork, AddressOf CompareFileDoWork
        Dlg.Dispose()
    End Sub

    Public Async Function CompareFile(ByVal localfile As String, ByVal ftpfile As String) As Task(Of FtpCompareResult)
        Dim result = Await NimbFTP.CompareFile(localfile, ftpfile, NConfig.CompareFileType)
        Return result
    End Function

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        Settings.Show()
    End Sub

    Private Sub NEditorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NEditorToolStripMenuItem.Click
        Dim NEdit As New NEditor()
        NEdit.SaveToolStripMenuItem.Enabled = False
        NEdit.Show(Me)
    End Sub

    Private Sub FileSearcherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileSearcherToolStripMenuItem.Click
        If TaskInProgress Then
            MBox("Another Task in Progress", "Another task is in progress. Let it finish before starting the next task.", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Dim AComplete As New AutoCompleteStringCollection()
        For Each item As TreeNode In Dirs.Nodes
            AComplete.Add(item.Text)
        Next
        Dim FSearcher As New FileSearcher(NimbFTP)
        FSearcher.Dirtxt.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        FSearcher.Dirtxt.AutoCompleteSource = AutoCompleteSource.CustomSource
        FSearcher.Dirtxt.AutoCompleteCustomSource = AComplete
        TaskInProgress = True
        If FSearcher.ShowDialog(Me) = DialogResult.OK Then TaskInProgress = False
    End Sub

    Private Async Sub AutoConnectClient(state As Object)
        If NimbFTP.IsConnected = False AndAlso AutoConnecting = False Then
            NLogger.LogInfo("Client disconnected. Trying to reconnect.")
            AutoConnecting = True
            Await NimbFTP.Connect()
            AutoConnecting = False
        End If
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        Profiles.Show()
    End Sub

    Private Sub ReportBugToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportBugToolStripMenuItem.Click
        Process.Start(New ProcessStartInfo() With {.FileName = "https://github.com/Nothing-Just-a-Code/Nimbus/issues/new", .UseShellExecute = True})
    End Sub

    Private Sub CreditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreditsToolStripMenuItem.Click
        Credits.Show(Me)
    End Sub

    Private Sub AboutNimbusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutNimbusToolStripMenuItem.Click
        Process.Start(New ProcessStartInfo() With {.FileName = "https://github.com/Nothing-Just-a-Code/Nimbus", .UseShellExecute = True})
    End Sub
End Class