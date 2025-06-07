Imports System.Text.RegularExpressions
Imports GenerativeAI
Imports Nimbus_FTP_Client.NimbusX
Public Class CodeGenerator

    Private GAi As GeminiAIService = New GeminiAIService(NConfig.GeminiAPI)

    Private Sub CodeGenerator_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Async Sub codecmd_KeyDown(sender As Object, e As KeyEventArgs) Handles codecmd.KeyDown
        If e.KeyCode = Keys.Enter AndAlso Not IsEmpty(Me.codecmd.Text) Then
            e.Handled = True
            e.SuppressKeyPress = True
            FCTB.Enabled = False
            codecmd.Enabled = False
            Dim response = Await GAi.GenerateScriptAsync(Me.codecmd.Text)
            codecmd.Enabled = True
            FCTB.Enabled = True
            GetCode(response)
        End If
    End Sub

    Private Sub GetCode(ByVal resp As String)
        Dim results = ExtractCodeAndLanguage(response:=resp)
        FCTB.SetLanguage(GetFCTBLanguage(results.Language))
        FCTB.Text = results.Code
    End Sub

    Private Function ExtractCodeAndLanguage(response As String) As (Language As String, Code As String)
        ' Matches: ```language\n<code>\n```
        Dim pattern As String = "```(\w+)?\s*(.*?)```"
        Dim match As Match = Regex.Match(response, pattern, RegexOptions.Singleline)

        If match.Success Then
            Dim lang As String = match.Groups(1).Value.Trim().ToLower()
            Dim code As String = match.Groups(2).Value.Trim()
            Return (lang, code)
        End If

        Return ("", "")
    End Function

    Private Function GetFCTBLanguage(lang As String) As FastColoredTextBoxNS.Text.Language
        Select Case lang.ToLower()
            Case "vb", "vbnet" : Return FastColoredTextBoxNS.Text.Language.VB
            Case "csharp", "cs", "c#" : Return FastColoredTextBoxNS.Text.Language.CSharp
            Case "js", "javascript" : Return FastColoredTextBoxNS.Text.Language.JS
            Case "html" : Return FastColoredTextBoxNS.Text.Language.HTML
            Case "sql" : Return FastColoredTextBoxNS.Text.Language.SQL
            Case "php" : Return FastColoredTextBoxNS.Text.Language.PHP
            Case "json" : Return FastColoredTextBoxNS.Text.Language.JSON
            Case "sql" : Return FastColoredTextBoxNS.Text.Language.SQL
            Case "xml" : Return FastColoredTextBoxNS.Text.Language.XML
            Case "lua" : Return FastColoredTextBoxNS.Text.Language.Lua
            Case Else : Return FastColoredTextBoxNS.Text.Language.Custom
        End Select
    End Function
End Class