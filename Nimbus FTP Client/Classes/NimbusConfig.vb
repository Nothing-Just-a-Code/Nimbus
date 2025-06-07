Imports FluentFTP
Imports Newtonsoft.Json
Public Class NimbusConfig
    <JsonProperty("checkforupdate")> Public Property CheckForUpdateAtStartup As Boolean = True
    <JsonProperty("filesloadmethod")> Public Property FilesLoadMethod As String = "advanced" ' Async Enumerable. 'all' for async
    <JsonProperty("downloaddir")> Public Property DownloadDirectory As String = IO.Path.Combine(Microsoft.WindowsAPICodePack.Shell.KnownFolders.Downloads.Path, "Nimbus Downloads")
    <JsonProperty("downloadoverwrite")> Public Property DownloadOverwriteType As FluentFTP.FtpLocalExists = FluentFTP.FtpLocalExists.Resume
    <JsonProperty("uploadoverwrite")> Public Property UploadOverwriteType As FtpRemoteExists = FtpRemoteExists.Resume
    <JsonProperty("maxuploadthreads")> Public Property MaxUploadThreads As Integer = 3 'Coming soon in upcoming version
    <JsonProperty("remotedir")> Public Property CreateRemoteDirectory As Boolean = True
    <JsonProperty("wordswrap")> Public Property WordsWrap As Boolean = True
    <JsonProperty("deletefileafteredit")> Public Property DeleteLocalFileAfterEdit As Boolean = True
    <JsonProperty("showlinenumber")> Public Property ShowLineNumbers As Boolean = True
    <JsonProperty("encryptionmode")> Public Property EncryptionMode As FtpEncryptionMode = FtpEncryptionMode.Auto
    <JsonProperty("connecttimeout")> Public Property ConnectionTimeoutSeconds As Integer = 30
    <JsonProperty("readtimeout")> Public Property ReadTimeoutSeconds As Integer = 30
    <JsonProperty("retrytask")> Public Property RetryTaskLimit As Integer = 3
    <JsonProperty("dataconnectiontimeout")> Public Property DataConnectionTimeoutSeconds As Integer = 60
    <JsonProperty("datatype")> Public Property TransferDataType As FtpDataType = FtpDataType.Binary
    <JsonProperty("FtpCompareOption")> Public Property CompareFileType As FtpCompareOption = FtpCompareOption.Auto
    <JsonProperty("geminiapi")> Public Property GeminiAPI As String
End Class
