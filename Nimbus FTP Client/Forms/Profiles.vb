Imports Newtonsoft.Json
Imports System.IO
Imports Nimbus_FTP_Client.NimbusX
Public Class Profiles
    Private Sub Profiles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        For Each item As NimbusProfile In NimbusX.NimbusProfiles
            proflist.Items.Add(item)
        Next
    End Sub


    Private Sub UsernameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsernameToolStripMenuItem.Click
        If GetSelectedItem() IsNot Nothing Then
            Clipboard.SetText(GetSelectedItem().FTPUsername)
        End If
    End Sub

    Private Function GetSelectedItem() As NimbusProfile
        If proflist.SelectedItem Is Nothing Then Return Nothing
        Return CType(proflist.SelectedItem, NimbusProfile)
    End Function

    Private Sub HostToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HostToolStripMenuItem.Click
        If GetSelectedItem() IsNot Nothing Then
            Clipboard.SetText(GetSelectedItem().FTPHostname)
        End If
    End Sub

    Private Async Sub UsernameToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UsernameToolStripMenuItem1.Click
        Dim prof As NimbusProfile = GetSelectedItem()
        If prof IsNot Nothing Then
            Dim Dlg As New Ookii.Dialogs.WinForms.InputDialog() With {
                .Content = "Enter your new Username for your FTP account.",
                .MainInstruction = "FTP Username",
                .Multiline = False,
                .UsePasswordMasking = False,
                .WindowTitle = "Change Username"}
            If Dlg.ShowDialog(Me) = DialogResult.OK Then
                If prof.FTPUsername.Equals(Dlg.Input, StringComparison.OrdinalIgnoreCase) Then
                    MBox("No changes Made", "You cannot save your old username as your new username.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Else
                    If File.Exists(Path.Combine(DataDir, $"{prof.FTPHostname}@{prof.FTPUsername}.nbs")) Then File.Delete(Path.Combine(DataDir, $"{prof.FTPHostname}@{prof.FTPUsername}.nbs"))
                    prof.FTPUsername = Dlg.Input

                    'Save the new profile
                    Await File.WriteAllTextAsync(Path.Combine(DataDir, $"{prof.FTPHostname}@{prof.FTPUsername}.nbs"), JsonConvert.SerializeObject(prof, Formatting.Indented), System.Text.Encoding.UTF8)
                        MBox("Changes Saved", "Your username has been changed in your Nimbus Profile. You need to restart application to apply changes.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                End If
        End If
    End Sub

    Private Async Sub HostToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HostToolStripMenuItem1.Click
        Dim prof As NimbusProfile = GetSelectedItem()
        If prof IsNot Nothing Then
            Dim Dlg As New Ookii.Dialogs.WinForms.InputDialog() With {
                .Content = "Enter your new Hostname for your FTP account.",
                .MainInstruction = "FTP Hostname",
                .Multiline = False,
                .UsePasswordMasking = False,
                .WindowTitle = "Change Hostname"}
            If Dlg.ShowDialog(Me) = DialogResult.OK Then
                If prof.FTPHostname.Equals(Dlg.Input, StringComparison.OrdinalIgnoreCase) Then
                    MBox("No changes Made", "You cannot save your old hostname as your new hostname.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                Else
                    If File.Exists(Path.Combine(DataDir, $"{prof.FTPHostname}@{prof.FTPUsername}.nbs")) Then File.Delete(Path.Combine(DataDir, $"{prof.FTPHostname}@{prof.FTPUsername}.nbs"))
                    prof.FTPHostname = Dlg.Input
                    Await File.WriteAllTextAsync(Path.Combine(DataDir, $"{prof.FTPHostname}@{prof.FTPUsername}.nbs"), JsonConvert.SerializeObject(prof, Formatting.Indented), System.Text.Encoding.UTF8)
                    MBox("Changes Saved", "Your hostname has been changed in your Nimbus Profile. You need to restart application to apply changes.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If GetSelectedItem() IsNot Nothing AndAlso MBox("Deleting Nimbus Profile", $"You will lose your Nimbus Profile and all saved data. That action cannot be undone.{Environment.NewLine}Do you really want to continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            DeleteProfile(GetSelectedItem())
            proflist.Items.Remove(proflist.SelectedItem)
        End If
    End Sub
End Class