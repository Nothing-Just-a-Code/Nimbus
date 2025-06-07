Public Class NLogger
    Public Shared logFile As String
    Public Shared Sub Init(Optional addGlobalHandlers As Boolean = True)
        ' Start new log file with timestamp
        Dim timestamp As String = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")
        logFile = IO.Path.Combine(NimbusX.LogsDir, $"log_{timestamp}.txt")

        If addGlobalHandlers Then
            AddHandler Application.ThreadException, AddressOf Application_ThreadException
            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException
        End If

        WriteLog($"=== New Session Started: {DateTime.Now} ==={Environment.NewLine}")
    End Sub

    Public Shared Sub Log(ex As Exception)
        If ex IsNot Nothing Then
            Dim msg = $"[{DateTime.Now}] ERROR: {ex.Message}-- {Environment.NewLine}{ex.StackTrace}{Environment.NewLine}"
            WriteLog(msg)
        End If
    End Sub

    Public Shared Sub LogInfo(info As String)
        Dim msg = $"[{DateTime.Now}] INFO: {info}{Environment.NewLine}"
        WriteLog(msg)
    End Sub

    Private Shared Sub WriteLog(message As String)
        Try
            IO.File.AppendAllText(logFile, message)
        Catch
        End Try
    End Sub

    Private Shared Sub Application_ThreadException(sender As Object, e As Threading.ThreadExceptionEventArgs)
        Log(e.Exception)
    End Sub

    Private Shared Sub CurrentDomain_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs)
        Dim ex As Exception = TryCast(e.ExceptionObject, Exception)
        If ex IsNot Nothing Then Log(ex)
    End Sub
End Class
