<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NEditor))
        MenuStrip1 = New MenuStrip()
        ToolStripMenuItem1 = New ToolStripMenuItem()
        SaveToolStripMenuItem = New ToolStripMenuItem()
        SaveAsToolStripMenuItem = New ToolStripMenuItem()
        CloseToolStripMenuItem = New ToolStripMenuItem()
        OpenAIToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem3 = New ToolStripMenuItem()
        ChatAssistantToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem2 = New ToolStripMenuItem()
        VBNETToolStripMenuItem = New ToolStripMenuItem()
        PHPToolStripMenuItem = New ToolStripMenuItem()
        HTLPToolStripMenuItem = New ToolStripMenuItem()
        JSONToolStripMenuItem = New ToolStripMenuItem()
        CSSToolStripMenuItem = New ToolStripMenuItem()
        JSToolStripMenuItem = New ToolStripMenuItem()
        XMLToolStripMenuItem = New ToolStripMenuItem()
        PythonToolStripMenuItem = New ToolStripMenuItem()
        RubyToolStripMenuItem = New ToolStripMenuItem()
        OptionsToolStripMenuItem = New ToolStripMenuItem()
        WordsWrapToolStripMenuItem = New ToolStripMenuItem()
        ShowLineNumbersToolStripMenuItem = New ToolStripMenuItem()
        codetxt = New ScintillaNET.Scintilla()
        SFD = New SaveFileDialog()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.BackColor = Color.White
        MenuStrip1.Items.AddRange(New ToolStripItem() {ToolStripMenuItem1, OpenAIToolStripMenuItem, ToolStripMenuItem2, OptionsToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(853, 24)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.DropDownItems.AddRange(New ToolStripItem() {SaveToolStripMenuItem, SaveAsToolStripMenuItem, CloseToolStripMenuItem})
        ToolStripMenuItem1.Image = My.Resources.NimbusResources.document_1_
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(53, 20)
        ToolStripMenuItem1.Text = "File"
        ' 
        ' SaveToolStripMenuItem
        ' 
        SaveToolStripMenuItem.Image = CType(resources.GetObject("SaveToolStripMenuItem.Image"), Image)
        SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        SaveToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.S
        SaveToolStripMenuItem.Size = New Size(177, 22)
        SaveToolStripMenuItem.Text = "Save"
        ' 
        ' SaveAsToolStripMenuItem
        ' 
        SaveAsToolStripMenuItem.Image = CType(resources.GetObject("SaveAsToolStripMenuItem.Image"), Image)
        SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem"
        SaveAsToolStripMenuItem.ShortcutKeys = Keys.Control Or Keys.Alt Or Keys.S
        SaveAsToolStripMenuItem.Size = New Size(177, 22)
        SaveAsToolStripMenuItem.Text = "Save As"
        ' 
        ' CloseToolStripMenuItem
        ' 
        CloseToolStripMenuItem.Image = CType(resources.GetObject("CloseToolStripMenuItem.Image"), Image)
        CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        CloseToolStripMenuItem.Size = New Size(177, 22)
        CloseToolStripMenuItem.Text = "Close"
        ' 
        ' OpenAIToolStripMenuItem
        ' 
        OpenAIToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ToolStripMenuItem3, ChatAssistantToolStripMenuItem})
        OpenAIToolStripMenuItem.Image = CType(resources.GetObject("OpenAIToolStripMenuItem.Image"), Image)
        OpenAIToolStripMenuItem.Name = "OpenAIToolStripMenuItem"
        OpenAIToolStripMenuItem.Size = New Size(87, 20)
        OpenAIToolStripMenuItem.Text = "Gemini AI"
        ' 
        ' ToolStripMenuItem3
        ' 
        ToolStripMenuItem3.Image = CType(resources.GetObject("ToolStripMenuItem3.Image"), Image)
        ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        ToolStripMenuItem3.Size = New Size(157, 22)
        ToolStripMenuItem3.Text = "Code Generator"
        ' 
        ' ChatAssistantToolStripMenuItem
        ' 
        ChatAssistantToolStripMenuItem.Image = CType(resources.GetObject("ChatAssistantToolStripMenuItem.Image"), Image)
        ChatAssistantToolStripMenuItem.Name = "ChatAssistantToolStripMenuItem"
        ChatAssistantToolStripMenuItem.Size = New Size(157, 22)
        ChatAssistantToolStripMenuItem.Text = "Chat Assistant"
        ' 
        ' ToolStripMenuItem2
        ' 
        ToolStripMenuItem2.DropDownItems.AddRange(New ToolStripItem() {VBNETToolStripMenuItem, PHPToolStripMenuItem, HTLPToolStripMenuItem, JSONToolStripMenuItem, CSSToolStripMenuItem, JSToolStripMenuItem, XMLToolStripMenuItem, PythonToolStripMenuItem, RubyToolStripMenuItem})
        ToolStripMenuItem2.Image = CType(resources.GetObject("ToolStripMenuItem2.Image"), Image)
        ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        ToolStripMenuItem2.Size = New Size(87, 20)
        ToolStripMenuItem2.Text = "Language"
        ' 
        ' VBNETToolStripMenuItem
        ' 
        VBNETToolStripMenuItem.Image = CType(resources.GetObject("VBNETToolStripMenuItem.Image"), Image)
        VBNETToolStripMenuItem.Name = "VBNETToolStripMenuItem"
        VBNETToolStripMenuItem.Size = New Size(113, 22)
        VBNETToolStripMenuItem.Text = "VB.NET"
        ' 
        ' PHPToolStripMenuItem
        ' 
        PHPToolStripMenuItem.Image = CType(resources.GetObject("PHPToolStripMenuItem.Image"), Image)
        PHPToolStripMenuItem.Name = "PHPToolStripMenuItem"
        PHPToolStripMenuItem.Size = New Size(113, 22)
        PHPToolStripMenuItem.Text = "PHP"
        ' 
        ' HTLPToolStripMenuItem
        ' 
        HTLPToolStripMenuItem.Image = CType(resources.GetObject("HTLPToolStripMenuItem.Image"), Image)
        HTLPToolStripMenuItem.Name = "HTLPToolStripMenuItem"
        HTLPToolStripMenuItem.Size = New Size(113, 22)
        HTLPToolStripMenuItem.Text = "HTML"
        ' 
        ' JSONToolStripMenuItem
        ' 
        JSONToolStripMenuItem.Image = CType(resources.GetObject("JSONToolStripMenuItem.Image"), Image)
        JSONToolStripMenuItem.Name = "JSONToolStripMenuItem"
        JSONToolStripMenuItem.Size = New Size(113, 22)
        JSONToolStripMenuItem.Text = "JSON"
        ' 
        ' CSSToolStripMenuItem
        ' 
        CSSToolStripMenuItem.Image = CType(resources.GetObject("CSSToolStripMenuItem.Image"), Image)
        CSSToolStripMenuItem.Name = "CSSToolStripMenuItem"
        CSSToolStripMenuItem.Size = New Size(113, 22)
        CSSToolStripMenuItem.Text = "CSS"
        ' 
        ' JSToolStripMenuItem
        ' 
        JSToolStripMenuItem.Image = CType(resources.GetObject("JSToolStripMenuItem.Image"), Image)
        JSToolStripMenuItem.Name = "JSToolStripMenuItem"
        JSToolStripMenuItem.Size = New Size(113, 22)
        JSToolStripMenuItem.Text = "JS"
        ' 
        ' XMLToolStripMenuItem
        ' 
        XMLToolStripMenuItem.Image = CType(resources.GetObject("XMLToolStripMenuItem.Image"), Image)
        XMLToolStripMenuItem.Name = "XMLToolStripMenuItem"
        XMLToolStripMenuItem.Size = New Size(113, 22)
        XMLToolStripMenuItem.Text = "XML"
        ' 
        ' PythonToolStripMenuItem
        ' 
        PythonToolStripMenuItem.Image = CType(resources.GetObject("PythonToolStripMenuItem.Image"), Image)
        PythonToolStripMenuItem.Name = "PythonToolStripMenuItem"
        PythonToolStripMenuItem.Size = New Size(113, 22)
        PythonToolStripMenuItem.Text = "Python"
        ' 
        ' RubyToolStripMenuItem
        ' 
        RubyToolStripMenuItem.Image = CType(resources.GetObject("RubyToolStripMenuItem.Image"), Image)
        RubyToolStripMenuItem.Name = "RubyToolStripMenuItem"
        RubyToolStripMenuItem.Size = New Size(113, 22)
        RubyToolStripMenuItem.Text = "Ruby"
        ' 
        ' OptionsToolStripMenuItem
        ' 
        OptionsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {WordsWrapToolStripMenuItem, ShowLineNumbersToolStripMenuItem})
        OptionsToolStripMenuItem.Image = CType(resources.GetObject("OptionsToolStripMenuItem.Image"), Image)
        OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        OptionsToolStripMenuItem.Size = New Size(77, 20)
        OptionsToolStripMenuItem.Text = "Options"
        ' 
        ' WordsWrapToolStripMenuItem
        ' 
        WordsWrapToolStripMenuItem.CheckOnClick = True
        WordsWrapToolStripMenuItem.Name = "WordsWrapToolStripMenuItem"
        WordsWrapToolStripMenuItem.Size = New Size(180, 22)
        WordsWrapToolStripMenuItem.Text = "Words Wrap"
        ' 
        ' ShowLineNumbersToolStripMenuItem
        ' 
        ShowLineNumbersToolStripMenuItem.CheckOnClick = True
        ShowLineNumbersToolStripMenuItem.Name = "ShowLineNumbersToolStripMenuItem"
        ShowLineNumbersToolStripMenuItem.Size = New Size(180, 22)
        ShowLineNumbersToolStripMenuItem.Text = "Show Line Numbers"
        ' 
        ' codetxt
        ' 
        codetxt.AnnotationVisible = ScintillaNET.Annotation.Standard
        codetxt.AutocompleteListSelectedBackColor = Color.FromArgb(CByte(0), CByte(120), CByte(215))
        codetxt.BorderStyle = ScintillaNET.BorderStyle.None
        codetxt.Dock = DockStyle.Fill
        codetxt.Font = New Font("Segoe UI", 9F)
        codetxt.LexerName = Nothing
        codetxt.Location = New Point(0, 24)
        codetxt.Name = "codetxt"
        codetxt.ScrollWidth = 51
        codetxt.Size = New Size(853, 475)
        codetxt.TabIndex = 1
        codetxt.UseTabs = True
        codetxt.WrapMode = ScintillaNET.WrapMode.Word
        ' 
        ' SFD
        ' 
        SFD.Title = "Save your file as"
        ' 
        ' NEditor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(853, 499)
        Controls.Add(codetxt)
        Controls.Add(MenuStrip1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = MenuStrip1
        Name = "NEditor"
        StartPosition = FormStartPosition.CenterParent
        Text = "Nimbus Code Editor"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents codetxt As ScintillaNET.Scintilla
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenAIToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WordsWrapToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ShowLineNumbersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ChatAssistantToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SFD As SaveFileDialog
    Friend WithEvents VBNETToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PHPToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HTLPToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JSONToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CSSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents XMLToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PythonToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RubyToolStripMenuItem As ToolStripMenuItem
End Class
