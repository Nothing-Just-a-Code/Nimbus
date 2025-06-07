<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CodeGenerator
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
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CodeGenerator))
        GroupBox1 = New GroupBox()
        codecmd = New TextBox()
        FCTB = New FastColoredTextBoxNS.FastColoredTextBox()
        GroupBox1.SuspendLayout()
        CType(FCTB, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(codecmd)
        GroupBox1.Dock = DockStyle.Top
        GroupBox1.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        GroupBox1.Location = New Point(0, 0)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(849, 52)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Your Code Command"
        ' 
        ' codecmd
        ' 
        codecmd.Dock = DockStyle.Bottom
        codecmd.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        codecmd.Location = New Point(3, 26)
        codecmd.Name = "codecmd"
        codecmd.PlaceholderText = "Ex.: Generate a code for auto redirect in .htaccess"
        codecmd.Size = New Size(843, 23)
        codecmd.TabIndex = 0
        ' 
        ' FCTB
        ' 
        FCTB.AccessibleDescription = "Textbox control"
        FCTB.AccessibleName = "Fast Colored Text Box"
        FCTB.AccessibleRole = AccessibleRole.Text
        FCTB.AutoCompleteBracketsList = New Char() {"("c, ")"c, "{"c, "}"c, "["c, "]"c, """"c, """"c, "'"c, "'"c}
        FCTB.AutoIndentCharsPatterns = "^\s*[\w\.]+(\s\w+)?\s*(?<range>=)\s*(?<range>[^;=]+);" & vbCrLf & "^\s*(case|default)\s*[^:]*(?<range>:)\s*(?<range>[^;]+);"
        FCTB.AutoScrollMinSize = New Size(0, 14)
        FCTB.BackBrush = Nothing
        FCTB.CharCnWidth = 15
        FCTB.CharHeight = 14
        FCTB.CharWidth = 8
        FCTB.DefaultMarkerSize = 8
        FCTB.DisabledColor = Color.FromArgb(CByte(100), CByte(180), CByte(180), CByte(180))
        FCTB.Dock = DockStyle.Fill
        FCTB.FindForm = Nothing
        FCTB.FoldingHighlightColor = Color.LightGray
        FCTB.FoldingHighlightEnabled = False
        FCTB.GoToForm = Nothing
        FCTB.Hotkeys = resources.GetString("FCTB.Hotkeys")
        FCTB.IsReplaceMode = False
        FCTB.Location = New Point(0, 52)
        FCTB.Name = "FCTB"
        FCTB.Paddings = New Padding(0)
        FCTB.ReplaceForm = Nothing
        FCTB.SelectionColor = Color.FromArgb(CByte(60), CByte(0), CByte(0), CByte(255))
        FCTB.ServiceColors = CType(resources.GetObject("FCTB.ServiceColors"), FastColoredTextBoxNS.ServiceColors)
        FCTB.Size = New Size(849, 457)
        FCTB.TabIndex = 1
        FCTB.ToolTipDelay = 100
        FCTB.UseCJK = FastColoredTextBoxNS.CJKMode.Hanzi
        FCTB.WordWrap = True
        FCTB.Zoom = 100
        ' 
        ' CodeGenerator
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(849, 509)
        Controls.Add(FCTB)
        Controls.Add(GroupBox1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "CodeGenerator"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Code Generator with Gemini AI"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(FCTB, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents FCTB As FastColoredTextBoxNS.FastColoredTextBox
    Friend WithEvents codecmd As TextBox
End Class
