<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        GroupBox1 = New GroupBox()
        SaveProfile = New CheckBox()
        ftpport = New NumericUpDown()
        Button1 = New Button()
        Label4 = New Label()
        ftppass = New TextBox()
        Label3 = New Label()
        ftpuser = New TextBox()
        Label2 = New Label()
        ftphost = New TextBox()
        NProfilesCM = New ContextMenuStrip(components)
        NimbusProfilesToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator1 = New ToolStripSeparator()
        CopyToolStripMenuItem = New ToolStripMenuItem()
        PasteToolStripMenuItem = New ToolStripMenuItem()
        SelectAllToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator2 = New ToolStripSeparator()
        ClearToolStripMenuItem = New ToolStripMenuItem()
        Label1 = New Label()
        ProgressBar1 = New ProgressBar()
        PictureBox1 = New PictureBox()
        GroupBox1.SuspendLayout()
        CType(ftpport, ComponentModel.ISupportInitialize).BeginInit()
        NProfilesCM.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(SaveProfile)
        GroupBox1.Controls.Add(ftpport)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(ftppass)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(ftpuser)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(ftphost)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Location = New Point(12, 52)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(354, 200)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Your FTP Info"
        ' 
        ' SaveProfile
        ' 
        SaveProfile.AutoSize = True
        SaveProfile.Location = New Point(6, 175)
        SaveProfile.Name = "SaveProfile"
        SaveProfile.Size = New Size(146, 19)
        SaveProfile.TabIndex = 12
        SaveProfile.Text = "Save as Nimbus Profile"
        SaveProfile.UseVisualStyleBackColor = True
        ' 
        ' ftpport
        ' 
        ftpport.Location = New Point(99, 120)
        ftpport.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        ftpport.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        ftpport.Name = "ftpport"
        ftpport.Size = New Size(71, 23)
        ftpport.TabIndex = 10
        ftpport.TextAlign = HorizontalAlignment.Center
        ftpport.Value = New Decimal(New Integer() {21, 0, 0, 0})
        ' 
        ' Button1
        ' 
        Button1.Image = CType(resources.GetObject("Button1.Image"), Image)
        Button1.ImageAlign = ContentAlignment.MiddleLeft
        Button1.Location = New Point(239, 135)
        Button1.Name = "Button1"
        Button1.Size = New Size(109, 23)
        Button1.TabIndex = 5
        Button1.Text = "Connect"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(10, 122)
        Label4.Name = "Label4"
        Label4.Size = New Size(55, 15)
        Label4.TabIndex = 9
        Label4.Text = "FTP Host"
        ' 
        ' ftppass
        ' 
        ftppass.Location = New Point(99, 90)
        ftppass.Name = "ftppass"
        ftppass.Size = New Size(249, 23)
        ftppass.TabIndex = 8
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(10, 93)
        Label3.Name = "Label3"
        Label3.Size = New Size(80, 15)
        Label3.TabIndex = 7
        Label3.Text = "FTP Password"
        ' 
        ' ftpuser
        ' 
        ftpuser.Location = New Point(99, 61)
        ftpuser.Name = "ftpuser"
        ftpuser.Size = New Size(249, 23)
        ftpuser.TabIndex = 6
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(10, 64)
        Label2.Name = "Label2"
        Label2.Size = New Size(83, 15)
        Label2.TabIndex = 5
        Label2.Text = "FTP Username"
        ' 
        ' ftphost
        ' 
        ftphost.ContextMenuStrip = NProfilesCM
        ftphost.Location = New Point(99, 32)
        ftphost.Name = "ftphost"
        ftphost.Size = New Size(249, 23)
        ftphost.TabIndex = 4
        ' 
        ' NProfilesCM
        ' 
        NProfilesCM.Items.AddRange(New ToolStripItem() {NimbusProfilesToolStripMenuItem, ToolStripSeparator1, CopyToolStripMenuItem, PasteToolStripMenuItem, SelectAllToolStripMenuItem, ToolStripSeparator2, ClearToolStripMenuItem})
        NProfilesCM.Name = "NProfilesCM"
        NProfilesCM.Size = New Size(159, 126)
        ' 
        ' NimbusProfilesToolStripMenuItem
        ' 
        NimbusProfilesToolStripMenuItem.Image = CType(resources.GetObject("NimbusProfilesToolStripMenuItem.Image"), Image)
        NimbusProfilesToolStripMenuItem.Name = "NimbusProfilesToolStripMenuItem"
        NimbusProfilesToolStripMenuItem.Size = New Size(158, 22)
        NimbusProfilesToolStripMenuItem.Text = "Nimbus Profiles"
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(155, 6)
        ' 
        ' CopyToolStripMenuItem
        ' 
        CopyToolStripMenuItem.Image = My.Resources.NimbusResources.copy
        CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
        CopyToolStripMenuItem.Size = New Size(158, 22)
        CopyToolStripMenuItem.Text = "Copy"
        ' 
        ' PasteToolStripMenuItem
        ' 
        PasteToolStripMenuItem.Image = My.Resources.NimbusResources.paper_sizes
        PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
        PasteToolStripMenuItem.Size = New Size(158, 22)
        PasteToolStripMenuItem.Text = "Paste"
        ' 
        ' SelectAllToolStripMenuItem
        ' 
        SelectAllToolStripMenuItem.Image = My.Resources.NimbusResources.editing
        SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem"
        SelectAllToolStripMenuItem.Size = New Size(158, 22)
        SelectAllToolStripMenuItem.Text = "Select All"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(155, 6)
        ' 
        ' ClearToolStripMenuItem
        ' 
        ClearToolStripMenuItem.Image = My.Resources.NimbusResources.cross_1_
        ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        ClearToolStripMenuItem.Size = New Size(158, 22)
        ClearToolStripMenuItem.Text = "Clear"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(10, 35)
        Label1.Name = "Label1"
        Label1.Size = New Size(55, 15)
        Label1.TabIndex = 3
        Label1.Text = "FTP Host"
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Dock = DockStyle.Bottom
        ProgressBar1.Location = New Point(0, 263)
        ProgressBar1.MarqueeAnimationSpeed = 10
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(378, 5)
        ProgressBar1.Step = 5
        ProgressBar1.Style = ProgressBarStyle.Marquee
        ProgressBar1.TabIndex = 11
        ProgressBar1.Visible = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(271, 3)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(107, 53)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 12
        PictureBox1.TabStop = False
        ' 
        ' Login
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(378, 268)
        Controls.Add(PictureBox1)
        Controls.Add(ProgressBar1)
        Controls.Add(GroupBox1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Login"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(ftpport, ComponentModel.ISupportInitialize).EndInit()
        NProfilesCM.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents ftphost As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ftpuser As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ftppass As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ftpport As NumericUpDown
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents SaveProfile As CheckBox
    Friend WithEvents NProfilesCM As ContextMenuStrip
    Friend WithEvents NimbusProfilesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents CopyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ClearToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
End Class
