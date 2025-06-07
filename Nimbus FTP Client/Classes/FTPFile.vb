Public Class FTPFile
    Public Property Filename As String
    Public Property FileSize As Long
    Public Property Permission As Integer
    Public Property FullPath As String
    Public Property Extension As String
    Public Property CreatedOn As Date
    Public Property LastModifiedOn As Date

    Public Overrides Function ToString() As String
        Return Filename
    End Function
End Class
