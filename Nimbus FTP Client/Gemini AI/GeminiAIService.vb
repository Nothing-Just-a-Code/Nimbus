Imports GenerativeAI
Imports GenerativeAI.Clients


Public Class GeminiAIService
    Private ReadOnly GemAI As GoogleAi
    Public model As GenerativeModel

    Public Sub New(apiKey As String)
        GemAI = New GoogleAi(apiKey:=apiKey)
        model = GemAI.CreateGenerativeModel("models/gemini-1.5-flash")
    End Sub

    Public Async Function GenerateScriptAsync(userRequest As String) As Task(Of String)
        Dim resp = Await model.GenerateContentAsync(userRequest)
        Return resp.Text
    End Function
End Class
