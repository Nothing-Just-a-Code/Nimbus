<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DownloadFolder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DownloadFolder))
        Panel1 = New Panel()
        filedownprog = New ProgressBar()
        overallprog = New ProgressBar()
        Button1 = New Button()
        downeta = New Label()
        Label6 = New Label()
        downspeed = New Label()
        Label3 = New Label()
        Fname = New Label()
        Label1 = New Label()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), Image)
        Panel1.BackgroundImageLayout = ImageLayout.Stretch
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(filedownprog)
        Panel1.Controls.Add(overallprog)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(downeta)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(downspeed)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Fname)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(578, 165)
        Panel1.TabIndex = 0
        ' 
        ' filedownprog
        ' 
        filedownprog.Location = New Point(11, 118)
        filedownprog.Name = "filedownprog"
        filedownprog.Size = New Size(212, 5)
        filedownprog.TabIndex = 8
        ' 
        ' overallprog
        ' 
        overallprog.Location = New Point(4, 153)
        overallprog.Name = "overallprog"
        overallprog.Size = New Size(455, 5)
        overallprog.TabIndex = 7
        ' 
        ' Button1
        ' 
        Button1.Image = CType(resources.GetObject("Button1.Image"), Image)
        Button1.ImageAlign = ContentAlignment.MiddleLeft
        Button1.Location = New Point(484, 137)
        Button1.Name = "Button1"
        Button1.Size = New Size(89, 23)
        Button1.TabIndex = 6
        Button1.Text = "Cancel"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' downeta
        ' 
        downeta.AutoSize = True
        downeta.BackColor = Color.Transparent
        downeta.Location = New Point(72, 93)
        downeta.Name = "downeta"
        downeta.Size = New Size(22, 15)
        downeta.TabIndex = 5
        downeta.Text = ". . ."
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.Transparent
        Label6.Location = New Point(11, 93)
        Label6.Name = "Label6"
        Label6.Size = New Size(55, 15)
        Label6.TabIndex = 4
        Label6.Text = "Estimate:"
        ' 
        ' downspeed
        ' 
        downspeed.AutoSize = True
        downspeed.BackColor = Color.Transparent
        downspeed.Location = New Point(72, 73)
        downspeed.Name = "downspeed"
        downspeed.Size = New Size(22, 15)
        downspeed.TabIndex = 3
        downspeed.Text = ". . ."
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Location = New Point(11, 73)
        Label3.Name = "Label3"
        Label3.Size = New Size(42, 15)
        Label3.TabIndex = 2
        Label3.Text = "Speed:"
        ' 
        ' Fname
        ' 
        Fname.AutoEllipsis = True
        Fname.BackColor = Color.Transparent
        Fname.Location = New Point(11, 46)
        Fname.Name = "Fname"
        Fname.Size = New Size(537, 15)
        Fname.TabIndex = 1
        Fname.Text = "Downloading file: . . ."
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = SystemColors.ControlText
        Label1.Location = New Point(8, 8)
        Label1.Name = "Label1"
        Label1.Size = New Size(516, 17)
        Label1.TabIndex = 0
        Label1.Text = "Listing Directory. Please wait... It may take longer than expected if directory is large."
        ' 
        ' DownloadFolder
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(578, 165)
        Controls.Add(Panel1)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.None
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "DownloadFolder"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "Download Folder  -  Nimbus"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Fname As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents downspeed As Label
    Friend WithEvents downeta As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents overallprog As ProgressBar
    Friend WithEvents filedownprog As ProgressBar
End Class
