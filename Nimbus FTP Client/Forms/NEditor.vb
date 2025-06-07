Imports ScintillaNET
Imports Nimbus_FTP_Client.NimbusX

Public Class NEditor
    Private FileITem As FTPFile
    Private Filename As String

    Sub New(ByVal _tempfile As String, ByVal fItem As FTPFile)
        InitializeComponent()
        Filename = _tempfile
        FileITem = fItem
    End Sub
    Sub New()
        InitializeComponent()
    End Sub


    Private Async Sub NEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetupConfig()
        If FileITem IsNot Nothing AndAlso Not IsEmpty(FileITem.FullPath) Then SetLexilla(file:=FileITem.FullPath)
        If Not IsEmpty(Filename) Then Me.codetxt.Text = Await IO.File.ReadAllTextAsync(Filename)
    End Sub

    Private Sub Scintilla1_TextChanged(sender As Object, e As EventArgs) Handles codetxt.TextChanged
        If ShowLineNumbersToolStripMenuItem.Checked = True Then UpdateLineNumberMarginWidth()
    End Sub

    Private Sub UpdateLineNumberMarginWidth()
        ' Get max line number digit length
        Dim maxLineNumLength As Integer = Math.Max(1, codetxt.Lines.Count.ToString().Length)

        ' Estimate character width based on current font
        Dim charSize As Size = TextRenderer.MeasureText("1", codetxt.Font)
        Dim charWidth As Integer = charSize.Width - 4

        ' Set margin width with padding
        Dim widthz As Integer = (maxLineNumLength * charWidth)
        codetxt.Margins(0).Width = widthz
    End Sub

