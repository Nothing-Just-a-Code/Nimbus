Imports System.Runtime.InteropServices
Imports AutoUpdaterDotNET
Imports CredentialManagement.NativeMethods
Imports FluentFTP
Imports Nimbus_FTP_Client.NimbusX
Public Class Settings

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim t As Task = Task.Run(Sub() ReadSettings())
        t.Wait()
    End Sub

    Private Sub ReadSettings()
        Me.TdataType.SelectedIndex = NConfig.TransferDataType
        Select Case NConfig.UploadOverwriteType
            Case FtpRemoteExists.NoCheck
                up_overwritetype.SelectedIndex = 0
                Label2.Text = "Do not check file missing data. It may freeze app if file exist."

            Case FtpRemoteExists.Overwrite
                up_overwritetype.SelectedIndex = 3
                Label2.Text = "It will overwrite the file with the uploaded one."

            Case FtpRemoteExists.Resume
                up_overwritetype.SelectedIndex = 2
                Label2.Text = "It will check it a file exist and has missing data, it will repair it."

            Case FtpRemoteExists.Skip
                up_overwritetype.SelectedIndex = 1
                Label2.Text = "Skip file checking. It may freeze app if file exist."
        End Select

        DelLFile.Checked = NConfig.DeleteLocalFileAfterEdit
        checkupdate.Checked = NConfig.CheckForUpdateAtStartup

        If NConfig.FilesLoadMethod = "advanced" Then
            load_adv.Checked = True
        ElseIf NConfig.FilesLoadMethod = "basic" Then
            load_bsc.Checked = True
        End If

        connection_TO.Text = NConfig.ConnectionTimeoutSeconds
        Dconnection_TO.Text = NConfig.DataConnectionTimeoutSeconds
        read_TO.Text = NConfig.ReadTimeoutSeconds
        maxretry.Value = NConfig.RetryTaskLimit
        Enc_Type.SelectedIndex = NConfig.EncryptionMode

        'Securely read Gemini API Key (If have any)
        If Not IsEmpty(NConfig.GeminiAPI) Then
            GeminiAPItxt.Text = MaskString(NConfig.GeminiAPI)
        End If

        Select Case NConfig.CompareFileType
            Case FtpCompareOption.Auto
                FileCompareType.SelectedIndex = 0
            Case FtpCompareOption.Checksum
                FileCompareType.SelectedIndex = 2
            Case FtpCompareOption.DateModified
                FileCompareType.SelectedIndex = 1
            Case FtpCompareOption.Size
                FileCompareType.SelectedIndex = 3
        End Select

        'download directory
        DownDirtxt.Text = NConfig.DownloadDirectory

        remdir.Checked = NConfig.CreateRemoteDirectory

        DownFileAction.SelectedIndex = NConfig.DownloadOverwriteType
    End Sub

    Private Sub TdataType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TdataType.SelectedIndexChanged
        NConfig.TransferDataType = TdataType.SelectedIndex
        SaveNimbusConfig()
    End Sub

    Private Sub up_overwritetype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles up_overwritetype.SelectedIndexChanged
        Select Case up_overwritetype.SelectedIndex
            Case 0
                NConfig.UploadOverwriteType = FtpRemoteExists.NoCheck
                Label2.Text = "Do not check file missing data. It may freeze app if file exist."

            Case 1
                NConfig.UploadOverwriteType = FtpRemoteExists.Skip
                Label2.Text = "Skip file checking. It may freeze app if file exist."

            Case 2
                NConfig.UploadOverwriteType = FtpRemoteExists.Resume
                Label2.Text = "It will check it a file exist and has missing data, it will repair it."

            Case 3
                NConfig.UploadOverwriteType = FtpRemoteExists.Overwrite
                Label2.Text = "It will overwrite the file with the uploaded one."
        End Select
        SaveNimbusConfig()

    End Sub

    Private Sub DelLFile_CheckedChanged(sender As Object, e As EventArgs) Handles DelLFile.CheckedChanged
        NConfig.DeleteLocalFileAfterEdit = DelLFile.Checked
        SaveNimbusConfig()
    End Sub

    Private Sub checkupdate_CheckedChanged(sender As Object, e As EventArgs) Handles checkupdate.CheckedChanged
        NConfig.CheckForUpdateAtStartup = checkupdate.Checked
        SaveNimbusConfig()

    End Sub

    Private Sub load_adv_CheckedChanged(sender As Object, e As EventArgs) Handles load_adv.CheckedChanged
        If load_adv.Checked = True AndAlso NConfig.FilesLoadMethod = "basic" Then
            NConfig.FilesLoadMethod = "advanced"
            SaveNimbusConfig()
        End If
    End Sub

    Private Sub load_bsc_CheckedChanged(sender As Object, e As EventArgs) Handles load_bsc.CheckedChanged
        If load_bsc.Checked = True AndAlso NConfig.FilesLoadMethod = "advanced" Then
            NConfig.FilesLoadMethod = "basic"
            SaveNimbusConfig()
        End If
    End Sub

    Private Sub TimeoutValues_KeyPress(sender As Object, e As KeyPressEventArgs) Handles connection_TO.KeyPress, Dconnection_TO.KeyPress, read_TO.KeyPress
        ' Allow only digits and backspace
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Settings_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If CInt(connection_TO.Text) <> NConfig.ConnectionTimeoutSeconds Then NConfig.ConnectionTimeoutSeconds = CInt(connection_TO.Text)
        If CInt(Dconnection_TO.Text) <> NConfig.DataConnectionTimeoutSeconds Then NConfig.DataConnectionTimeoutSeconds = CInt(Dconnection_TO.Text)
        If CInt(read_TO.Text) <> NConfig.ReadTimeoutSeconds Then NConfig.ReadTimeoutSeconds = CInt(read_TO.Text)
        If NConfig.RetryTaskLimit <> maxretry.Value Then NConfig.RetryTaskLimit = maxretry.Value
        SaveNimbusConfig()
    End Sub

    Private Sub Enc_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Enc_Type.SelectedIndexChanged
        NConfig.EncryptionMode = Enc_Type.SelectedIndex
        SaveNimbusConfig()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles getapibtn.Click
        Process.Start(New ProcessStartInfo() With {.FileName = "https://aistudio.google.com/app/apikey&ved=2ahUKEwiWxYq349uNAxX3SGcHHSotNqkQFnoECBoQAQ&usg=AOvVaw1WWenMsZaHnCnN4FhYRAe9",
                      .UseShellExecute = True})
    End Sub

    Private Sub GeminiAPItxt_TextChanged(sender As Object, e As EventArgs) Handles GeminiAPItxt.TextChanged
        getapibtn.Enabled = IsEmpty(GeminiAPItxt.Text)
        savegemapi.Enabled = Not IsEmpty(GeminiAPItxt.Text)
    End Sub

    Private Sub FileCompareType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles FileCompareType.SelectedIndexChanged
        Select Case FileCompareType.SelectedIndex
            Case 0
                NConfig.CompareFileType = FtpCompareOption.Auto
                SaveNimbusConfig()
            Case 1
                NConfig.CompareFileType = FtpCompareOption.DateModified
                SaveNimbusConfig()
            Case 2
                NConfig.CompareFileType = FtpCompareOption.Checksum
                SaveNimbusConfig()
            Case 3
                NConfig.CompareFileType = FtpCompareOption.Size
                SaveNimbusConfig()
        End Select
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles savegemapi.Click
        'Gemini Api
        If Not IsEmpty(GeminiAPItxt.Text) Then
            If GeminiAPItxt.Text.Substring(Math.Max(0, GeminiAPItxt.Text.Length - 6)).Equals(NConfig.GeminiAPI.Substring(Math.Max(0, NConfig.GeminiAPI.Length - 6))) Then
                MBox("Error", "It seems the entered API Key and the saved API Key are same.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Else
                NConfig.GeminiAPI = GeminiAPItxt.Text
                SaveNimbusConfig()
                savegemapi.Enabled = False
            End If
        End If

    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        If Not IsEmpty(DownDirtxt.Text) AndAlso IO.Directory.Exists(DownDirtxt.Text) Then FolderBrowserDialog1.SelectedPath = DownDirtxt.Text
        If FolderBrowserDialog1.ShowDialog(Me) = DialogResult.OK Then
            DownDirtxt.Text = FolderBrowserDialog1.SelectedPath
            NConfig.DownloadDirectory = FolderBrowserDialog1.SelectedPath
            SaveNimbusConfig()
        End If

    End Sub

    Private Sub remdir_CheckedChanged(sender As Object, e As EventArgs) Handles remdir.CheckedChanged
        NConfig.CreateRemoteDirectory = remdir.Checked
        SaveNimbusConfig()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DownFileAction.SelectedIndexChanged
        NConfig.DownloadOverwriteType = DownFileAction.SelectedIndex
    End Sub
End Class