Imports System.ComponentModel

Public Class ChangePermission
    Private FtpDir As FTPDirectory
    Private FtpFile As FTPFile
    Sub New(ByVal dir As FTPDirectory)
        InitializeComponent()
        Me.FtpDir = dir
    End Sub

    Sub New(ByVal _file As FTPFile)
        InitializeComponent()
        Me.FtpFile = _file
    End Sub
    Private Sub ChangePermission_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        LoadPermissions()
    End Sub

    Public Sub LoadPermissions()
        If FtpDir Is Nothing Then
            ApplyChmodToCheckboxes(FtpFile.Permission.ToString())
        ElseIf FtpFile Is Nothing Then
            ApplyChmodToCheckboxes(FtpDir.Permission.ToString())
        End If
    End Sub

    Private Sub ApplyChmodToCheckboxes(chmod As String)
        If chmod.Length <> 3 OrElse Not chmod.All(AddressOf Char.IsDigit) Then
            NimbusX.MBox("Error", "Invalid CHMOD Permission.", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        Dim chmodDigits = chmod.ToCharArray().Select(Function(c) CInt(c.ToString())).ToArray()
        Dim perms = chmodDigits.Select(Function(d) Convert.ToString(d, 2).PadLeft(3, "0"c)).ToArray()

        ' Owner
        chkOwnerRead.Checked = perms(0)(0) = "1"c
        chkOwnerWrite.Checked = perms(0)(1) = "1"c
        chkOwnerExecute.Checked = perms(0)(2) = "1"c

        ' Group
        chkGroupRead.Checked = perms(1)(0) = "1"c
        chkGroupWrite.Checked = perms(1)(1) = "1"c
        chkGroupExecute.Checked = perms(1)(2) = "1"c

        ' Users
        chkOtherRead.Checked = perms(2)(0) = "1"c
        chkOtherWrite.Checked = perms(2)(1) = "1"c
        chkOtherExecute.Checked = perms(2)(2) = "1"c
    End Sub

    Private Function GetChmodFrom() As Integer
        Dim ownerPerm = GetPermAsDigits(chkOwnerRead.Checked, chkOwnerWrite.Checked, chkOwnerExecute.Checked)
        Dim groupPerm = GetPermAsDigits(chkGroupRead.Checked, chkGroupWrite.Checked, chkGroupExecute.Checked)
        Dim otherPerm = GetPermAsDigits(chkOtherRead.Checked, chkOtherWrite.Checked, chkOtherExecute.Checked)
        Return ownerPerm & groupPerm & otherPerm
    End Function

    Private Function GetPermAsDigits(read As Boolean, write As Boolean, execute As Boolean) As Integer
        Dim value As Integer = 0
        If read Then value += 4
        If write Then value += 2
        If execute Then value += 1
        Return value
    End Function

    Private Sub ChangePermission_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If FtpDir Is Nothing Then
            CType(Me.Owner, MainForm).SaveCHMODPermsCall(GetChmodFrom(), False)
        ElseIf FtpFile Is Nothing Then
            CType(Me.Owner, MainForm).SaveCHMODPermsCall(GetChmodFrom(), True)
        End If
    End Sub
End Class