Imports System.Security.Cryptography.X509Certificates

Public Class CertCheckup
    Private cert As X509Certificate2
    Public ReadOnly Property Accepted As Boolean
    Private Sub CertCheckup_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Public Sub New(_cert As X509Certificate2, ByVal errormsg As String)
        InitializeComponent()
        cert = _cert
        PopulateCertInfo(errormsg)
    End Sub
    Private Sub PopulateCertInfo(ByVal ermsg As String)
        lblSubject.Text = cert.Subject
        lblIssuer.Text = cert.Issuer
        lblValidFrom.Text = cert.NotBefore
        lblValidTo.Text = cert.NotAfter
        lblThumbprint.Text = cert.Thumbprint
        If Not NimbusX.IsEmpty(ermsg) Then Me.errormsg.Text = ermsg
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If trustcertCB.Checked = True Then
            Me.DialogResult = DialogResult.Yes ' Accept and trust cert
            Me.Close()
        Else
            Me.DialogResult = DialogResult.OK ' just accept the cert without trusting in future
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub
End Class