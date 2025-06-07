Public Class FTPDirectory
    Public Property FolderName As String
    Public Property CreatedOn As Date
    Public Property LastModifiedOn As Date
    Public Property Permission As Integer
    Public Property FullPath As String
    Public Overrides Function ToString() As String
        Return FolderName
    End Function
End Class
