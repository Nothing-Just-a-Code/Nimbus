<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Gemini
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Gemini))
        txtInput = New TextBox()
        flowMessages = New FlowLayoutPanel()
        SplitContainer1 = New SplitContainer()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        SuspendLayout()
        ' 
        ' txtInput
        ' 
        txtInput.Dock = DockStyle.Fill
        txtInput.Location = New Point(0, 0)
        txtInput.Multiline = True
        txtInput.Name = "txtInput"
        txtInput.Size = New Size(887, 76)
        txtInput.TabIndex = 1
        ' 
        ' flowMessages
        ' 
        flowMessages.AutoScroll = True
        flowMessages.Dock = DockStyle.Fill
        flowMessages.FlowDirection = FlowDirection.TopDown
        flowMessages.Location = New Point(0, 0)
        flowMessages.Name = "flowMessages"
        flowMessages.Size = New Size(887, 440)
        flowMessages.TabIndex = 2
        flowMessages.WrapContents = False
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.FixedPanel = FixedPanel.Panel2
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        SplitContainer1.Orientation = Orientation.Horizontal
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(flowMessages)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(txtInput)
        SplitContainer1.Size = New Size(887, 520)
        SplitContainer1.SplitterDistance = 440
        SplitContainer1.TabIndex = 3
        ' 
        ' Gemini
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(887, 520)
        Controls.Add(SplitContainer1)
        DoubleBuffered = True
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "Gemini"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Gemini AI Assistant"
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        SplitContainer1.Panel2.PerformLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents txtInput As TextBox
    Friend WithEvents flowMessages As FlowLayoutPanel
    Friend WithEvents SplitContainer1 As SplitContainer
End Class