#Region "LEXILLA"
    Private Sub SetLexilla(ByVal file As String)
        Dim fileExtension As String = IO.Path.GetExtension(file)
        codetxt.StyleResetDefault()
        codetxt.Styles(ScintillaNET.Style.Default).BackColor = Color.White
        codetxt.StyleClearAll()

        Select Case IO.Path.GetExtension(file).ToLower()
            Case ".json"
                SetupJSON()
            Case ".html", ".htm", ".xhtml", ".phtml", "cshtml"
                SetupHTML()
            Case ".php"
                SetupPHP()
            Case ".css"
                SetupCSS()
            Case ".js"
                SetupJavaScript()
            Case ".xml"
                SetupXML()
            Case ".ini"
                SetupINI()
            Case ".vbscript", "vbs"
                SetupVBScript()
            Case ".vb"
                SetupVB()
            Case ".py", ".pyw"
                SetupPython()
            Case ".rb"
                SetupRuby()

        End Select
    End Sub


    Sub SetupVB()
        With codetxt
            .LexerName = "vb"
            .SetKeywords(0, "addressof alias and as attribute base begin binary boolean byref byte byval call case cdbl cint clng compare const csng cstr currency date decimal declare defbool defbyte defcur defdate defdbl defdec defint deflng defobj defsng defstr defvar dim do double each else elseif empty end enum eqv erase error event exit explicit false for friend function get global gosub goto if imp implements in input integer is len let lib like load lock long loop lset me mid midb mod new next not nothing null object on option optional or paramarray preserve print private property public raiseevent randomize redim rem resume return rset seek select set single static step stop string sub text then time to true type typeof unload until variant wend while with withevents xor")
            .SetKeywords(1, "appactivate beep chdir chdrive close filecopy get input kill line unlock mkdir name open print put reset rmdir savepicture savesetting seek sendkeys setattr width write")
            .SetKeywords(2, "addhandler andalso ansi assembly auto catch cbool cbyte cchar cdate cdec char class cobj continue csbyte cshort ctype cuint culng cushort custom default delegate directcast endif externalsource finally gettype handles imports inherits interface isfalse isnot istrue module mustinherit mustoverride my mybase myclass namespace narrowing notinheritable notoverridable of off operator orelse overloads overridable overrides partial protected readonly region removehandler sbyte shadows shared short strict structure synclock throw try trycast uinteger ulong unicode ushort using when widening writeonly")

            .Styles(ScintillaNET.Style.Vb.Default).ForeColor = Color.Black
            .Styles(ScintillaNET.Style.Vb.Comment).ForeColor = Color.Green
            .Styles(ScintillaNET.Style.Vb.Number).ForeColor = Color.DarkCyan
            .Styles(ScintillaNET.Style.Vb.Keyword).ForeColor = Color.Blue
            .Styles(ScintillaNET.Style.Vb.String).ForeColor = Color.Brown
            .Styles(ScintillaNET.Style.Vb.Preprocessor).ForeColor = Color.Purple
            .Styles(ScintillaNET.Style.Vb.Operator).ForeColor = Color.DarkRed
            .Styles(ScintillaNET.Style.Vb.Identifier).ForeColor = Color.Black
            .Styles(ScintillaNET.Style.Vb.Date).ForeColor = Color.DarkSlateBlue
            .Styles(ScintillaNET.Style.Vb.StringEol).BackColor = Color.LightPink
        End With
    End Sub

    Sub SetupJSON()
        With codetxt
            .LexerName = "json"
            .SetKeywords(0, "true false null")
            .Styles(ScintillaNET.Style.Json.Default).ForeColor = Color.Black
            .Styles(ScintillaNET.Style.Json.Number).ForeColor = Color.DarkOrange
            .Styles(ScintillaNET.Style.Json.String).ForeColor = Color.Brown
            .Styles(ScintillaNET.Style.Json.PropertyName).ForeColor = Color.Blue
            .Styles(ScintillaNET.Style.Json.Operator).ForeColor = Color.DarkRed
            .Styles(ScintillaNET.Style.Json.BlockComment).ForeColor = Color.Green
            .Styles(ScintillaNET.Style.Json.Keyword).ForeColor = Color.Purple ' If supported
        End With
    End Sub

    Public Function HexToColor(hex As String) As Color
        ' Remove leading # if present
        If hex.StartsWith("#") Then
            hex = hex.Substring(1)
        End If

        ' Parse R, G, B
        Dim r As Integer = Convert.ToInt32(hex.Substring(0, 2), 16)
        Dim g As Integer = Convert.ToInt32(hex.Substring(2, 2), 16)
        Dim b As Integer = Convert.ToInt32(hex.Substring(4, 2), 16)

        Return Color.FromArgb(r, g, b)
    End Function

    Private Function GetMaxLineNumberWidth() As Integer
        Dim lineCount As Integer = Math.Max(codetxt.Lines.Count, 1)
        Dim maxDigits As Integer = lineCount.ToString().Length

        ' Safely construct a Font object using style settings
        Dim styleFontName As String = codetxt.Styles(ScintillaNET.Style.LineNumber).Font
        Dim styleFontSize As Integer = codetxt.Styles(ScintillaNET.Style.LineNumber).Size
        If String.IsNullOrWhiteSpace(styleFontName) Then
            styleFontName = Me.Font.Name
        End If
        If styleFontSize <= 0 Then
            styleFontSize = 10
        End If

        Using font As New Font(styleFontName, styleFontSize)
            Dim size As Size = TextRenderer.MeasureText(New String("9"c, maxDigits), font)
            Return size.Width + 10
        End Using
    End Function

    Sub SetupHTML()
        With codetxt
            .LexerName = "html"
            .SetKeywords(0, "html head title meta link script style body div span a img ul ol li h1 h2 h3 h4 h5 h6 p br hr table tr td th form input button label select option textarea doctype")

            .Styles(ScintillaNET.Style.Html.Tag).ForeColor = Color.Blue
            .Styles(ScintillaNET.Style.Html.Attribute).ForeColor = Color.Red
            .Styles(ScintillaNET.Style.Html.DoubleString).ForeColor = Color.Brown
            .Styles(ScintillaNET.Style.Html.SingleString).ForeColor = Color.Brown
            .Styles(ScintillaNET.Style.Html.Comment).ForeColor = Color.Green
            .Styles(ScintillaNET.Style.Default).ForeColor = Color.Black
            .Styles(ScintillaNET.Style.Default).BackColor = Color.White
        End With
    End Sub

    Sub SetupCSS()
        With codetxt
            .LexerName = "css"
            .SetKeywords(0, "color background border margin padding font display position float clear width height content visibility overflow z-index")

            .Styles(ScintillaNET.Style.Css.Tag).ForeColor = Color.Blue
            .Styles(ScintillaNET.Style.Css.Class).ForeColor = Color.DarkCyan
            .Styles(ScintillaNET.Style.Css.PseudoClass).ForeColor = Color.DarkMagenta
            .Styles(ScintillaNET.Style.Css.UnknownPseudoClass).ForeColor = Color.Red
            .Styles(ScintillaNET.Style.Css.Identifier).ForeColor = Color.Maroon
            .Styles(ScintillaNET.Style.Css.UnknownIdentifier).ForeColor = Color.Red
            .Styles(ScintillaNET.Style.Css.Comment).ForeColor = Color.Green
        End With
    End Sub

    Sub SetupJavaScript()
        With codetxt
            .LexerName = "javascript"
            .SetKeywords(0, "var let const function if else for while do switch case break return true false null undefined new try catch throw typeof instanceof this")

            .Styles(ScintillaNET.Style.JavaScript.Word).ForeColor = Color.Blue
            .Styles(ScintillaNET.Style.JavaScript.Comment).ForeColor = Color.Green
            .Styles(ScintillaNET.Style.JavaScript.CommentLine).ForeColor = Color.Green
            .Styles(ScintillaNET.Style.JavaScript.Number).ForeColor = Color.OrangeRed
            .Styles(ScintillaNET.Style.JavaScript.SingleString).ForeColor = Color.Brown
        End With
    End Sub

    Sub SetupXML()
        With codetxt
            .LexerName = "xml"
            .Styles(ScintillaNET.Style.Xml.Tag).ForeColor = Color.Blue
            .Styles(ScintillaNET.Style.Xml.Attribute).ForeColor = Color.Red
            .Styles(ScintillaNET.Style.Xml.DoubleString).ForeColor = Color.Brown
            .Styles(ScintillaNET.Style.Xml.SingleString).ForeColor = Color.Brown
            .Styles(ScintillaNET.Style.Xml.Comment).ForeColor = Color.Green
        End With
    End Sub

    Sub SetupINI()
        With codetxt
            .LexerName = "prop"
            .Styles(ScintillaNET.Style.Properties.Default).ForeColor = Color.Black
            .Styles(ScintillaNET.Style.Properties.Section).ForeColor = Color.Blue
            .Styles(ScintillaNET.Style.Properties.Assignment).ForeColor = Color.Red
            .Styles(ScintillaNET.Style.Properties.Comment).ForeColor = Color.Green
        End With
    End Sub

    Sub SetupPHP()
        With codetxt
            .LexerName = "phpscript"
            .SetKeywords(0, "echo print if else elseif foreach for while do break continue return function class public private protected static global true false null")
            .Styles(ScintillaNET.Style.PhpScript.Default).ForeColor = Color.Black
            .Styles(ScintillaNET.Style.PhpScript.Word).ForeColor = Color.Blue
            .Styles(ScintillaNET.Style.PhpScript.Comment).ForeColor = Color.Green
            .Styles(ScintillaNET.Style.PhpScript.Variable).ForeColor = Color.Purple
            .Styles(ScintillaNET.Style.PhpScript.SimpleString).ForeColor = Color.Brown
        End With
    End Sub

    Sub SetupVBScript()
        With codetxt
            .LexerName = "vb"
            .SetKeywords(0, "dim set let if else elseif end function sub call true false not and or loop next do while select case then")
            .Styles(ScintillaNET.Style.Vb.Comment).ForeColor = Color.Green
            .Styles(ScintillaNET.Style.Vb.Keyword).ForeColor = Color.Blue
            .Styles(ScintillaNET.Style.Vb.String).ForeColor = Color.Brown
        End With
    End Sub

    Sub SetupPython()
        With codetxt
            .LexerName = "python"
            .SetKeywords(0, "def return if else elif for while import from as class try except finally with lambda yield global nonlocal True False None")
            .Styles(ScintillaNET.Style.Python.DefName).ForeColor = Color.DarkBlue
            .Styles(ScintillaNET.Style.Python.Word).ForeColor = Color.Blue
            .Styles(ScintillaNET.Style.Python.CommentLine).ForeColor = Color.Green
            .Styles(ScintillaNET.Style.Python.String).ForeColor = Color.Brown
        End With
    End Sub

    Sub SetupRuby()
        With codetxt
            .LexerName = "ruby"
            .SetKeywords(0, "def end if else elsif unless while until do class module begin rescue ensure yield true false nil self super return")
            .Styles(ScintillaNET.Style.Ruby.ClassName).ForeColor = Color.DarkCyan
            .Styles(ScintillaNET.Style.Ruby.DefName).ForeColor = Color.DarkBlue
            .Styles(ScintillaNET.Style.Ruby.Word).ForeColor = Color.Blue
            .Styles(ScintillaNET.Style.Ruby.CommentLine).ForeColor = Color.Green
            .Styles(ScintillaNET.Style.Ruby.String).ForeColor = Color.Brown
        End With
    End Sub

    Sub SetupCSHTML()
        ' Treat CSHTML as HTML + Razor with embedded C# -- usually custom highlighting is needed.
        SetupHTML()
        ' Additional C# lexer setup would go here if using embedded syntax parsing.
    End Sub
