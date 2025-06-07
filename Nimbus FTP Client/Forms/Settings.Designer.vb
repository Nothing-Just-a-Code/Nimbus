<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Settings))
        TabControl1 = New TabControl()
        TabPage3 = New TabPage()
        GroupBox8 = New GroupBox()
        FileCompareType = New ComboBox()
        GroupBox7 = New GroupBox()
        savegemapi = New Button()
        getapibtn = New Button()
        GeminiAPItxt = New TextBox()
        Label7 = New Label()
        GroupBox4 = New GroupBox()
        load_bsc = New RadioButton()
        load_adv = New RadioButton()
        checkupdate = New CheckBox()
        TabPage1 = New TabPage()
        GroupBox3 = New GroupBox()
        DelLFile = New CheckBox()
        GroupBox2 = New GroupBox()
        Label2 = New Label()
        up_overwritetype = New ComboBox()
        Label1 = New Label()
        GroupBox1 = New GroupBox()
        TdataType = New ComboBox()
        TabPage2 = New TabPage()
        GroupBox10 = New GroupBox()
        DownFileAction = New ComboBox()
        Label10 = New Label()
        remdir = New CheckBox()
        GroupBox9 = New GroupBox()
        Button1 = New Button()
        Label8 = New Label()
        DownDirtxt = New TextBox()
        TabPage4 = New TabPage()
        GroupBox6 = New GroupBox()
        Enc_Type = New ComboBox()
        GroupBox5 = New GroupBox()
        maxretry = New NumericUpDown()
        Label6 = New Label()
        read_TO = New TextBox()
        Label5 = New Label()
        Dconnection_TO = New TextBox()
        Label4 = New Label()
        connection_TO = New TextBox()
        Label3 = New Label()
        ImageList1 = New ImageList(components)
        ToolTip1 = New ToolTip(components)
        FolderBrowserDialog1 = New FolderBrowserDialog()
        TabControl1.SuspendLayout()
        TabPage3.SuspendLayout()
        GroupBox8.SuspendLayout()
        GroupBox7.SuspendLayout()
        GroupBox4.SuspendLayout()
        TabPage1.SuspendLayout()
        GroupBox3.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox1.SuspendLayout()
        TabPage2.SuspendLayout()
        GroupBox10.SuspendLayout()
        GroupBox9.SuspendLayout()
        TabPage4.SuspendLayout()
        GroupBox6.SuspendLayout()
        GroupBox5.SuspendLayout()
        CType(maxretry, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPage3)
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage4)
        TabControl1.Dock = DockStyle.Fill
        TabControl1.ImageList = ImageList1
        TabControl1.Location = New Point(0, 0)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(650, 409)
        TabControl1.TabIndex = 0
        ' 
        ' TabPage3
        ' 
        TabPage3.AutoScroll = True
        TabPage3.BackColor = Color.White
        TabPage3.Controls.Add(GroupBox8)
        TabPage3.Controls.Add(GroupBox7)
        TabPage3.Controls.Add(GroupBox4)
        TabPage3.Controls.Add(checkupdate)
        TabPage3.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TabPage3.ImageIndex = 3
        TabPage3.Location = New Point(4, 24)
        TabPage3.Name = "TabPage3"
        TabPage3.Padding = New Padding(3)
        TabPage3.Size = New Size(642, 381)
        TabPage3.TabIndex = 2
        TabPage3.Text = "General"
        ' 
        ' GroupBox8
        ' 
        GroupBox8.Controls.Add(FileCompareType)
        GroupBox8.Location = New Point(11, 283)
        GroupBox8.Name = "GroupBox8"
        GroupBox8.Size = New Size(253, 78)
        GroupBox8.TabIndex = 3
        GroupBox8.TabStop = False
        GroupBox8.Text = "File Comparison Method"
        ' 
        ' FileCompareType
        ' 
        FileCompareType.DropDownStyle = ComboBoxStyle.DropDownList
        FileCompareType.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        FileCompareType.FormattingEnabled = True
        FileCompareType.Items.AddRange(New Object() {"Auto", "Modified Date", "Checksum", "File Size"})
        FileCompareType.Location = New Point(10, 37)
        FileCompareType.Name = "FileCompareType"
        FileCompareType.Size = New Size(143, 23)
        FileCompareType.TabIndex = 4
        ' 
        ' GroupBox7
        ' 
        GroupBox7.Controls.Add(savegemapi)
        GroupBox7.Controls.Add(getapibtn)
        GroupBox7.Controls.Add(GeminiAPItxt)
        GroupBox7.Controls.Add(Label7)
        GroupBox7.Location = New Point(11, 166)
        GroupBox7.Name = "GroupBox7"
        GroupBox7.Size = New Size(305, 106)
        GroupBox7.TabIndex = 2
        GroupBox7.TabStop = False
        GroupBox7.Text = "Gemini AI API Key"
        ' 
        ' savegemapi
        ' 
        savegemapi.Location = New Point(232, 74)
        savegemapi.Name = "savegemapi"
        savegemapi.Size = New Size(61, 23)
        savegemapi.TabIndex = 5
        savegemapi.Text = "Save"
        savegemapi.UseVisualStyleBackColor = True
        ' 
        ' getapibtn
        ' 
        getapibtn.Location = New Point(10, 74)
        getapibtn.Name = "getapibtn"
        getapibtn.Size = New Size(86, 23)
        getapibtn.TabIndex = 3
        getapibtn.Text = "Get API Key"
        getapibtn.UseVisualStyleBackColor = True
        ' 
        ' GeminiAPItxt
        ' 
        GeminiAPItxt.Location = New Point(10, 45)
        GeminiAPItxt.Name = "GeminiAPItxt"
        GeminiAPItxt.Size = New Size(283, 23)
        GeminiAPItxt.TabIndex = 4
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(10, 26)
        Label7.Name = "Label7"
        Label7.Size = New Size(159, 15)
        Label7.TabIndex = 0
        Label7.Text = "Enter your Gemini AI API Key"
        ' 
        ' GroupBox4
        ' 
        GroupBox4.Controls.Add(load_bsc)
        GroupBox4.Controls.Add(load_adv)
        GroupBox4.Location = New Point(11, 70)
        GroupBox4.Name = "GroupBox4"
        GroupBox4.Size = New Size(305, 87)
        GroupBox4.TabIndex = 1
        GroupBox4.TabStop = False
        GroupBox4.Text = "Files Loading Method"
        ' 
        ' load_bsc
        ' 
        load_bsc.AutoSize = True
        load_bsc.Location = New Point(7, 54)
        load_bsc.Name = "load_bsc"
        load_bsc.Size = New Size(170, 19)
        load_bsc.TabIndex = 3
        load_bsc.TabStop = True
        load_bsc.Text = "Load files all at once (Basic)"
        load_bsc.UseVisualStyleBackColor = True
        ' 
        ' load_adv
        ' 
        load_adv.AutoSize = True
        load_adv.Location = New Point(7, 26)
        load_adv.Name = "load_adv"
        load_adv.Size = New Size(220, 19)
        load_adv.TabIndex = 2
        load_adv.TabStop = True
        load_adv.Text = "Load all files one-by-one (Advanced)"
        load_adv.UseVisualStyleBackColor = True
        ' 
        ' checkupdate
        ' 
        checkupdate.AutoSize = True
        checkupdate.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        checkupdate.Location = New Point(11, 20)
        checkupdate.Name = "checkupdate"
        checkupdate.Size = New Size(239, 19)
        checkupdate.TabIndex = 0
        checkupdate.Text = "Check for update when application start."
        checkupdate.UseVisualStyleBackColor = True
        ' 
        ' TabPage1
        ' 
        TabPage1.AutoScroll = True
        TabPage1.BackColor = Color.White
        TabPage1.Controls.Add(GroupBox3)
        TabPage1.Controls.Add(GroupBox2)
        TabPage1.Controls.Add(GroupBox1)
        TabPage1.ImageIndex = 1
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(642, 381)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Uploads"
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(DelLFile)
        GroupBox3.Location = New Point(10, 231)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(199, 54)
        GroupBox3.TabIndex = 3
        GroupBox3.TabStop = False
        GroupBox3.Text = "File Edit Action"
        ' 
        ' DelLFile
        ' 
        DelLFile.AutoSize = True
        DelLFile.Location = New Point(11, 26)
        DelLFile.Name = "DelLFile"
        DelLFile.Size = New Size(156, 19)
        DelLFile.TabIndex = 2
        DelLFile.Text = "Delete local file after edit"
        DelLFile.UseVisualStyleBackColor = True
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(Label2)
        GroupBox2.Controls.Add(up_overwritetype)
        GroupBox2.Controls.Add(Label1)
        GroupBox2.Location = New Point(10, 96)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(302, 124)
        GroupBox2.TabIndex = 1
        GroupBox2.TabStop = False
        GroupBox2.Text = "Upload File Action"
        ' 
        ' Label2
        ' 
        Label2.AutoEllipsis = True
        Label2.Font = New Font("Segoe UI", 7.75F)
        Label2.Location = New Point(7, 105)
        Label2.Name = "Label2"
        Label2.Size = New Size(289, 13)
        Label2.TabIndex = 3
        Label2.Text = ". . ."
        ' 
        ' up_overwritetype
        ' 
        up_overwritetype.DropDownStyle = ComboBoxStyle.DropDownList
        up_overwritetype.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        up_overwritetype.FormattingEnabled = True
        up_overwritetype.Items.AddRange(New Object() {"No Checks", "Skip", "Resume", "Overwrite"})
        up_overwritetype.Location = New Point(17, 67)
        up_overwritetype.Name = "up_overwritetype"
        up_overwritetype.Size = New Size(121, 23)
        up_overwritetype.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 8F)
        Label1.Location = New Point(10, 23)
        Label1.Name = "Label1"
        Label1.Size = New Size(248, 26)
        Label1.TabIndex = 0
        Label1.Text = "What action you would like to take when a file" & vbCrLf & "already exist in your directory."
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(TdataType)
        GroupBox1.Location = New Point(10, 10)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(160, 75)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Transfer Data Type"
        ' 
        ' TdataType
        ' 
        TdataType.DropDownStyle = ComboBoxStyle.DropDownList
        TdataType.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TdataType.FormattingEnabled = True
        TdataType.Items.AddRange(New Object() {"ASCII", "Binary"})
        TdataType.Location = New Point(17, 32)
        TdataType.Name = "TdataType"
        TdataType.Size = New Size(121, 23)
        TdataType.TabIndex = 1
        ' 
        ' TabPage2
        ' 
        TabPage2.BackColor = Color.White
        TabPage2.Controls.Add(GroupBox10)
        TabPage2.Controls.Add(remdir)
        TabPage2.Controls.Add(GroupBox9)
        TabPage2.ImageIndex = 2
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(642, 381)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Downloads"
        ' 
        ' GroupBox10
        ' 
        GroupBox10.Controls.Add(DownFileAction)
        GroupBox10.Controls.Add(Label10)
        GroupBox10.Location = New Point(11, 166)
        GroupBox10.Name = "GroupBox10"
        GroupBox10.Size = New Size(302, 107)
        GroupBox10.TabIndex = 2
        GroupBox10.TabStop = False
        GroupBox10.Text = "Download File Action"
        ' 
        ' DownFileAction
        ' 
        DownFileAction.DropDownStyle = ComboBoxStyle.DropDownList
        DownFileAction.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        DownFileAction.FormattingEnabled = True
        DownFileAction.Items.AddRange(New Object() {"Overwrite", "Resume", "Skip", "Append"})
        DownFileAction.Location = New Point(17, 67)
        DownFileAction.Name = "DownFileAction"
        DownFileAction.Size = New Size(168, 23)
        DownFileAction.TabIndex = 2
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Segoe UI", 8F)
        Label10.Location = New Point(10, 23)
        Label10.Name = "Label10"
        Label10.Size = New Size(248, 26)
        Label10.TabIndex = 0
        Label10.Text = "What action you would like to take when a file" & vbCrLf & "already exist in your directory."
        ' 
        ' remdir
        ' 
        remdir.AutoSize = True
        remdir.Location = New Point(11, 20)
        remdir.Name = "remdir"
        remdir.Size = New Size(260, 19)
        remdir.TabIndex = 1
        remdir.Text = "Create Remote Directory on FTP (if not exist)"
        ToolTip1.SetToolTip(remdir, "Enabling this option will automatically create the remote directories and sub-directories (if needed)")
        remdir.UseVisualStyleBackColor = True
        ' 
        ' GroupBox9
        ' 
        GroupBox9.Controls.Add(Button1)
        GroupBox9.Controls.Add(Label8)
        GroupBox9.Controls.Add(DownDirtxt)
        GroupBox9.Location = New Point(11, 68)
        GroupBox9.Name = "GroupBox9"
        GroupBox9.Size = New Size(348, 87)
        GroupBox9.TabIndex = 0
        GroupBox9.TabStop = False
        GroupBox9.Text = "Downloads Directory"
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(267, 53)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 1
        Button1.Text = "Change"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Location = New Point(11, 27)
        Label8.Name = "Label8"
        Label8.Size = New Size(55, 15)
        Label8.TabIndex = 0
        Label8.Text = "Directory"
        ' 
        ' DownDirtxt
        ' 
        DownDirtxt.BackColor = Color.White
        DownDirtxt.Location = New Point(72, 24)
        DownDirtxt.Name = "DownDirtxt"
        DownDirtxt.ReadOnly = True
        DownDirtxt.Size = New Size(270, 23)
        DownDirtxt.TabIndex = 1
        ' 
        ' TabPage4
        ' 
        TabPage4.BackColor = Color.White
        TabPage4.Controls.Add(GroupBox6)
        TabPage4.Controls.Add(GroupBox5)
        TabPage4.ImageIndex = 4
        TabPage4.Location = New Point(4, 24)
        TabPage4.Name = "TabPage4"
        TabPage4.Padding = New Padding(3)
        TabPage4.Size = New Size(642, 381)
        TabPage4.TabIndex = 3
        TabPage4.Text = "Connection"
        ' 
        ' GroupBox6
        ' 
        GroupBox6.Controls.Add(Enc_Type)
        GroupBox6.Location = New Point(10, 10)
        GroupBox6.Name = "GroupBox6"
        GroupBox6.Size = New Size(178, 67)
        GroupBox6.TabIndex = 2
        GroupBox6.TabStop = False
        GroupBox6.Text = "Connection Encryption Mode"
        ' 
        ' Enc_Type
        ' 
        Enc_Type.DropDownStyle = ComboBoxStyle.DropDownList
        Enc_Type.FormattingEnabled = True
        Enc_Type.Items.AddRange(New Object() {"Plain Text", "Implicit", "Explicit", "Auto"})
        Enc_Type.Location = New Point(15, 29)
        Enc_Type.Name = "Enc_Type"
        Enc_Type.Size = New Size(141, 23)
        Enc_Type.TabIndex = 0
        ' 
        ' GroupBox5
        ' 
        GroupBox5.Controls.Add(maxretry)
        GroupBox5.Controls.Add(Label6)
        GroupBox5.Controls.Add(read_TO)
        GroupBox5.Controls.Add(Label5)
        GroupBox5.Controls.Add(Dconnection_TO)
        GroupBox5.Controls.Add(Label4)
        GroupBox5.Controls.Add(connection_TO)
        GroupBox5.Controls.Add(Label3)
        GroupBox5.Location = New Point(10, 88)
        GroupBox5.Name = "GroupBox5"
        GroupBox5.Size = New Size(311, 174)
        GroupBox5.TabIndex = 1
        GroupBox5.TabStop = False
        GroupBox5.Text = "Timeouts (Timeout values must be in seconds)"
        ' 
        ' maxretry
        ' 
        maxretry.Location = New Point(184, 128)
        maxretry.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        maxretry.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        maxretry.Name = "maxretry"
        maxretry.Size = New Size(81, 23)
        maxretry.TabIndex = 2
        maxretry.TextAlign = HorizontalAlignment.Center
        ToolTip1.SetToolTip(maxretry, "Max retry attempts allowed when a verification failure occurs during download or upload.")
        maxretry.Value = New Decimal(New Integer() {1, 0, 0, 0})
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(13, 130)
        Label6.Name = "Label6"
        Label6.Size = New Size(112, 15)
        Label6.TabIndex = 6
        Label6.Text = "Task Retry Attempts"
        ToolTip1.SetToolTip(Label6, "Max retry attempts allowed when a verification failure occurs during download or upload.")
        ' 
        ' read_TO
        ' 
        read_TO.Location = New Point(184, 95)
        read_TO.Name = "read_TO"
        read_TO.PlaceholderText = "In seconds"
        read_TO.Size = New Size(81, 23)
        read_TO.TabIndex = 5
        read_TO.TextAlign = HorizontalAlignment.Center
        ToolTip1.SetToolTip(read_TO, "Time for data to be read from the underlying stream.")
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(13, 98)
        Label5.Name = "Label5"
        Label5.Size = New Size(81, 15)
        Label5.TabIndex = 4
        Label5.Text = "Read Timeout"
        ToolTip1.SetToolTip(Label5, "Time for data to be read from the underlying stream.")
        ' 
        ' Dconnection_TO
        ' 
        Dconnection_TO.Location = New Point(184, 63)
        Dconnection_TO.Name = "Dconnection_TO"
        Dconnection_TO.PlaceholderText = "In seconds"
        Dconnection_TO.Size = New Size(81, 23)
        Dconnection_TO.TabIndex = 3
        Dconnection_TO.TextAlign = HorizontalAlignment.Center
        ToolTip1.SetToolTip(Dconnection_TO, "Time for a data connection to be established before giving up.")
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(13, 66)
        Label4.Name = "Label4"
        Label4.Size = New Size(144, 15)
        Label4.TabIndex = 2
        Label4.Text = "Data Connection Timeout"
        ToolTip1.SetToolTip(Label4, "Time for a data connection to be established before giving up.")
        ' 
        ' connection_TO
        ' 
        connection_TO.Location = New Point(184, 31)
        connection_TO.Name = "connection_TO"
        connection_TO.PlaceholderText = "In seconds"
        connection_TO.Size = New Size(81, 23)
        connection_TO.TabIndex = 1
        connection_TO.TextAlign = HorizontalAlignment.Center
        ToolTip1.SetToolTip(connection_TO, "Time to wait for a connection attempt to succeed before giving up.")
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(13, 34)
        Label3.Name = "Label3"
        Label3.Size = New Size(100, 15)
        Label3.TabIndex = 0
        Label3.Text = "Connect Timeout"
        ToolTip1.SetToolTip(Label3, "Time to wait for a connection attempt to succeed before giving up.")
        ' 
        ' ImageList1
        ' 
        ImageList1.ColorDepth = ColorDepth.Depth32Bit
        ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), ImageListStreamer)
        ImageList1.TransparentColor = Color.Transparent
        ImageList1.Images.SetKeyName(0, "maps-and-flags.png")
        ImageList1.Images.SetKeyName(1, "download(3).png")
        ImageList1.Images.SetKeyName(2, "arrow.png")
        ImageList1.Images.SetKeyName(3, "settings(1).png")
        ImageList1.Images.SetKeyName(4, "link(1).png")
        ' 
        ' FolderBrowserDialog1
        ' 
        FolderBrowserDialog1.Description = "Select your Downloads Directory"
        FolderBrowserDialog1.UseDescriptionForTitle = True
        ' 
        ' Settings
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(650, 409)
        Controls.Add(TabControl1)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Settings"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Settings    -  Nimbus"
        TabControl1.ResumeLayout(False)
        TabPage3.ResumeLayout(False)
        TabPage3.PerformLayout()
        GroupBox8.ResumeLayout(False)
        GroupBox7.ResumeLayout(False)
        GroupBox7.PerformLayout()
        GroupBox4.ResumeLayout(False)
        GroupBox4.PerformLayout()
        TabPage1.ResumeLayout(False)
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox1.ResumeLayout(False)
        TabPage2.ResumeLayout(False)
        TabPage2.PerformLayout()
        GroupBox10.ResumeLayout(False)
        GroupBox10.PerformLayout()
        GroupBox9.ResumeLayout(False)
        GroupBox9.PerformLayout()
        TabPage4.ResumeLayout(False)
        GroupBox6.ResumeLayout(False)
        GroupBox5.ResumeLayout(False)
        GroupBox5.PerformLayout()
        CType(maxretry, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TdataType As ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents up_overwritetype As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DelLFile As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents checkupdate As CheckBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents load_bsc As RadioButton
    Friend WithEvents load_adv As RadioButton
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents connection_TO As TextBox
    Friend WithEvents Dconnection_TO As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents read_TO As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents maxretry As NumericUpDown
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents Enc_Type As ComboBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents getapibtn As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents GeminiAPItxt As TextBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents FileCompareType As ComboBox
    Friend WithEvents savegemapi As Button
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents DownDirtxt As TextBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents remdir As CheckBox
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents DownFileAction As ComboBox
    Friend WithEvents Label10 As Label
End Class
