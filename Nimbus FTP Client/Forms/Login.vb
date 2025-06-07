Imports System.ComponentModel
Imports System.IO
Imports FluentFTP
Imports FluentFTP.Client.BaseClient
Imports Nimbus_FTP_Client.NimbusX
Imports Ookii.Dialogs.WinForms
Imports Newtonsoft.Json
Public Class Login
    Private WithEvents NimbFTP As New FluentFTP.AsyncFtpClient()
    Private RunProfile As String
    Sub New(Optional pPath As String = "")
        InitializeComponent()
        RunProfile = pPath
    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsEmpty(Me.ftphost.Text) Or IsEmpty(ftpuser.Text) Or IsEmpty(ftppass.Text) Then
            MBox("One or more field is missing", "Please fill all fields to connect to your FTP server.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        Else
            Try
                If IsEmpty(ftpport.Text) Then ftpport.Text = "21"
                Me.GroupBox1.Enabled = False
                ProgressBar1.Visible = True
                If NimbFTP.IsAuthenticated Or NimbFTP.IsConnected Then Await NimbFTP.Disconnect()
                NimbFTP.Host = Me.ftphost.Text
                NimbFTP.Credentials = New Net.NetworkCredential(userName:=Me.ftpuser.Text, password:=Me.ftppass.Text)
                NimbFTP.Port = Integer.Parse(Me.ftpport.Text)
                NimbFTP.Config.EncryptionMode = NConfig.EncryptionMode
                NimbFTP.Config.ConnectTimeout = NConfig.ConnectionTimeoutSeconds * 1000
                NimbFTP.Config.DataConnectionConnectTimeout = NimbusX.NConfig.DataConnectionTimeoutSeconds * 1000
                NimbFTP.Config.ReadTimeout = NConfig.ReadTimeoutSeconds * 1000
                NimbFTP.Config.RetryAttempts = NConfig.RetryTaskLimit

                'NOOP
                NimbFTP.Config.Noop = True
                NimbFTP.Config.NoopInterval = 60 * 1000

                Await NimbFTP.AutoConnect()
                If NimbFTP.IsConnected AndAlso NimbFTP.IsAuthenticated Then
                    'save profile for later use
                    If SaveProfile.Checked = True Then SaveNimbusProfile(New NimbusProfile() With {
                                                                      .EncryptionMode = FtpEncryptionMode.Auto,
                                                                      .FTPHostname = ftphost.Text,
                                                                      .FTPUsername = ftpuser.Text,
                                                                      .FTPPort = Integer.Parse(ftpport.Text),
                                                                      .ReadTimeout = 15000,
                                                                      .Timeout = 15000})
                    CredentialManager.SavePassword(ftphost.Text, ftpuser.Text, ftppass.Text)
                    Dim MF As New MainForm(NimbFTP)
                    MF.Show()
                    Me.Close()
                End If
            Catch ex As FluentFTP.Exceptions.FtpAuthenticationException
                ProgressBar1.Visible = False
                MBox("Authentication Failed", "Authentication Failed! Please check your username or password and try again.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.GroupBox1.Enabled = True
            Catch ex2 As Exception
                ProgressBar1.Visible = False
                MBox("Error while authentication", ex2.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.GroupBox1.Enabled = True
            End Try
        End If
    End Sub

    Private Sub Profiles()
        If Not NimbusX.NimbusProfiles.Count = 0 Then
            For Each item As NimbusProfile In NimbusProfiles
                Dim itm = NimbusProfilesToolStripMenuItem.DropDownItems.Add($"{item.FTPUsername}@{item.FTPHostname}", BytesToImage(My.Resources.NimbusResources.link_2_))
                itm.Tag = item
                AddHandler itm.Click, New EventHandler(AddressOf OnCMClick)
            Next
        End If
    End Sub

    Private Sub OnCMClick(ByVal sender As Object, ByVal obj As Object)
        LoginWithProfile(CType(CType(sender, ToolStripItem).Tag, NimbusProfile))
    End Sub

    Private Sub NimbFTP_ValidateCertificate(control As BaseFtpClient, e As FtpSslValidationEventArgs) Handles NimbFTP.ValidateCertificate
        If IsTrustedCert(control.Host, e.Certificate) = True Then
            e.Accept = True
        Else
            Select Case e.PolicyErrors
                Case Net.Security.SslPolicyErrors.RemoteCertificateChainErrors
                    Dim check As New CertCheckup(e.Certificate, "The server's certificate is not trusted. This may be caused by a self-signed or expired certificate. Please verify the connection details or contact the server administrator.")
                    Dim res = check.ShowDialog()
                    If res = DialogResult.Yes Then
                        AddTrustedCert(control.Host, e.Certificate)
                        e.Accept = True
                    ElseIf res = DialogResult.OK Then
                        e.Accept = True
                    ElseIf res = DialogResult.No Then
                        e.Accept = False
                    End If
                Case Net.Security.SslPolicyErrors.RemoteCertificateNameMismatch
                    Dim check As New CertCheckup(e.Certificate, "The certificate name does not match the server name.")
                    Dim res = check.ShowDialog()
                    If res = DialogResult.Yes Then
                        AddTrustedCert(control.Host, e.Certificate)
                        e.Accept = True
                    ElseIf res = DialogResult.OK Then
                        e.Accept = True
                    ElseIf res = DialogResult.No Then
                        e.Accept = False
                    End If
                Case Net.Security.SslPolicyErrors.RemoteCertificateNotAvailable
                    Dim msg = "The server did not provide an SSL certificate. This may indicate that the server doesn't support FTPS or there's a configuration issue. Do you want to connect without SSL (not secure)?"
                    Dim check As New CertCheckup(e.Certificate, msg)
                    Dim res = check.ShowDialog()
                    If res = DialogResult.Yes Then
                        AddTrustedCert(control.Host, e.Certificate)
                        e.Accept = True
                    ElseIf res = DialogResult.OK Then
                        e.Accept = True
                    ElseIf res = DialogResult.No Then
                        e.Accept = False
                    End If
            End Select
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles SaveProfile.CheckedChanged
        If SaveProfile.Checked = True Then
            MBox("WARNING!!", $"Nimbus Profile is a quick method to login your ftp account in one click. It will save your data like FTP Host and FTP User in plain-text{Environment.NewLine}and your FTP Password will be saved encrypted and will not be able to read by anyone but this is one-click login{Environment.NewLine}system so make sure you are using your personal trusted system.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Async Sub LoginWithProfile(ByVal prof As NimbusProfile)
        Try
            Me.GroupBox1.Enabled = False
            ProgressBar1.Visible = True
            If NimbFTP.IsAuthenticated Or NimbFTP.IsConnected Then Await NimbFTP.Disconnect()
            NimbFTP.Host = prof.FTPHostname
            NimbFTP.Credentials = New Net.NetworkCredential(userName:=prof.FTPUsername, password:=CredentialManager.GetPassword(prof.FTPHostname))
            If IsNothing(prof.FTPPort) Or prof.FTPPort = 0 Then NimbFTP.Port = 21 Else NimbFTP.Port = prof.FTPPort
            NimbFTP.Config.EncryptionMode = prof.EncryptionMode
            NimbFTP.Config.ConnectTimeout = prof.Timeout
            NimbFTP.Config.ReadTimeout = prof.ReadTimeout
            NimbFTP.Config.DataConnectionType = FtpDataConnectionType.AutoPassive
            NimbFTP.Config.DataConnectionConnectTimeout = NimbusX.NConfig.DataConnectionTimeoutSeconds * 1000
            NimbFTP.Config.RetryAttempts = NConfig.RetryTaskLimit

            'NOOP
            NimbFTP.Config.Noop = True
            NimbFTP.Config.NoopInterval = 60 * 1000


            Await NimbFTP.AutoConnect()
            If NimbFTP.IsConnected AndAlso NimbFTP.IsAuthenticated Then
                Dim MF As New MainForm(NimbFTP)
                MF.Show()
                Me.Close()
            End If
        Catch ex As FluentFTP.Exceptions.FtpAuthenticationException
            ProgressBar1.Visible = False
            MBox("Authentication Failed", "Authentication Failed! Please check your username or password and try again.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.GroupBox1.Enabled = True
        Catch ex2 As Exception
            ProgressBar1.Visible = False
            MBox("Error while authentication", ex2.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.GroupBox1.Enabled = True
        End Try
    End Sub

    Private Sub NProfilesCM_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles NProfilesCM.Opening
        If IsEmpty(ftphost.SelectedText) Then CopyToolStripMenuItem.Enabled = False Else CopyToolStripMenuItem.Enabled = True
        If IsEmpty(Clipboard.GetText()) Then PasteToolStripMenuItem.Enabled = False Else PasteToolStripMenuItem.Enabled = True
        If IsEmpty(ftphost.Text) Then
            ClearToolStripMenuItem.Enabled = False
            SelectAllToolStripMenuItem.Enabled = False
        Else
            ClearToolStripMenuItem.Enabled = True
            SelectAllToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Profiles()
        If Not IsEmpty(RunProfile) Then
            Dim profile As NimbusProfile = JsonConvert.DeserializeObject(Of NimbusProfile)(File.ReadAllText(RunProfile))
            LoginWithProfile(profile)
        End If
    End Sub

    Private Sub ClearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearToolStripMenuItem.Click
        ftphost.Clear()
    End Sub

    Private Sub CopyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenuItem.Click
        ftphost.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteToolStripMenuItem.Click
        ftphost.Paste()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectAllToolStripMenuItem.Click
        ftphost.SelectAll()
    End Sub

    Private Sub Login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not NimbFTP.IsConnected AndAlso Not NimbFTP.IsAuthenticated Then Environment.Exit(0)
    End Sub
End Class