#End Region

    Private Sub WordsWrapToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles WordsWrapToolStripMenuItem.CheckedChanged
        If WordsWrapToolStripMenuItem.Checked = True Then
            codetxt.WrapMode = WrapMode.Word
        Else
            codetxt.WrapMode = WrapMode.None
        End If
        NConfig.WordsWrap = WordsWrapToolStripMenuItem.Checked
        SaveNimbusConfig()
    End Sub

    Private Sub SetupConfig()
        WordsWrapToolStripMenuItem.Checked = NConfig.WordsWrap
        ShowLineNumbersToolStripMenuItem.Checked = NConfig.ShowLineNumbers
    End Sub
    Private Sub ShowLineNumbersToolStripMenuItem_CheckedChanged(sender As Object, e As EventArgs) Handles ShowLineNumbersToolStripMenuItem.CheckedChanged
        If ShowLineNumbersToolStripMenuItem.Checked = True Then
            codetxt.Margins(0).Type = ScintillaNET.MarginType.Number
            codetxt.Margins(0).Sensitive = False
            UpdateLineNumberMarginWidth()
        Else
            codetxt.Margins(0).Width = 0
        End If
        NConfig.ShowLineNumbers = ShowLineNumbersToolStripMenuItem.Checked
        SaveNimbusConfig()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Async Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        codetxt.Enabled = False
        Await WriteToFile()
        Dim result = Await CType(Me.Owner, MainForm).SaveStreamCall(Filename, Me.FileITem.FullPath)
        If result = True Then
            CType(Me.Owner, MainForm).ShowBalloon("File Saved", "File has been edited and saved.", ToolTipIcon.Info)
            Me.Close()
        Else
            CType(Me.Owner, MainForm).ShowBalloon("Failed", "Cannot save the edited file. Please try again.", ToolTipIcon.Error)
            codetxt.Enabled = True
        End If
    End Sub

    Private Async Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        If SFD.ShowDialog(Me) = DialogResult.OK Then
            Using stm As New IO.StreamWriter(SFD.FileName, False, System.Text.Encoding.UTF8)
                Await stm.WriteAsync(codetxt.Text)
                Await stm.FlushAsync()
            End Using
        End If
    End Sub

    Private Sub NEditor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Async Function WriteToFile() As Task
        Using stm As New IO.StreamWriter(Filename, False, System.Text.Encoding.UTF8)
            Await stm.WriteAsync(codetxt.Text)
            Await stm.FlushAsync()
        End Using
    End Function

    Private Sub VBNETToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VBNETToolStripMenuItem.Click
        SetLexilla(".vb")
    End Sub

    Private Sub PHPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PHPToolStripMenuItem.Click
        SetLexilla(".php")
    End Sub

    Private Sub HTLPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HTLPToolStripMenuItem.Click
        SetLexilla(".html")
    End Sub

    Private Sub JSONToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JSONToolStripMenuItem.Click
        SetLexilla(".json")
    End Sub

    Private Sub CSSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CSSToolStripMenuItem.Click
        SetLexilla(".css")
    End Sub

    Private Sub JSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JSToolStripMenuItem.Click
        SetLexilla(".js")
    End Sub

    Private Sub XMLToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles XMLToolStripMenuItem.Click
        SetLexilla(".xml")
    End Sub

    Private Sub PythonToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PythonToolStripMenuItem.Click
        SetLexilla(".py")
    End Sub

    Private Sub RubyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RubyToolStripMenuItem.Click
        SetLexilla(".rb")
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        If IsEmpty(NConfig.GeminiAPI) Then
            MBox("AI is Disabled", "You have not entered your Gemini AI API Key to enable the AI services.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            CodeGenerator.Show()
        End If

    End Sub

    Private Sub ChatAssistantToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChatAssistantToolStripMenuItem.Click
        If IsEmpty(NConfig.GeminiAPI) Then
            MBox("AI is Disabled", "You have not entered your Gemini AI API Key to enable the AI services.", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Gemini.Show()
        End If
    End Sub
End Class