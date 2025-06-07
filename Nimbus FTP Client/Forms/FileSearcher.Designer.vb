<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileSearcher
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FileSearcher))
        GroupBox1 = New GroupBox()
        pbar = New ProgressBar()
        Dirtxt = New TextBox()
        Label2 = New Label()
        PictureBox1 = New PictureBox()
        Button1 = New Button()
        filekeyword = New TextBox()
        Label1 = New Label()
        GroupBox2 = New GroupBox()
        fileslist = New ListView()
        ColumnHeader1 = New ColumnHeader()
        ColumnHeader2 = New ColumnHeader()
        ColumnHeader3 = New ColumnHeader()
        ColumnHeader4 = New ColumnHeader()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        EditFieToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        CopyNameToolStripMenuItem = New ToolStripMenuItem()
        CopyPathToolStripMenuItem = New ToolStripMenuItem()
        DeleteFileToolStripMenuItem = New ToolStripMenuItem()
        ImageList1 = New ImageList(components)
        GroupBox1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox2.SuspendLayout()
        ContextMenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(pbar)
        GroupBox1.Controls.Add(Dirtxt)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(PictureBox1)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Controls.Add(filekeyword)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Dock = DockStyle.Top
        GroupBox1.Location = New Point(0, 0)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(800, 149)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Search File(s)"
        ' 
        ' pbar
        ' 
        pbar.Dock = DockStyle.Bottom
        pbar.Location = New Point(3, 143)
        pbar.MarqueeAnimationSpeed = 15
        pbar.Name = "pbar"
        pbar.Size = New Size(794, 3)
        pbar.Style = ProgressBarStyle.Marquee
        pbar.TabIndex = 6
        pbar.Visible = False
        ' 
        ' Dirtxt
        ' 
        Dirtxt.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Dirtxt.Location = New Point(14, 97)
        Dirtxt.Name = "Dirtxt"
        Dirtxt.PlaceholderText = "/public_html"
        Dirtxt.Size = New Size(297, 23)
        Dirtxt.TabIndex = 5
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(14, 78)
        Label2.Name = "Label2"
        Label2.Size = New Size(166, 15)
        Label2.TabIndex = 4
        Label2.Text = "In Directory (Must start with /)"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(734, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(60, 60)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 3
        PictureBox1.TabStop = False
        PictureBox1.Visible = False
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button1.Enabled = False
        Button1.Location = New Point(708, 114)
        Button1.Name = "Button1"
        Button1.Size = New Size(86, 23)
        Button1.TabIndex = 2
        Button1.Text = "Search"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' filekeyword
        ' 
        filekeyword.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        filekeyword.Location = New Point(14, 42)
        filekeyword.Name = "filekeyword"
        filekeyword.PlaceholderText = "Keyword to search for a file"
        filekeyword.Size = New Size(297, 23)
        filekeyword.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(14, 23)
        Label1.Name = "Label1"
        Label1.Size = New Size(53, 15)
        Label1.TabIndex = 0
        Label1.Text = "Keyword"
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(fileslist)
        GroupBox2.Dock = DockStyle.Fill
        GroupBox2.Location = New Point(0, 149)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(800, 301)
        GroupBox2.TabIndex = 1
        GroupBox2.TabStop = False
        GroupBox2.Text = "Searched Files"
        ' 
        ' fileslist
        ' 
        fileslist.Columns.AddRange(New ColumnHeader() {ColumnHeader1, ColumnHeader2, ColumnHeader3, ColumnHeader4})
        fileslist.ContextMenuStrip = ContextMenuStrip1
        fileslist.Dock = DockStyle.Fill
        fileslist.FullRowSelect = True
        fileslist.Location = New Point(3, 19)
        fileslist.MultiSelect = False
        fileslist.Name = "fileslist"
        fileslist.Size = New Size(794, 279)
        fileslist.SmallImageList = ImageList1
        fileslist.TabIndex = 0
        fileslist.UseCompatibleStateImageBehavior = False
        fileslist.View = View.Details
        ' 
        ' ColumnHeader1
        ' 
        ColumnHeader1.Text = "Filename"
        ColumnHeader1.Width = 150
        ' 
        ' ColumnHeader2
        ' 
        ColumnHeader2.Text = "Directory"
        ColumnHeader2.TextAlign = HorizontalAlignment.Center
        ColumnHeader2.Width = 100
        ' 
        ' ColumnHeader3
        ' 
        ColumnHeader3.Text = "Size"
        ColumnHeader3.TextAlign = HorizontalAlignment.Center
        ColumnHeader3.Width = 80
        ' 
        ' ColumnHeader4
        ' 
        ColumnHeader4.Text = "Permission"
        ColumnHeader4.TextAlign = HorizontalAlignment.Center
        ColumnHeader4.Width = 80
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.Items.AddRange(New ToolStripItem() {EditFieToolStripMenuItem, ToolStripSeparator1, CopyNameToolStripMenuItem, CopyPathToolStripMenuItem, DeleteFileToolStripMenuItem})
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(138, 98)
        ' 
        ' EditFieToolStripMenuItem
        ' 
        EditFieToolStripMenuItem.Image = My.Resources.NimbusResources.editing
        EditFieToolStripMenuItem.Name = "EditFieToolStripMenuItem"
        EditFieToolStripMenuItem.Size = New Size(137, 22)
        EditFieToolStripMenuItem.Text = "Edit File"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(134, 6)
        ' 
        ' CopyNameToolStripMenuItem
        ' 
        CopyNameToolStripMenuItem.Image = My.Resources.NimbusResources.copy1
        CopyNameToolStripMenuItem.Name = "CopyNameToolStripMenuItem"
        CopyNameToolStripMenuItem.Size = New Size(137, 22)
        CopyNameToolStripMenuItem.Text = "Copy Name"
        ' 
        ' CopyPathToolStripMenuItem
        ' 
        CopyPathToolStripMenuItem.Image = My.Resources.NimbusResources.link_3_
        CopyPathToolStripMenuItem.Name = "CopyPathToolStripMenuItem"
        CopyPathToolStripMenuItem.Size = New Size(137, 22)
        CopyPathToolStripMenuItem.Text = "Copy Path"
        ' 
        ' DeleteFileToolStripMenuItem
        ' 
        DeleteFileToolStripMenuItem.Image = My.Resources.NimbusResources.delete
        DeleteFileToolStripMenuItem.Name = "DeleteFileToolStripMenuItem"
        DeleteFileToolStripMenuItem.Size = New Size(137, 22)
        DeleteFileToolStripMenuItem.Text = "Delete File"
        ' 
        ' ImageList1
        ' 
        ImageList1.ColorDepth = ColorDepth.Depth32Bit
        ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), ImageListStreamer)
        ImageList1.TransparentColor = Color.Transparent
        ImageList1.Images.SetKeyName(0, "search(2).png")
        ' 
        ' FileSearcher
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(800, 450)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "FileSearcher"
        StartPosition = FormStartPosition.CenterScreen
        Text = "File Searcher"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        ContextMenuStrip1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents fileslist As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents Label1 As Label
    Friend WithEvents filekeyword As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Dirtxt As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents pbar As ProgressBar
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents CopyNameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyPathToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditFieToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class
