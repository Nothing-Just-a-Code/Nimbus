Imports Newtonsoft.Json
Public Class TrustedCert
    <JsonProperty("hostname")> Public Property Hostname As String
    <JsonProperty("thumbprint")> Public Property CertThumbprint As String
End Class
