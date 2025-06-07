<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        MenuStrip1 = New MenuStrip()
        ToolStripMenuItem1 = New ToolStripMenuItem()
        ToolStripMenuItem2 = New ToolStripMenuItem()
        ToolStripMenuItem3 = New ToolStripMenuItem()
        OptionsToolStripMenuItem = New ToolStripMenuItem()
        ToolStripMenuItem7 = New ToolStripMenuItem()
        ToolStripMenuItem9 = New ToolStripMenuItem()
        ToolStripMenuItem8 = New ToolStripMenuItem()
        NimbusToolStripMenuItem = New ToolStripMenuItem()
        FileSearcherToolStripMenuItem = New ToolStripMenuItem()
        NEditorToolStripMenuItem = New ToolStripMenuItem()
        AboutToolStripMenuItem = New ToolStripMenuItem()
        ReportBugToolStripMenuItem = New ToolStripMenuItem()
        CreditsToolStripMenuItem = New ToolStripMenuItem()
        AboutNimbusToolStripMenuItem = New ToolStripMenuItem()
        ToolStrip1 = New ToolStrip()
        ToolStripLabel1 = New ToolStripLabel()
        ToolStripButton3 = New ToolStripButton()
        ToolStripButton2 = New ToolStripButton()
        servername = New ToolStripLabel()
        ToolStripSeparator1 = New ToolStripSeparator()
        pauseresume_upload = New ToolStripButton()
        cancel_upload = New ToolStripButton()
        ToolStripSeparator2 = New ToolStripSeparator()
        ToolStripButton1 = New ToolStripButton()
        SplitContainer1 = New SplitContainer()
        ftpfiles = New ListView()
        ColumnHeader1 = New ColumnHeader()
        ColumnHeader2 = New ColumnHeader()
        ColumnHeader3 = New ColumnHeader()
        ColumnHeader4 = New ColumnHeader()
        ColumnHeader5 = New ColumnHeader()
        FtpFiles_CM = New ContextMenuStrip(components)
        ToolStripMenuItem10 = New ToolStripMenuItem()
        ToolStripMenuItem11 = New ToolStripMenuItem()
        ToolStripMenuItem12 = New ToolStripMenuItem()
        ToolStripMenuItem13 = New ToolStripMenuItem()
        CompareFileToolStripMenuItem = New ToolStripMenuItem()
        ToolStripSeparator6 = New ToolStripSeparator()
        ToolStripMenuItem14 = New ToolStripMenuItem()
        ToolStripMenuItem15 = New ToolStripMenuItem()
        ToolStripMenuItem16 = New ToolStripMenuItem()
        ToolStripMenuItem17 = New ToolStripMenuItem()
        ToolStripSeparator7 = New ToolStripSeparator()
        ToolStripMenuItem18 = New ToolStripMenuItem()
        ToolStripMenuItem19 = New ToolStripMenuItem()
        ToolStripMenuItem20 = New ToolStripMenuItem()
        ImageList2 = New ImageList(components)
        GroupBox1 = New GroupBox()
        Dirs = New TreeView()
        Dirs_CM = New ContextMenuStrip(components)
        ToolStripMenuItem4 = New ToolStripMenuItem()
        ToolStripMenuItem5 = New ToolStripMenuItem()
        ToolStripMenuItem6 = New ToolStripMenuItem()
        download_dirTS = New ToolStripMenuItem()
        ToolStripSeparator5 = New ToolStripSeparator()
        createdir_TS = New ToolStripMenuItem()
        getfiles_TS = New ToolStripMenuItem()
        copyname_TS = New ToolStripMenuItem()
        ToolStripSeparator3 = New ToolStripSeparator()
        RefreshDirectoriesToolStripMenuItem = New ToolStripMenuItem()
        rename_TS = New ToolStripMenuItem()
        changeperm_TS = New ToolStripMenuItem()
        ToolStripSeparator4 = New ToolStripSeparator()
        delete_TS = New ToolStripMenuItem()
        ImageList1 = New ImageList(components)
        upfileslist = New ListView()
        ColumnHeader6 = New ColumnHeader()
        ColumnHeader7 = New ColumnHeader()
        ColumnHeader8 = New ColumnHeader()
        ColumnHeader9 = New ColumnHeader()
        ColumnHeader10 = New ColumnHeader()
        ImageList3 = New ImageList(components)
        StatusStrip1 = New StatusStrip()
        stslbl = New ToolStripStatusLabel()
        sts_pb = New ToolStripProgressBar()
        speedtime = New ToolStripStatusLabel()
        FolderBrowserDialog1 = New FolderBrowserDialog()
        OpenFileDialog1 = New OpenFileDialog()
        NotIcon = New NotifyIcon(components)
        DownloadFolderDlg = New FolderBrowserDialog()
        MenuStrip1.SuspendLayout()
        ToolStrip1.SuspendLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        FtpFiles_CM.SuspendLayout()
        GroupBox1.SuspendLayout()
        Dirs_CM.SuspendLayout()
        StatusStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.BackColor = Color.White
        MenuStrip1.Items.AddRange(New ToolStripItem() {ToolStripMenuItem1, OptionsToolStripMenuItem, NimbusToolStripMenuItem, AboutToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1104, 24)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.DropDownItems.AddRange(New ToolStripItem() {ToolStripMenuItem2, ToolStripMenuItem3})
        ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), Image)
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(78, 20)
        ToolStripMenuItem1.Text = "Uploads"
        ' 
        ' ToolStripMenuItem2
        ' 
        ToolStripMenuItem2.BackColor = Color.White
        ToolStripMenuItem2.Image = My.Resources.NimbusResources.upload_file
        ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        ToolStripMenuItem2.Size = New Size(180, 22)
        ToolStripMenuItem2.Text = "Upload File(s)"
        ' 
        ' ToolStripMenuItem3
        ' 
        ToolStripMenuItem3.BackColor = Color.White
        ToolStripMenuItem3.Image = My.Resources.NimbusResources.folder
        ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        ToolStripMenuItem3.Size = New Size(180, 22)
        ToolStripMenuItem3.Text = "Upload Folder"
        ' 
        ' OptionsToolStripMenuItem
        ' 
        OptionsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ToolStripMenuItem7, ToolStripMenuItem9, ToolStripMenuItem8})
        OptionsToolStripMenuItem.Image = CType(resources.GetObject("OptionsToolStripMenuItem.Image"), Image)
        OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        OptionsToolStripMenuItem.Size = New Size(77, 20)
        OptionsToolStripMenuItem.Text = "Options"
        ' 
        ' ToolStripMenuItem7
        ' 
        ToolStripMenuItem7.Image = CType(resources.GetObject("ToolStripMenuItem7.Image"), Image)
        ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        ToolStripMenuItem7.Size = New Size(180, 22)
        ToolStripMenuItem7.Text = "Nimbus Profile"
        ' 
        ' ToolStripMenuItem9
        ' 
        ToolStripMenuItem9.Image = CType(resources.GetObject("ToolStripMenuItem9.Image"), Image)
        ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        ToolStripMenuItem9.Size = New Size(180, 22)
        ToolStripMenuItem9.Text = "Open Logs"
        ' 
        ' ToolStripMenuItem8
        ' 
        ToolStripMenuItem8.Image = CType(resources.GetObject("ToolStripMenuItem8.Image"), Image)
        ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        ToolStripMenuItem8.Size = New Size(180, 22)
        ToolStripMenuItem8.Text = "Settings"
        ' 
        ' NimbusToolStripMenuItem
        ' 
        NimbusToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {FileSearcherToolStripMenuItem, NEditorToolStripMenuItem})
        NimbusToolStripMenuItem.Image = CType(resources.GetObject("NimbusToolStripMenuItem.Image"), Image)
        NimbusToolStripMenuItem.Name = "NimbusToolStripMenuItem"
        NimbusToolStripMenuItem.Size = New Size(63, 20)
        NimbusToolStripMenuItem.Text = "Tools"
        ' 
        ' FileSearcherToolStripMenuItem
        ' 
        FileSearcherToolStripMenuItem.Image = CType(resources.GetObject("FileSearcherToolStripMenuItem.Image"), Image)
        FileSearcherToolStripMenuItem.Name = "FileSearcherToolStripMenuItem"
        FileSearcherToolStripMenuItem.Size = New Size(180, 22)
        FileSearcherToolStripMenuItem.Text = "File Searcher"
        ' 
        ' NEditorToolStripMenuItem
        ' 
        NEditorToolStripMenuItem.Image = CType(resources.GetObject("NEditorToolStripMenuItem.Image"), Image)
        NEditorToolStripMenuItem.Name = "NEditorToolStripMenuItem"
        NEditorToolStripMenuItem.Size = New Size(180, 22)
        NEditorToolStripMenuItem.Text = "N Editor"
        NEditorToolStripMenuItem.ToolTipText = "Nimbus Code Editor with Gemini AI"
        ' 
        ' AboutToolStripMenuItem
        ' 
        AboutToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ReportBugToolStripMenuItem, CreditsToolStripMenuItem, AboutNimbusToolStripMenuItem})
        AboutToolStripMenuItem.Image = CType(resources.GetObject("AboutToolStripMenuItem.Image"), Image)
        AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        AboutToolStripMenuItem.Size = New Size(68, 20)
        AboutToolStripMenuItem.Text = "About"
        ' 
        ' ReportBugToolStripMenuItem
        ' 
        ReportBugToolStripMenuItem.Image = CType(resources.GetObject("ReportBugToolStripMenuItem.Image"), Image)
        ReportBugToolStripMenuItem.Name = "ReportBugToolStripMenuItem"
        ReportBugToolStripMenuItem.Size = New Size(180, 22)
        ReportBugToolStripMenuItem.Text = "Report Bug"
        ' 
        ' CreditsToolStripMenuItem
        ' 
        CreditsToolStripMenuItem.Image = CType(resources.GetObject("CreditsToolStripMenuItem.Image"), Image)
        CreditsToolStripMenuItem.Name = "CreditsToolStripMenuItem"
        CreditsToolStripMenuItem.Size = New Size(180, 22)
        CreditsToolStripMenuItem.Text = "Credits"
        ' 
        ' AboutNimbusToolStripMenuItem
        ' 
        AboutNimbusToolStripMenuItem.Image = CType(resources.GetObject("AboutNimbusToolStripMenuItem.Image"), Image)
        AboutNimbusToolStripMenuItem.Name = "AboutNimbusToolStripMenuItem"
        AboutNimbusToolStripMenuItem.Size = New Size(180, 22)
        AboutNimbusToolStripMenuItem.Text = "About Nimbus"
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.BackColor = Color.White
        ToolStrip1.Items.AddRange(New ToolStripItem() {ToolStripLabel1, ToolStripButton3, ToolStripButton2, servername, ToolStripSeparator1, pauseresume_upload, cancel_upload, ToolStripSeparator2, ToolStripButton1})
        ToolStrip1.Location = New Point(0, 24)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(1104, 25)
        ToolStrip1.TabIndex = 1
        ToolStrip1.Text = "ToolStrip1"
        ' 
        ' ToolStripLabel1
        ' 
        ToolStripLabel1.Name = "ToolStripLabel1"
        ToolStripLabel1.Size = New Size(66, 22)
        ToolStripLabel1.Text = "Directories:"
        ' 
        ' ToolStripButton3
        ' 
        ToolStripButton3.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton3.Image = My.Resources.NimbusResources.folder_4_
        ToolStripButton3.ImageTransparentColor = Color.Magenta
        ToolStripButton3.Name = "ToolStripButton3"
        ToolStripButton3.Size = New Size(23, 22)
        ToolStripButton3.Text = "Refresh Directories"
        ' 
        ' ToolStripButton2
        ' 
        ToolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton2.Image = My.Resources.NimbusResources.refresh_1_
        ToolStripButton2.ImageTransparentColor = Color.Magenta
        ToolStripButton2.Name = "ToolStripButton2"
        ToolStripButton2.Size = New Size(23, 22)
        ToolStripButton2.Text = "Refresh Files"
        ' 
        ' servername
        ' 
        servername.Alignment = ToolStripItemAlignment.Right
        servername.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        servername.Image = My.Resources.NimbusResources.link_3_
        servername.Name = "servername"
        servername.Size = New Size(32, 22)
        servername.Text = "..."
        ' 
        ' ToolStripSeparator1
        ' 
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New Size(6, 25)
        ' 
        ' pauseresume_upload
        ' 
        pauseresume_upload.DisplayStyle = ToolStripItemDisplayStyle.Image
        pauseresume_upload.Enabled = False
        pauseresume_upload.Image = My.Resources.NimbusResources.pause_2_
        pauseresume_upload.ImageTransparentColor = Color.Magenta
        pauseresume_upload.Name = "pauseresume_upload"
        pauseresume_upload.Size = New Size(23, 22)
        pauseresume_upload.Text = "Pause Upload"
        ' 
        ' cancel_upload
        ' 
        cancel_upload.DisplayStyle = ToolStripItemDisplayStyle.Image
        cancel_upload.Enabled = False
        cancel_upload.Image = CType(resources.GetObject("cancel_upload.Image"), Image)
        cancel_upload.ImageTransparentColor = Color.Magenta
        cancel_upload.Name = "cancel_upload"
        cancel_upload.Size = New Size(23, 22)
        cancel_upload.Text = "Cancel Upload"
        ' 
        ' ToolStripSeparator2
        ' 
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New Size(6, 25)
        ' 
        ' ToolStripButton1
        ' 
        ToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton1.Image = My.Resources.NimbusResources.information_7_
        ToolStripButton1.ImageTransparentColor = Color.Magenta
        ToolStripButton1.Name = "ToolStripButton1"
        ToolStripButton1.Size = New Size(23, 22)
        ToolStripButton1.Text = "View/Hide Uploading Information Panel"
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.FixedPanel = FixedPanel.Panel2
        SplitContainer1.Location = New Point(0, 49)
        SplitContainer1.Name = "SplitContainer1"
        SplitContainer1.Orientation = Orientation.Horizontal
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(ftpfiles)
        SplitContainer1.Panel1.Controls.Add(GroupBox1)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(upfileslist)
        SplitContainer1.Size = New Size(1104, 548)
        SplitContainer1.SplitterDistance = 391
        SplitContainer1.TabIndex = 2
        ' 
        ' ftpfiles
        ' 
        ftpfiles.BorderStyle = BorderStyle.None
        ftpfiles.Columns.AddRange(New ColumnHeader() {ColumnHeader1, ColumnHeader2, ColumnHeader3, ColumnHeader4, ColumnHeader5})
        ftpfiles.ContextMenuStrip = FtpFiles_CM
        ftpfiles.Dock = DockStyle.Fill
        ftpfiles.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ftpfiles.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        ftpfiles.FullRowSelect = True
        ftpfiles.Location = New Point(216, 0)
        ftpfiles.Name = "ftpfiles"
        ftpfiles.ShowGroups = False
        ftpfiles.Size = New Size(888, 391)
        ftpfiles.SmallImageList = ImageList2
        ftpfiles.TabIndex = 4
        ftpfiles.UseCompatibleStateImageBehavior = False
        ftpfiles.View = View.Details
        ' 
        ' ColumnHeader1
        ' 
        ColumnHeader1.Text = "Filename"
        ColumnHeader1.Width = 200
        ' 
        ' ColumnHeader2
        ' 
        ColumnHeader2.Text = "Size"
        ColumnHeader2.TextAlign = HorizontalAlignment.Center
        ColumnHeader2.Width = 80
        ' 
        ' ColumnHeader3
        ' 
        ColumnHeader3.Text = "Created on"
        ColumnHeader3.TextAlign = HorizontalAlignment.Center
        ColumnHeader3.Width = 100
        ' 
        ' ColumnHeader4
        ' 
        ColumnHeader4.Text = "Last Modified"
        ColumnHeader4.TextAlign = HorizontalAlignment.Center
        ColumnHeader4.Width = 100
        ' 
        ' ColumnHeader5
        ' 
        ColumnHeader5.Text = "Permission"
        ColumnHeader5.TextAlign = HorizontalAlignment.Center
        ColumnHeader5.Width = 100
        ' 
        ' FtpFiles_CM
        ' 
        FtpFiles_CM.Items.AddRange(New ToolStripItem() {ToolStripMenuItem10, ToolStripMenuItem11, CompareFileToolStripMenuItem, ToolStripSeparator6, ToolStripMenuItem14, ToolStripMenuItem15, ToolStripMenuItem16, ToolStripMenuItem17, ToolStripSeparator7, ToolStripMenuItem18, ToolStripMenuItem19, ToolStripMenuItem20})
        FtpFiles_CM.Name = "FtpFiles_CM"
        FtpFiles_CM.Size = New Size(182, 236)
        ' 
        ' ToolStripMenuItem10
        ' 
        ToolStripMenuItem10.Image = My.Resources.NimbusResources.cloud_computing_1_
        ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        ToolStripMenuItem10.Size = New Size(181, 22)
        ToolStripMenuItem10.Text = "Download File"
        ' 
        ' ToolStripMenuItem11
        ' 
        ToolStripMenuItem11.DropDownItems.AddRange(New ToolStripItem() {ToolStripMenuItem12, ToolStripMenuItem13})
        ToolStripMenuItem11.Image = My.Resources.NimbusResources.copy
        ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        ToolStripMenuItem11.Size = New Size(181, 22)
        ToolStripMenuItem11.Text = "Copy"
        ' 
        ' ToolStripMenuItem12
        ' 
        ToolStripMenuItem12.Image = My.Resources.NimbusResources.document_1_
        ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        ToolStripMenuItem12.Size = New Size(160, 22)
        ToolStripMenuItem12.Text = "File Name"
        ' 
        ' ToolStripMenuItem13
        ' 
        ToolStripMenuItem13.Image = My.Resources.NimbusResources.url
        ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        ToolStripMenuItem13.Size = New Size(160, 22)
        ToolStripMenuItem13.Text = "Remote Address"
        ' 
        ' CompareFileToolStripMenuItem
        ' 
        CompareFileToolStripMenuItem.Image = CType(resources.GetObject("CompareFileToolStripMenuItem.Image"), Image)
        CompareFileToolStripMenuItem.Name = "CompareFileToolStripMenuItem"
        CompareFileToolStripMenuItem.Size = New Size(181, 22)
        CompareFileToolStripMenuItem.Text = "Compare File"
        ' 
        ' ToolStripSeparator6
        ' 
        ToolStripSeparator6.Name = "ToolStripSeparator6"
        ToolStripSeparator6.Size = New Size(178, 6)
        ' 
        ' ToolStripMenuItem14
        ' 
        ToolStripMenuItem14.Image = My.Resources.NimbusResources.duplicate
        ToolStripMenuItem14.Name = "ToolStripMenuItem14"
        ToolStripMenuItem14.Size = New Size(181, 22)
        ToolStripMenuItem14.Text = "Duplicate File"
        ' 
        ' ToolStripMenuItem15
        ' 
        ToolStripMenuItem15.Image = My.Resources.NimbusResources.editing
        ToolStripMenuItem15.Name = "ToolStripMenuItem15"
        ToolStripMenuItem15.Size = New Size(181, 22)
        ToolStripMenuItem15.Text = "Edit File"
        ' 
        ' ToolStripMenuItem16
        ' 
        ToolStripMenuItem16.Image = My.Resources.NimbusResources.new_document_1_
        ToolStripMenuItem16.Name = "ToolStripMenuItem16"
        ToolStripMenuItem16.Size = New Size(181, 22)
        ToolStripMenuItem16.Text = "Create New File"
        ' 
        ' ToolStripMenuItem17
        ' 
        ToolStripMenuItem17.Image = My.Resources.NimbusResources.document_2_
        ToolStripMenuItem17.Name = "ToolStripMenuItem17"
        ToolStripMenuItem17.Size = New Size(181, 22)
        ToolStripMenuItem17.Text = "Refresh Files"
        ' 
        ' ToolStripSeparator7
        ' 
        ToolStripSeparator7.Name = "ToolStripSeparator7"
        ToolStripSeparator7.Size = New Size(178, 6)
        ' 
        ' ToolStripMenuItem18
        ' 
        ToolStripMenuItem18.Image = My.Resources.NimbusResources.edit
        ToolStripMenuItem18.Name = "ToolStripMenuItem18"
        ToolStripMenuItem18.Size = New Size(181, 22)
        ToolStripMenuItem18.Text = "Rename"
        ' 
        ' ToolStripMenuItem19
        ' 
        ToolStripMenuItem19.Image = My.Resources.NimbusResources.user_1_
        ToolStripMenuItem19.Name = "ToolStripMenuItem19"
        ToolStripMenuItem19.Size = New Size(181, 22)
        ToolStripMenuItem19.Text = "Change Permissions"
        ' 
        ' ToolStripMenuItem20
        ' 
        ToolStripMenuItem20.Image = My.Resources.NimbusResources.delete
        ToolStripMenuItem20.Name = "ToolStripMenuItem20"
        ToolStripMenuItem20.Size = New Size(181, 22)
        ToolStripMenuItem20.Text = "Delete"
        ' 
        ' ImageList2
        ' 
        ImageList2.ColorDepth = ColorDepth.Depth32Bit
        ImageList2.ImageSize = New Size(16, 16)
        ImageList2.TransparentColor = Color.Transparent
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(Dirs)
        GroupBox1.Dock = DockStyle.Left
        GroupBox1.Location = New Point(0, 0)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(216, 391)
        GroupBox1.TabIndex = 3
        GroupBox1.TabStop = False
        GroupBox1.Text = "Directories"
        ' 
        ' Dirs
        ' 
        Dirs.BorderStyle = BorderStyle.None
        Dirs.ContextMenuStrip = Dirs_CM
        Dirs.Dock = DockStyle.Fill
        Dirs.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Dirs.ForeColor = Color.FromArgb(CByte(40), CByte(40), CByte(40))
        Dirs.FullRowSelect = True
        Dirs.ImageIndex = 1
        Dirs.ImageList = ImageList1
        Dirs.Location = New Point(3, 19)
        Dirs.Name = "Dirs"
        Dirs.SelectedImageIndex = 0
        Dirs.ShowLines = False
        Dirs.Size = New Size(210, 369)
        Dirs.TabIndex = 4
        ' 
        ' Dirs_CM
        ' 
        Dirs_CM.Items.AddRange(New ToolStripItem() {ToolStripMenuItem4, download_dirTS, ToolStripSeparator5, createdir_TS, getfiles_TS, copyname_TS, ToolStripSeparator3, RefreshDirectoriesToolStripMenuItem, rename_TS, changeperm_TS, ToolStripSeparator4, delete_TS})
        Dirs_CM.Name = "ContextMenuStrip1"
        Dirs_CM.Size = New Size(190, 220)
        ' 
        ' ToolStripMenuItem4
        ' 
        ToolStripMenuItem4.DropDownItems.AddRange(New ToolStripItem() {ToolStripMenuItem5, ToolStripMenuItem6})
        ToolStripMenuItem4.Image = My.Resources.NimbusResources.upload_file1
        ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        ToolStripMenuItem4.Size = New Size(189, 22)
        ToolStripMenuItem4.Text = "Uploads"
        ' 
        ' ToolStripMenuItem5
        ' 
        ToolStripMenuItem5.Image = My.Resources.NimbusResources.paper_sizes
        ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        ToolStripMenuItem5.Size = New Size(148, 22)
        ToolStripMenuItem5.Text = "Upload File(s)"
        ' 
        ' ToolStripMenuItem6
        ' 
        ToolStripMenuItem6.Image = My.Resources.NimbusResources.folder
        ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        ToolStripMenuItem6.Size = New Size(148, 22)
        ToolStripMenuItem6.Text = "Upload Folder"
        ' 
        ' download_dirTS
        ' 
        download_dirTS.Image = CType(resources.GetObject("download_dirTS.Image"), Image)
        download_dirTS.Name = "download_dirTS"
        download_dirTS.Size = New Size(189, 22)
        download_dirTS.Text = "Download Directory"
        ' 
        ' ToolStripSeparator5
        ' 
        ToolStripSeparator5.Name = "ToolStripSeparator5"
        ToolStripSeparator5.Size = New Size(186, 6)
        ' 
        ' createdir_TS
        ' 
        createdir_TS.Image = My.Resources.NimbusResources.add_folder
        createdir_TS.Name = "createdir_TS"
        createdir_TS.Size = New Size(189, 22)
        createdir_TS.Text = "Create New Directory"
        ' 
        ' getfiles_TS
        ' 
        getfiles_TS.Image = My.Resources.NimbusResources.document
        getfiles_TS.Name = "getfiles_TS"
        getfiles_TS.Size = New Size(189, 22)
        getfiles_TS.Text = "Get Files"
        ' 
        ' copyname_TS
        ' 
        copyname_TS.Image = My.Resources.NimbusResources.copy1
        copyname_TS.Name = "copyname_TS"
        copyname_TS.Size = New Size(189, 22)
        copyname_TS.Text = "Copy Name"
        ' 
        ' ToolStripSeparator3
        ' 
        ToolStripSeparator3.Name = "ToolStripSeparator3"
        ToolStripSeparator3.Size = New Size(186, 6)
        ' 
        ' RefreshDirectoriesToolStripMenuItem
        ' 
        RefreshDirectoriesToolStripMenuItem.Image = My.Resources.NimbusResources.folder_4_
        RefreshDirectoriesToolStripMenuItem.Name = "RefreshDirectoriesToolStripMenuItem"
        RefreshDirectoriesToolStripMenuItem.Size = New Size(189, 22)
        RefreshDirectoriesToolStripMenuItem.Text = "Refresh Directories"
        ' 
        ' rename_TS
        ' 
        rename_TS.Image = My.Resources.NimbusResources.rename
        rename_TS.Name = "rename_TS"
        rename_TS.Size = New Size(189, 22)
        rename_TS.Text = "Rename Directory"
        ' 
        ' changeperm_TS
        ' 
        changeperm_TS.Image = My.Resources.NimbusResources.user_1_
        changeperm_TS.Name = "changeperm_TS"
        changeperm_TS.Size = New Size(189, 22)
        changeperm_TS.Text = "Change Permission(s)"
        ' 
        ' ToolStripSeparator4
        ' 
        ToolStripSeparator4.Name = "ToolStripSeparator4"
        ToolStripSeparator4.Size = New Size(186, 6)
        ' 
        ' delete_TS
        ' 
        delete_TS.Image = My.Resources.NimbusResources.delete
        delete_TS.Name = "delete_TS"
        delete_TS.Size = New Size(189, 22)
        delete_TS.Text = "Delete Directory"
        ' 
        ' ImageList1
        ' 
        ImageList1.ColorDepth = ColorDepth.Depth32Bit
        ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), ImageListStreamer)
        ImageList1.TransparentColor = Color.Transparent
        ImageList1.Images.SetKeyName(0, "folder.png")
        ImageList1.Images.SetKeyName(1, "folder(1).png")
        ImageList1.Images.SetKeyName(2, "folder(2).png")
        ImageList1.Images.SetKeyName(3, "folder(3).png")
        ImageList1.Images.SetKeyName(4, "paper-sizes.png")
        ImageList1.Images.SetKeyName(5, "file(1).png")
        ImageList1.Images.SetKeyName(6, "folder(4).png")
        ImageList1.Images.SetKeyName(7, "check(4).png")
        ' 
        ' upfileslist
        ' 
        upfileslist.Columns.AddRange(New ColumnHeader() {ColumnHeader6, ColumnHeader7, ColumnHeader8, ColumnHeader9, ColumnHeader10})
        upfileslist.Dock = DockStyle.Fill
        upfileslist.FullRowSelect = True
        upfileslist.Location = New Point(0, 0)
        upfileslist.MultiSelect = False
        upfileslist.Name = "upfileslist"
        upfileslist.Size = New Size(1104, 153)
        upfileslist.SmallImageList = ImageList3
        upfileslist.TabIndex = 0
        upfileslist.UseCompatibleStateImageBehavior = False
        upfileslist.View = View.Details
        ' 
        ' ColumnHeader6
        ' 
        ColumnHeader6.Text = "Filename"
        ColumnHeader6.Width = 300
        ' 
        ' ColumnHeader7
        ' 
        ColumnHeader7.Text = "Size"
        ColumnHeader7.TextAlign = HorizontalAlignment.Center
        ColumnHeader7.Width = 100
        ' 
        ' ColumnHeader8
        ' 
        ColumnHeader8.Text = "In Directory"
        ColumnHeader8.TextAlign = HorizontalAlignment.Center
        ColumnHeader8.Width = 200
        ' 
        ' ColumnHeader9
        ' 
        ColumnHeader9.Text = "Progress"
        ColumnHeader9.TextAlign = HorizontalAlignment.Center
        ColumnHeader9.Width = 80
        ' 
        ' ColumnHeader10
        ' 
        ColumnHeader10.Text = "Status"
        ColumnHeader10.TextAlign = HorizontalAlignment.Center
        ColumnHeader10.Width = 100
        ' 
        ' ImageList3
        ' 
        ImageList3.ColorDepth = ColorDepth.Depth32Bit
        ImageList3.ImageStream = CType(resources.GetObject("ImageList3.ImageStream"), ImageListStreamer)
        ImageList3.TransparentColor = Color.Transparent
        ImageList3.Images.SetKeyName(0, "upload-file.png")
        ImageList3.Images.SetKeyName(1, "cloud-computing.png")
        ImageList3.Images.SetKeyName(2, "cross(1).png")
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.BackColor = Color.White
        StatusStrip1.Items.AddRange(New ToolStripItem() {stslbl, sts_pb, speedtime})
        StatusStrip1.Location = New Point(0, 597)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(1104, 22)
        StatusStrip1.TabIndex = 3
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' stslbl
        ' 
        stslbl.Image = My.Resources.NimbusResources.sleep
        stslbl.Name = "stslbl"
        stslbl.Size = New Size(66, 17)
        stslbl.Text = "I'm IDLE"
        ' 
        ' sts_pb
        ' 
        sts_pb.MarqueeAnimationSpeed = 20
        sts_pb.Name = "sts_pb"
        sts_pb.Size = New Size(150, 16)
        sts_pb.Visible = False
        ' 
        ' speedtime
        ' 
        speedtime.Name = "speedtime"
        speedtime.Size = New Size(16, 17)
        speedtime.Text = "..."
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.Multiselect = True
        OpenFileDialog1.Title = "Select file(s) to upload"
        ' 
        ' NotIcon
        ' 
        NotIcon.Icon = CType(resources.GetObject("NotIcon.Icon"), Icon)
        NotIcon.Text = "Nimbus"
        NotIcon.Visible = True
        ' 
        ' DownloadFolderDlg
        ' 
        DownloadFolderDlg.Description = "Select path to download folder"
        DownloadFolderDlg.UseDescriptionForTitle = True
        ' 
        ' MainForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(1104, 619)
        Controls.Add(SplitContainer1)
        Controls.Add(ToolStrip1)
        Controls.Add(MenuStrip1)
        Controls.Add(StatusStrip1)
        DoubleBuffered = True
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = MenuStrip1
        Name = "MainForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Nimbus"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        FtpFiles_CM.ResumeLayout(False)
        GroupBox1.ResumeLayout(False)
        Dirs_CM.ResumeLayout(False)
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents servername As ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents Dirs As TreeView
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents ftpfiles As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents Dirs_CM As ContextMenuStrip
    Friend WithEvents getfiles_TS As ToolStripMenuItem
    Friend WithEvents copyname_TS As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents rename_TS As ToolStripMenuItem
    Friend WithEvents changeperm_TS As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents delete_TS As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents stslbl As ToolStripStatusLabel
    Friend WithEvents sts_pb As ToolStripProgressBar
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents createdir_TS As ToolStripMenuItem
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents upfileslist As ListView
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
    Friend WithEvents ColumnHeader10 As ColumnHeader
    Friend WithEvents ImageList3 As ImageList
    Friend WithEvents speedtime As ToolStripStatusLabel
    Friend WithEvents NotIcon As NotifyIcon
    Friend WithEvents pauseresume_upload As ToolStripButton
    Friend WithEvents cancel_upload As ToolStripButton
    Friend WithEvents RefreshDirectoriesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem5 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As ToolStripMenuItem
    Friend WithEvents download_dirTS As ToolStripMenuItem
    Friend WithEvents DownloadFolderDlg As FolderBrowserDialog
    Friend WithEvents FtpFiles_CM As ContextMenuStrip
    Friend WithEvents ToolStripMenuItem10 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem12 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem13 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem14 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem15 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem16 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem17 As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItem18 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem19 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem20 As ToolStripMenuItem
    Friend WithEvents NimbusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FileSearcherToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CompareFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NEditorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreditsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutNimbusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportBugToolStripMenuItem As ToolStripMenuItem
End Class
