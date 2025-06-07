Imports Nimbus_FTP_Client.NimbusX
Public Class Gemini
    Private aiclass As GeminiAIService

    Private Async Sub txtInput_KeyDown(sender As Object, e As KeyEventArgs) Handles txtInput.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            Dim req = txtInput.Text
            txtInput.Clear()
            AddMessageBubble(req, isIncoming:=False)
            Dim response = Await aiclass.GenerateScriptAsync(req)
            AddMessageBubble("Gemini AI: " & response, isIncoming:=True)
        End If
    End Sub

    Private Sub AddMessageBubble(message As String, isIncoming As Boolean)
        Dim bubble = New MessageBubble(message, isIncoming)
        bubble.MaximumSize = New Size(flowMessages.Width - 40, 0) ' prevent overflow
        flowMessages.Controls.Add(bubble)
        flowMessages.ScrollControlIntoView(bubble)
    End Sub

    Private Sub flowMessages_SizeChanged(sender As Object, e As EventArgs) Handles flowMessages.SizeChanged
        For Each ctrl As Control In flowMessages.Controls
            ctrl.Width = flowMessages.ClientSize.Width - 20
        Next
    End Sub

    Private Sub Gemini_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        aiclass = New GeminiAIService(NConfig.GeminiAPI)
        SendHello()
    End Sub
    Private Async Sub SendHello()
        Dim response = Await aiclass.GenerateScriptAsync("hello")
        AddMessageBubble("Gemini AI: " & response, isIncoming:=True)
    End Sub

End Class