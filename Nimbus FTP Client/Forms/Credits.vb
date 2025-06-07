Public Class Credits
    Private Sub Credits_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        OpenLink("https://github.com/gunpal5/Google_GenerativeAI")
    End Sub

    Private Sub OpenLink(ByVal link As String)
        Process.Start(New ProcessStartInfo() With {.FileName = link, .UseShellExecute = True})
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        OpenLink("https://github.com/contre/Windows-API-Code-Pack-1.1")
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        OpenLink("https://github.com/JamesNK/Newtonsoft.Json")
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        OpenLink("https://github.com/ookii-dialogs/ookii-dialogs-winforms")
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        OpenLink("https://github.com/desjarlais/Scintilla.NET")
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        OpenLink("https://github.com/xiaoyuvax/FastColoredTextBox/")
    End Sub

    Private Sub LinkLabel7_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        OpenLink("https://github.com/robinrodricks/FluentFTP")
    End Sub

    Private Sub LinkLabel8_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        OpenLink("https://www.flaticon.com")
    End Sub
End Class