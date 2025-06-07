<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangePermission
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChangePermission))
        GroupBox1 = New GroupBox()
        chkOwnerExecute = New CheckBox()
        chkOwnerWrite = New CheckBox()
        chkOwnerRead = New CheckBox()
        GroupBox2 = New GroupBox()
        chkGroupExecute = New CheckBox()
        chkGroupWrite = New CheckBox()
        chkGroupRead = New CheckBox()
        GroupBox3 = New GroupBox()
        chkOtherExecute = New CheckBox()
        chkOtherWrite = New CheckBox()
        chkOtherRead = New CheckBox()
        GroupBox1.SuspendLayout()
        GroupBox2.SuspendLayout()
        GroupBox3.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(chkOwnerExecute)
        GroupBox1.Controls.Add(chkOwnerWrite)
        GroupBox1.Controls.Add(chkOwnerRead)
        GroupBox1.Location = New Point(12, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(297, 68)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Owner"
        ' 
        ' chkOwnerExecute
        ' 
        chkOwnerExecute.AutoSize = True
        chkOwnerExecute.Location = New Point(203, 33)
        chkOwnerExecute.Name = "chkOwnerExecute"
        chkOwnerExecute.Size = New Size(66, 19)
        chkOwnerExecute.TabIndex = 2
        chkOwnerExecute.Text = "Execute"
        chkOwnerExecute.UseVisualStyleBackColor = True
        ' 
        ' chkOwnerWrite
        ' 
        chkOwnerWrite.AutoSize = True
        chkOwnerWrite.Location = New Point(113, 33)
        chkOwnerWrite.Name = "chkOwnerWrite"
        chkOwnerWrite.Size = New Size(54, 19)
        chkOwnerWrite.TabIndex = 1
        chkOwnerWrite.Text = "Write"
        chkOwnerWrite.UseVisualStyleBackColor = True
        ' 
        ' chkOwnerRead
        ' 
        chkOwnerRead.AutoSize = True
        chkOwnerRead.Location = New Point(23, 33)
        chkOwnerRead.Name = "chkOwnerRead"
        chkOwnerRead.Size = New Size(52, 19)
        chkOwnerRead.TabIndex = 0
        chkOwnerRead.Text = "Read"
        chkOwnerRead.UseVisualStyleBackColor = True
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(chkGroupExecute)
        GroupBox2.Controls.Add(chkGroupWrite)
        GroupBox2.Controls.Add(chkGroupRead)
        GroupBox2.Location = New Point(12, 88)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(297, 68)
        GroupBox2.TabIndex = 3
        GroupBox2.TabStop = False
        GroupBox2.Text = "Group"
        ' 
        ' chkGroupExecute
        ' 
        chkGroupExecute.AutoSize = True
        chkGroupExecute.Location = New Point(203, 33)
        chkGroupExecute.Name = "chkGroupExecute"
        chkGroupExecute.Size = New Size(66, 19)
        chkGroupExecute.TabIndex = 2
        chkGroupExecute.Text = "Execute"
        chkGroupExecute.UseVisualStyleBackColor = True
        ' 
        ' chkGroupWrite
        ' 
        chkGroupWrite.AutoSize = True
        chkGroupWrite.Location = New Point(113, 33)
        chkGroupWrite.Name = "chkGroupWrite"
        chkGroupWrite.Size = New Size(54, 19)
        chkGroupWrite.TabIndex = 1
        chkGroupWrite.Text = "Write"
        chkGroupWrite.UseVisualStyleBackColor = True
        ' 
        ' chkGroupRead
        ' 
        chkGroupRead.AutoSize = True
        chkGroupRead.Location = New Point(23, 33)
        chkGroupRead.Name = "chkGroupRead"
        chkGroupRead.Size = New Size(52, 19)
        chkGroupRead.TabIndex = 0
        chkGroupRead.Text = "Read"
        chkGroupRead.UseVisualStyleBackColor = True
        ' 
        ' GroupBox3
        ' 
        GroupBox3.Controls.Add(chkOtherExecute)
        GroupBox3.Controls.Add(chkOtherWrite)
        GroupBox3.Controls.Add(chkOtherRead)
        GroupBox3.Location = New Point(12, 164)
        GroupBox3.Name = "GroupBox3"
        GroupBox3.Size = New Size(297, 68)
        GroupBox3.TabIndex = 4
        GroupBox3.TabStop = False
        GroupBox3.Text = "User"
        ' 
        ' chkOtherExecute
        ' 
        chkOtherExecute.AutoSize = True
        chkOtherExecute.Location = New Point(203, 33)
        chkOtherExecute.Name = "chkOtherExecute"
        chkOtherExecute.Size = New Size(66, 19)
        chkOtherExecute.TabIndex = 2
        chkOtherExecute.Text = "Execute"
        chkOtherExecute.UseVisualStyleBackColor = True
        ' 
        ' chkOtherWrite
        ' 
        chkOtherWrite.AutoSize = True
        chkOtherWrite.Location = New Point(113, 33)
        chkOtherWrite.Name = "chkOtherWrite"
        chkOtherWrite.Size = New Size(54, 19)
        chkOtherWrite.TabIndex = 1
        chkOtherWrite.Text = "Write"
        chkOtherWrite.UseVisualStyleBackColor = True
        ' 
        ' chkOtherRead
        ' 
        chkOtherRead.AutoSize = True
        chkOtherRead.Location = New Point(23, 33)
        chkOtherRead.Name = "chkOtherRead"
        chkOtherRead.Size = New Size(52, 19)
        chkOtherRead.TabIndex = 0
        chkOtherRead.Text = "Read"
        chkOtherRead.UseVisualStyleBackColor = True
        ' 
        ' ChangePermission
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(321, 248)
        Controls.Add(GroupBox3)
        Controls.Add(GroupBox2)
        Controls.Add(GroupBox1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "ChangePermission"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "Change Permission"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        GroupBox3.ResumeLayout(False)
        GroupBox3.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chkOwnerRead As CheckBox
    Friend WithEvents chkOwnerExecute As CheckBox
    Friend WithEvents chkOwnerWrite As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkGroupExecute As CheckBox
    Friend WithEvents chkGroupWrite As CheckBox
    Friend WithEvents chkGroupRead As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents chkOtherExecute As CheckBox
    Friend WithEvents chkOtherWrite As CheckBox
    Friend WithEvents chkOtherRead As CheckBox
End Class
