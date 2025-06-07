<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CertCheckup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CertCheckup))
        GroupBox1 = New GroupBox()
        Button2 = New Button()
        Button1 = New Button()
        trustcertCB = New CheckBox()
        errormsg = New Label()
        Label2 = New Label()
        lblThumbprint = New TextBox()
        Label6 = New Label()
        lblValidTo = New Label()
        Label5 = New Label()
        lblValidFrom = New Label()
        Label4 = New Label()
        lblIssuer = New Label()
        Label3 = New Label()
        lblsubject = New Label()
        Label1 = New Label()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.Transparent
        GroupBox1.Controls.Add(Button2)
        GroupBox1.Controls.Add(Button1)
        GroupBox1.Controls.Add(trustcertCB)
        GroupBox1.Controls.Add(errormsg)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(lblThumbprint)
        GroupBox1.Controls.Add(Label6)
        GroupBox1.Controls.Add(lblValidTo)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(lblValidFrom)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(lblIssuer)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Controls.Add(lblsubject)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Dock = DockStyle.Bottom
        GroupBox1.Location = New Point(0, 12)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(351, 400)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        GroupBox1.Text = "Certificate Information"
        ' 
        ' Button2
        ' 
        Button2.Image = CType(resources.GetObject("Button2.Image"), Image)
        Button2.ImageAlign = ContentAlignment.MiddleLeft
        Button2.Location = New Point(264, 367)
        Button2.Name = "Button2"
        Button2.Size = New Size(75, 27)
        Button2.TabIndex = 14
        Button2.Text = "  Reject"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Image = CType(resources.GetObject("Button1.Image"), Image)
        Button1.ImageAlign = ContentAlignment.MiddleLeft
        Button1.Location = New Point(183, 367)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 27)
        Button1.TabIndex = 13
        Button1.Text = "     &Accept"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' trustcertCB
        ' 
        trustcertCB.AutoSize = True
        trustcertCB.Location = New Point(12, 375)
        trustcertCB.Name = "trustcertCB"
        trustcertCB.Size = New Size(134, 19)
        trustcertCB.TabIndex = 12
        trustcertCB.Text = "Do not ask next time"
        trustcertCB.UseVisualStyleBackColor = True
        ' 
        ' errormsg
        ' 
        errormsg.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold Or FontStyle.Italic, GraphicsUnit.Point, CByte(0))
        errormsg.Location = New Point(12, 230)
        errormsg.Name = "errormsg"
        errormsg.Size = New Size(327, 104)
        errormsg.TabIndex = 11
        errormsg.Text = ". . ."
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Image = CType(resources.GetObject("Label2.Image"), Image)
        Label2.ImageAlign = ContentAlignment.MiddleLeft
        Label2.Location = New Point(12, 200)
        Label2.Name = "Label2"
        Label2.Size = New Size(74, 15)
        Label2.TabIndex = 10
        Label2.Text = "       Message"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblThumbprint
        ' 
        lblThumbprint.Location = New Point(12, 158)
        lblThumbprint.Name = "lblThumbprint"
        lblThumbprint.ReadOnly = True
        lblThumbprint.Size = New Size(317, 23)
        lblThumbprint.TabIndex = 9
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(12, 139)
        Label6.Name = "Label6"
        Label6.Size = New Size(71, 15)
        Label6.TabIndex = 8
        Label6.Text = "Thumbprint"
        ' 
        ' lblValidTo
        ' 
        lblValidTo.AutoEllipsis = True
        lblValidTo.Location = New Point(82, 106)
        lblValidTo.Name = "lblValidTo"
        lblValidTo.Size = New Size(257, 15)
        lblValidTo.TabIndex = 7
        lblValidTo.Text = "..."
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(12, 106)
        Label5.Name = "Label5"
        Label5.Size = New Size(49, 15)
        Label5.TabIndex = 6
        Label5.Text = "Valid to:"
        ' 
        ' lblValidFrom
        ' 
        lblValidFrom.AutoEllipsis = True
        lblValidFrom.Location = New Point(82, 85)
        lblValidFrom.Name = "lblValidFrom"
        lblValidFrom.Size = New Size(257, 15)
        lblValidFrom.TabIndex = 5
        lblValidFrom.Text = "..."
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(12, 85)
        Label4.Name = "Label4"
        Label4.Size = New Size(64, 15)
        Label4.TabIndex = 4
        Label4.Text = "Valid from:"
        ' 
        ' lblIssuer
        ' 
        lblIssuer.AutoEllipsis = True
        lblIssuer.Location = New Point(82, 64)
        lblIssuer.Name = "lblIssuer"
        lblIssuer.Size = New Size(257, 15)
        lblIssuer.TabIndex = 3
        lblIssuer.Text = "..."
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(12, 64)
        Label3.Name = "Label3"
        Label3.Size = New Size(40, 15)
        Label3.TabIndex = 2
        Label3.Text = "Issuer:"
        ' 
        ' lblsubject
        ' 
        lblsubject.AutoEllipsis = True
        lblsubject.Location = New Point(82, 43)
        lblsubject.Name = "lblsubject"
        lblsubject.Size = New Size(257, 15)
        lblsubject.TabIndex = 1
        lblsubject.Text = "..."
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 43)
        Label1.Name = "Label1"
        Label1.Size = New Size(49, 15)
        Label1.TabIndex = 0
        Label1.Text = "Subject:"
        ' 
        ' CertCheckup
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(351, 412)
        Controls.Add(GroupBox1)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "CertCheckup"
        StartPosition = FormStartPosition.CenterParent
        Text = "Certificate Checkup"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblsubject As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblIssuer As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblValidFrom As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblValidTo As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblThumbprint As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents errormsg As Label
    Friend WithEvents trustcertCB As CheckBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
End Class
