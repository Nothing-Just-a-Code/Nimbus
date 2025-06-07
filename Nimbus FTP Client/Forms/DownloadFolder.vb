Imports System.Threading
Imports FluentFTP

Public Class DownloadFolder
    Private ftpclient As AsyncFtpClient
    Private FtpDir As FTPDirectory
    Private SelectedFolder As String
    Private CancelToken As New CancellationTokenSource()
    Private IsCancelled As Boolean = False
    Sub New(ByVal client As AsyncFtpClient, dir As FTPDirectory, ByVal folderpath As String)
        InitializeComponent()
        Me.ftpclient = client
        Me.FtpDir = dir
        Me.SelectedFolder = folderpath
    End Sub
    Private Sub DownloadFolder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        StartDownloadTask()
    End Sub


    Private Async Sub StartDownloadTask()
        Try
            Dim prog As New Progress(Of FtpProgress)(Sub(p)
                                                         'UpdateProgressUI(p)
                                                         filedownprog.Invoke(New MethodInvoker(Sub()
                                                                                                   UpdateProgressUI(p)
                                                                                               End Sub))
                                                     End Sub)
            overallprog.Style = ProgressBarStyle.Marquee
            overallprog.MarqueeAnimationSpeed = 20
            Await ftpclient.DownloadDirectory(SelectedFolder, FtpDir.FullPath, FtpFolderSyncMode.Update, NimbusX.NConfig.DownloadOverwriteType, FtpVerify.None,
Nothing, prog, CancelToken.Token)
            If IsCancelled Then
                CType(Me.Owner, MainForm).NotIcon.ShowBalloonTip(6000, "Download Cancelled", "Your download task has been cancelled.", ToolTipIcon.Info)
            Else
                CType(Me.Owner, MainForm).NotIcon.ShowBalloonTip(6000, "Download Completed", "Your download task has been done.", ToolTipIcon.Info)
            End If
        Catch ex As Exception
            If ex IsNot Nothing Then
                If ex.InnerException IsNot Nothing Then NLogger.Log(ex.InnerException) Else NLogger.Log(ex)
                NimbusX.MBox("Error", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End Try
    End Sub

    Private Sub UpdateProgressUI(ByVal p As FtpProgress)
        If InvokeRequired Then
            Invoke(New MethodInvoker(Sub() UpdateProgressUI(p)))
            Return
        End If
        Label1.Text = "Downloading Directory..."
        overallprog.Style = ProgressBarStyle.Blocks
        'set overall progress
        Dim totalFiles = CULng(p.FileCount)
        Dim currentfile = CULng(p.FileIndex)

        ' Avoid divide by zero
        If totalFiles = 0 Then totalFiles = 1

        ' Scale
        Dim scaledValue As Integer = CInt((currentfile * overallprog.Maximum) / totalFiles)

        ' Clamp
        If scaledValue < overallprog.Minimum Then scaledValue = overallprog.Minimum
        If scaledValue > overallprog.Maximum Then scaledValue = overallprog.Maximum

        ' Update on UI thread
        overallprog.Value = scaledValue

        'update file download progress
        If Not p.Progress = -1 Then filedownprog.Value = CInt(p.Progress)

        Fname.Text = $"Downloading file: {p.RemotePath}"
        downspeed.Text = p.TransferSpeedToString()
        downeta.Text = NimbusX.FormatTimeSpanReadable(p.ETA)
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.Enabled = False
        IsCancelled = True
        Label1.Text = "Cancelling. Please wait..."
        overallprog.Style = ProgressBarStyle.Marquee
        Await CancelToken.CancelAsync()
    End Sub
End Class