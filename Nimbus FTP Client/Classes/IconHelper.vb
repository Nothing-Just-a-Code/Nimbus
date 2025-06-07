Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.IO

Public Class IconHelper

    <StructLayout(LayoutKind.Sequential)>
    Private Structure SHFILEINFO
        Public hIcon As IntPtr
        Public iIcon As Integer
        Public dwAttributes As UInteger
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=260)>
        Public szDisplayName As String
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=80)>
        Public szTypeName As String
    End Structure

    <DllImport("shell32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SHGetFileInfo(
        ByVal pszPath As String,
        ByVal dwFileAttributes As UInteger,
        ByRef psfi As SHFILEINFO,
        ByVal cbFileInfo As UInteger,
        ByVal uFlags As UInteger) As IntPtr
    End Function

    Private Const SHGFI_ICON As UInteger = &H100
    Private Const SHGFI_USEFILEATTRIBUTES As UInteger = &H10
    Private Const FILE_ATTRIBUTE_NORMAL As UInteger = &H80

    ''' <summary>
    ''' Get the system icon image for a given file extension (e.g., ".mp3", ".txt").
    ''' </summary>
    Public Shared Function GetFileIconByExtension(extension As String) As Image
        If Not extension.StartsWith(".") Then extension = "." & extension

        Dim shinfo As New SHFILEINFO()
        SHGetFileInfo(extension, FILE_ATTRIBUTE_NORMAL, shinfo, CUInt(Marshal.SizeOf(shinfo)),
                      SHGFI_ICON Or SHGFI_USEFILEATTRIBUTES)

        If shinfo.hIcon <> IntPtr.Zero Then
            Dim icon As Icon = Icon.FromHandle(shinfo.hIcon)
            Dim image As Image = icon.ToBitmap()
            DestroyIcon(shinfo.hIcon) ' Clean up
            Return image
        End If

        Return Nothing
    End Function

    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function DestroyIcon(hIcon As IntPtr) As Boolean
    End Function

End Class
