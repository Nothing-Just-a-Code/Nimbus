Public Class CreateNewDirectory
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Not NimbusX.IsEmpty(newdirname.Text) Then
            CType(Me.Owner, MainForm).CreateDirectoryCall(newdirname.Text)
            Me.Close()
        End If
    End Sub
End Class