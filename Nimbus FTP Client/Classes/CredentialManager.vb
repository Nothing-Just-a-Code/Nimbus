Imports CredentialManagement

Public Class CredentialManager
    Public Shared Sub SavePassword(service As String, username As String, password As String)
        Dim cred As New Credential With {
            .Target = service,
            .Username = username,
            .Password = password,
            .PersistanceType = PersistanceType.LocalComputer,
            .Type = CredentialType.Generic
        }
        cred.Save()
    End Sub

    Public Shared Function GetPassword(service As String) As String
        Dim cred As New Credential With {.Target = service}
        If cred.Load() Then
            Return cred.Password
        End If
        Return Nothing
    End Function
End Class
