Imports Newtonsoft.Json
Imports System.IO
Imports System.Security.Cryptography.X509Certificates
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Newtonsoft.Json.Linq
Public Class NimbusX
    Public Shared MainDir As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Nimbus")
    Public Shared DataDir As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Nimbus", "Data")
    Public Shared CertsDir As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Nimbus", "Certs")
    Public Shared LogsDir As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Nimbus", "Logs")
    Public Shared DownloadsDir As String = Path.Combine(Microsoft.WindowsAPICodePack.Shell.KnownFolders.Downloads.Path, "Nimbus Downloads")
    Public Shared UpdateDir As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Nimbus", "Update")
    Public Shared TrustedCerts As New List(Of TrustedCert)()
    Public Shared NConfig As New NimbusConfig()
    Public Shared NimbusProfiles As New List(Of NimbusProfile)()
    Public Shared Async Function Init() As Task
        Await Task.Run(Sub()
                           'create dirs if not exists
                           If Not Directory.Exists(MainDir) Then Directory.CreateDirectory(MainDir)
                           If Not Directory.Exists(DataDir) Then Directory.CreateDirectory(DataDir)
                           If Not Directory.Exists(CertsDir) Then Directory.CreateDirectory(CertsDir)
                           If Not Directory.Exists(LogsDir) Then Directory.CreateDirectory(LogsDir)
                           If Not Directory.Exists(UpdateDir) Then Directory.CreateDirectory(UpdateDir)
                           If Not Microsoft.WindowsAPICodePack.Shell.KnownFolders.Downloads.PathExists Then Directory.CreateDirectory(Microsoft.WindowsAPICodePack.Shell.KnownFolders.Downloads.Path)
                           If Not Directory.Exists(DownloadsDir) Then Directory.CreateDirectory(DownloadsDir)

                           'Load Logger
                           NLogger.Init(True)

                           'load nimbus config file
                           LoadNimbusConfig()

                           'Load Nimbus Profiles
                           LoadProfiles()

                           'load trusted certs
                           LoadTrustedCerts()
                       End Sub)
    End Function

    Public Shared Sub LoadProfiles()
        For Each item As String In Directory.GetFiles(DataDir, "*.nbs")
            Dim nimprof As NimbusProfile = JsonConvert.DeserializeObject(Of NimbusProfile)(File.ReadAllText(item))
            NimbusProfiles.Add(nimprof)
        Next
    End Sub

    Public Shared Sub DeleteProfile(ByVal profile As NimbusProfile)
        Dim filepath As String = Path.Combine(DataDir, $"{profile.FTPHostname}@{profile.FTPUsername}.nbs")
        If File.Exists(filepath) Then
            NimbusProfiles.Remove(profile)
            File.Delete(filepath)
        End If
    End Sub

    Public Shared Sub LoadNimbusConfig()
        If File.Exists(Path.Combine(MainDir, "Nimbus.json")) Then
            NConfig = JsonConvert.DeserializeObject(Of NimbusConfig)(File.ReadAllText(Path.Combine(MainDir, "Nimbus.json")))
        Else
            SaveNimbusConfig()
        End If
    End Sub

    Public Shared Function GetNimbusProfile(ByVal hostname As String, ByVal username As String) As NimbusProfile
        Return NimbusProfiles.FirstOrDefault(Function(x) x.FTPHostname.Equals(hostname, comparisonType:=StringComparison.OrdinalIgnoreCase) AndAlso
                                         x.FTPUsername.Equals(username, comparisonType:=StringComparison.OrdinalIgnoreCase), Nothing)
    End Function

    Public Shared Sub SaveNimbusConfig()
        File.WriteAllText(Path.Combine(MainDir, "Nimbus.json"), JsonConvert.SerializeObject(NConfig, Formatting.Indented), System.Text.Encoding.UTF8)
    End Sub

    Public Shared Sub SaveNimbusProfile(ByVal profile As NimbusProfile)
        If Not NimbusProfiles.Any(Function(x) x.FTPHostname.Equals(profile.FTPHostname, comparisonType:=StringComparison.OrdinalIgnoreCase) AndAlso
                                         x.FTPUsername.Equals(profile.FTPUsername, comparisonType:=StringComparison.OrdinalIgnoreCase)) Then
            NimbusProfiles.Add(profile)
        End If
        File.WriteAllText(Path.Combine(DataDir, $"{profile.FTPHostname}@{profile.FTPUsername}.nbs"), JsonConvert.SerializeObject(profile, Formatting.Indented), System.Text.Encoding.UTF8)
    End Sub

    Public Shared Function IsEmpty(ByVal text As String) As Boolean
        Return String.IsNullOrEmpty(text) OrElse String.IsNullOrWhiteSpace(text)
    End Function

    Public Shared Sub LoadTrustedCerts()
        If File.Exists(Path.Combine(CertsDir, "trusted certs.json")) Then
            TrustedCerts = JsonConvert.DeserializeObject(Of List(Of TrustedCert))(File.ReadAllText(Path.Combine(CertsDir, "trusted certs.json")))
        End If
    End Sub

    ' Save cert list to file
    Private Shared Sub SaveTrustedCerts()
        Dim json = JsonConvert.SerializeObject(TrustedCerts, Formatting.Indented)
        IO.File.WriteAllText(Path.Combine(CertsDir, "trusted certs.json"), json, System.Text.Encoding.UTF8)
    End Sub

    ' Check if certificate is trusted for a specific hostname
    Public Shared Function IsTrustedCert(hostname As String, cert As X509Certificate2) As Boolean
        Return TrustedCerts.Any(Function(c) String.Equals(c.Hostname, hostname, StringComparison.OrdinalIgnoreCase) AndAlso
                                String.Equals(c.CertThumbprint, cert.Thumbprint, StringComparison.OrdinalIgnoreCase))
    End Function

    ' Add a certificate to the trusted list
    Public Shared Sub AddTrustedCert(hostname As String, cert As X509Certificate2)
        If Not TrustedCerts.Any(Function(c) c.Hostname.Equals(hostname, StringComparison.OrdinalIgnoreCase) AndAlso
                                     c.CertThumbprint.Equals(cert.Thumbprint, StringComparison.OrdinalIgnoreCase)) Then

            TrustedCerts.Add(New TrustedCert With {
                .Hostname = hostname,
                .CertThumbprint = cert.Thumbprint
            })

            SaveTrustedCerts()
        End If
    End Sub

    Public Shared Function GetVersion() As String
        Return $"{My.Application.Info.Version.Major}.{My.Application.Info.Version.Minor}.{My.Application.Info.Version.Build}"
    End Function

    Public Shared Function MBox(ByVal title As String, ByVal text As String, ByVal buttons As MessageBoxButtons, icon As MessageBoxIcon, Optional ByVal owner As IWin32Window = Nothing) As DialogResult
        Return MessageBox.Show(caption:=title, text:=text, buttons:=buttons, icon:=icon, owner:=owner)
    End Function

    'Enum for Update Check Method
    Public Class NewUpdateInfo
        Public Property IsAvailable As Boolean
        Public Property IsError As Boolean
        Public Property WhatsNew As New List(Of String)()
    End Class

    Public Shared Function ChildNodeExistsLinq(parentNode As TreeNode, value As String) As Boolean
        Return parentNode.Nodes.Cast(Of TreeNode)().
            Any(Function(n) n.Text.Equals(value, StringComparison.OrdinalIgnoreCase))
    End Function
    Public Shared Function FormatBytes(bytes As Long) As String
        Dim sizes = {"B", "KB", "MB", "GB", "TB"}
        Dim len As Double = bytes
        Dim order As Integer = 0
        While len >= 1024 AndAlso order < sizes.Length - 1
            order += 1
            len /= 1024
        End While
        Return $"{len:0.##} {sizes(order)}"
    End Function

    Public Shared Function FormatTimeSpanReadable(ts As TimeSpan) As String
        Dim parts As New List(Of String)

        If ts.Hours > 0 Then
            parts.Add($"{ts.Hours} hour{If(ts.Hours = 1, "", "s")}")
        End If

        If ts.Minutes > 0 Then
            parts.Add($"{ts.Minutes} minute{If(ts.Minutes = 1, "", "s")}")
        End If

        If ts.Seconds > 0 OrElse parts.Count = 0 Then ' Always show seconds if all other parts are 0
            parts.Add($"{ts.Seconds} second{If(ts.Seconds = 1, "", "s")}")
        End If

        Return String.Join(" ", parts)
    End Function
    Public Shared Function CombineFtpPath(ParamArray parts() As String) As String
        Dim resultParts As New List(Of String)

        For Each part In parts
            If Not String.IsNullOrWhiteSpace(part) Then
                ' Replace backslashes with forward slashes and trim slashes from ends
                Dim cleaned = part.Replace("\", "/").Trim("/"c)
                If cleaned.Length > 0 Then
                    resultParts.Add(cleaned)
                End If
            End If
        Next
        Return String.Join("/", resultParts)
    End Function

    Public Shared Function BytesToImage(bytes As Byte()) As Image
        Using ms As New MemoryStream(bytes)
            Return Image.FromStream(ms)
        End Using
    End Function

    Public Shared Function GetFtpDirectory(remotePath As String) As String
        Dim dir = Path.GetDirectoryName(remotePath.Replace("\"c, "/"c))
        If String.IsNullOrWhiteSpace(dir) Then Return "/"
        Return dir.Replace("\", "/")
    End Function

    Public Shared Function MaskString(ByVal inputString As String) As String
        ' Check if the input string is Nothing or empty.
        If IsEmpty(inputString) Then
            Return ""
        End If

        Dim stringLength As Integer = inputString.Length
        Const standardCharsToReveal As Integer = 6
        Const shortStringCharsToReveal As Integer = 2

        If stringLength > standardCharsToReveal Then
            Dim numberOfStars As Integer = stringLength - standardCharsToReveal
            Dim stars As String = New String("*"c, numberOfStars)
            Dim revealedPart As String = inputString.Substring(stringLength - standardCharsToReveal)
            Return stars & revealedPart
        ElseIf stringLength > shortStringCharsToReveal Then
            Dim numberOfStars As Integer = stringLength - shortStringCharsToReveal
            Dim stars As String = New String("*"c, numberOfStars)
            Dim revealedPart As String = inputString.Substring(stringLength - shortStringCharsToReveal)
            Return stars & revealedPart
        Else
            Return inputString
        End If
    End Function

    Public Shared Async Function IsNewVersionAvailable() As Task(Of (NewVersionAvailable As Boolean, IsMajorUpdate As Boolean, NewVersion As String, ChangeLogs As String()))
        Try
            Dim jsn As String = ""
            Using http As New Net.Http.HttpClient()
                Dim httpM = Await http.GetAsync("https://raw.githubusercontent.com/Nothing-Just-a-Code/Nimbus/refs/heads/main/Nimbus.json")
                httpM.EnsureSuccessStatusCode()
                jsn = Await httpM.Content.ReadAsStringAsync()
            End Using
            Dim J As JObject = JObject.Parse(jsn)
            Dim CurVer As String = GetVersion()
            Dim version As String = J("version").Value(Of String)()
            Dim changelogarray As JArray = J("changelog")
            Dim changelogs As List(Of String) = changelogarray.Select(Function(x) x.ToString()).ToList()
            Dim IsMajor As Boolean = J("ismajor").Value(Of Boolean)()
            Dim NewVer As Boolean
            If CurVer.Equals(version, StringComparison.OrdinalIgnoreCase) Then NewVer = False Else NewVer = True
            Return (NewVersionAvailable:=NewVer, IsMajorUpdate:=IsMajor, NewVersion:=version, ChangeLogs:=changelogs.ToArray())
        Catch ex As Exception
            NLogger.Log(ex)
            MBox("Error while checking for update", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

End Class
