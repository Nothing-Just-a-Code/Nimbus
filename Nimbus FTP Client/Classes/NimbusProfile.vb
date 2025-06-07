Imports Newtonsoft.Json
Public Class NimbusProfile
    <JsonProperty("ftphostname")> Public Property FTPHostname As String
    <JsonProperty("ftpusername")> Public Property FTPUsername As String
    <JsonProperty("ftpport")> Public Property FTPPort As Integer
    <JsonProperty("autoacceptcert")> Public Property AutoAcceptCert As Boolean = False
    <JsonProperty("encryptionmode")> Public Property EncryptionMode As FluentFTP.FtpEncryptionMode = FluentFTP.FtpEncryptionMode.Auto
    <JsonProperty("timeout")> Public Property Timeout As Integer = 15000
    <JsonProperty("readtimeout")> Public Property ReadTimeout As Integer = 15000
    Public Overrides Function ToString() As String
        Return $"{FTPUsername}@{FTPHostname}"
    End Function
End Class
