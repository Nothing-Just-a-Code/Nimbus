<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Profiles
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Profiles))
        proflist = New ListBox()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        CopyToolStripMenuItem = New ToolStripMenuItem()
        UsernameToolStripMenuItem = New ToolStripMenuItem()
        HostToolStripMenuItem = New ToolStripMenuItem()
        EditToolStripMenuItem = New ToolStripMenuItem()
        UsernameToolStripMenuItem1 = New ToolStripMenuItem()
        HostToolStripMenuItem1 = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        DeleteToolStripMenuItem = New ToolStripMenuItem()
        ContextMenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' proflist
        ' 
        proflist.ContextMenuStrip = ContextMenuStrip1
        proflist.Dock = DockStyle.Fill
        proflist.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold)
        proflist.FormattingEnabled = True
        proflist.ItemHeight = 15
        proflist.Location = New Point(0, 0)
        proflist.Name = "proflist"
        proflist.Size = New Size(316, 427)
        proflist.TabIndex = 0
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {CopyToolStripMenuItem, EditToolStripMenuItem, ToolStripSeparator1, DeleteToolStripMenuItem})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(108, 76)
        ' 
        ' CopyToolStripMenuItem
        ' 
        CopyToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {UsernameToolStripMenuItem, HostToolStripMenuItem})
        CopyToolStripMenuItem.Image = My.Resources.NimbusResources.copy
        CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        CopyToolStripMenuItem.Size = New Size(107, 22)
        CopyToolStripMenuItem.Text = "Copy"
        ' 
        ' UsernameToolStripMenuItem
        ' 
        UsernameToolStripMenuItem.Image = CType(resources.GetObject("UsernameToolStripMenuItem.Image"), Image)
        UsernameToolStripMenuItem.Name = "UsernameToolStripMenuItem"
        UsernameToolStripMenuItem.Size = New Size(127, 22)
        UsernameToolStripMenuItem.Text = "Username"
        ' 
        ' HostToolStripMenuItem
        ' 
        HostToolStripMenuItem.Image = CType(resources.GetObject("HostToolStripMenuItem.Image"), Image)
        HostToolStripMenuItem.Name = "HostToolStripMenuItem"
        HostToolStripMenuItem.Size = New Size(127, 22)
        HostToolStripMenuItem.Text = "Host"
        ' 
        ' EditToolStripMenuItem
        ' 
        EditToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {UsernameToolStripMenuItem1, HostToolStripMenuItem1})
        EditToolStripMenuItem.Image = CType(resources.GetObject("EditToolStripMenuItem.Image"), Image)
        EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        EditToolStripMenuItem.Size = New Size(107, 22)
        EditToolStripMenuItem.Text = "Edit"
        ' 
        ' UsernameToolStripMenuItem1
        ' 
        UsernameToolStripMenuItem1.Image = CType(resources.GetObject("UsernameToolStripMenuItem1.Image"), Image)
        UsernameToolStripMenuItem1.Name = "UsernameToolStripMenuItem1"
        UsernameToolStripMenuItem1.Size = New Size(127, 22)
        UsernameToolStripMenuItem1.Text = "Username"
        ' 
        ' HostToolStripMenuItem1
        ' 
        HostToolStripMenuItem1.Image = CType(resources.GetObject("HostToolStripMenuItem1.Image"), Image)
        HostToolStripMenuItem1.Name = "HostToolStripMenuItem1"
        HostToolStripMenuItem1.Size = New Size(127, 22)
        HostToolStripMenuItem1.Text = "Host"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(104, 6)
        ' 
        ' DeleteToolStripMenuItem
        ' 
        DeleteToolStripMenuItem.Image = CType(resources.GetObject("DeleteToolStripMenuItem.Image"), Image)
        DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        DeleteToolStripMenuItem.Size = New Size(107, 22)
        DeleteToolStripMenuItem.Text = "Delete"
        ' 
        ' Profiles
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(316, 427)
        Controls.Add(proflist)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Profiles"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "Profiles"
        ContextMenuStrip1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents proflist As ListBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UsernameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HostToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UsernameToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents HostToolStripMenuItem1 As ToolStripMenuItem
End Class
