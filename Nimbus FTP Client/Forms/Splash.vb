Public Class Splash
    Private ProfilePath As String
    Private Async Sub Splash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        Me.Label1.Text = "Loading Configurations..."
        Await NimbusX.Init()
        If NimbusX.NConfig.CheckForUpdateAtStartup Then
            Me.Label1.Text = "Checking for update..."
            Dim UpdateAvailable = Await NimbusX.IsNewVersionAvailable()
            If UpdateAvailable.NewVersionAvailable = True Then
                Dim Dlg As New Ookii.Dialogs.WinForms.TaskDialog() With {
                    .AllowDialogCancellation = True,
                    .ButtonStyle = Ookii.Dialogs.WinForms.TaskDialogButtonStyle.Standard,
                    .CenterParent = True,
                    .CollapsedControlText = "Show Changelogs",
                    .Content = "A newer version of Nimbus FTP Client is available to download.",
                    .CustomMainIcon = Me.Icon,
                    .ExpandedControlText = "Hide Changelogs",
                    .ExpandedInformation = String.Join(Environment.NewLine, UpdateAvailable.ChangeLogs),
                    .Footer = $"New Version: {UpdateAvailable.NewVersion}",
                    .FooterIcon = Ookii.Dialogs.WinForms.TaskDialogIcon.Information,
                .MainInstruction = "Update Available",
                    .MinimizeBox = False,
                    .ProgressBarStyle = Ookii.Dialogs.WinForms.ProgressBarStyle.None,
                    .WindowIcon = Me.Icon,
                    .WindowTitle = "Nimbus FTP Client Update"}
                Dlg.Buttons.Add(New Ookii.Dialogs.WinForms.TaskDialogButton("Update Now"))
                Dlg.Buttons.Add(New Ookii.Dialogs.WinForms.TaskDialogButton("Cancel"))
                AddHandler Dlg.ButtonClicked, New EventHandler(Of Ookii.Dialogs.WinForms.TaskDialogItemClickedEventArgs)(AddressOf OnButtonsClick)
                Dim button = Dlg.ShowDialog(Me)
            End If
        End If
        If NimbusX.IsEmpty(ProfilePath) Then
            RunApp()
        Else
            RunApp(ProfilePath)
        End If
    End Sub

    Private Sub OnButtonsClick(ByVal sender As Object, ByVal e As Ookii.Dialogs.WinForms.TaskDialogItemClickedEventArgs)
        Dim Dlg As Ookii.Dialogs.WinForms.TaskDialog = CType(sender, Ookii.Dialogs.WinForms.TaskDialog)
        Select Case e.Item.Text
            Case "Update Now"
                Process.Start(New ProcessStartInfo() With {.FileName = "https://github.com/Nothing-Just-a-Code/Nimbus/releases", .UseShellExecute = True})
                Dlg.Dispose()
            Case "Cancel"
                Dlg.Dispose()
        End Select
    End Sub

    Private Sub RunApp(Optional ByVal PPath As String = "")
        If NimbusX.IsEmpty(PPath) Then
            Dim LF As New Login()
            LF.Show()
            Me.Hide()
        Else
            Dim LF As New Login(PPath)
            LF.Show()
            Me.Hide()
        End If
    End Sub
    Sub New()
        InitializeComponent()
        If Environment.GetCommandLineArgs().Count = 2 AndAlso Environment.GetCommandLineArgs(1).EndsWith(".nbs") Then
            ProfilePath = Environment.GetCommandLineArgs(1)
        End If
    End Sub
End Class