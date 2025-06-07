Public Class MessageBubble
    Inherits UserControl

    Private Const MaxWidth As Integer = 650
    Private ReadOnly bubblePanel As Panel
    Private ReadOnly messageLabel As Label

    Public Sub New(message As String, isIncoming As Boolean)
        Me.DoubleBuffered = True
        Me.BackColor = Color.Transparent
        Me.AutoSize = True
        Me.AutoSizeMode = AutoSizeMode.GrowAndShrink
        Me.Margin = New Padding(0)

        ' Bubble panel
        bubblePanel = New Panel With {
            .AutoSize = True,
            .AutoSizeMode = AutoSizeMode.GrowAndShrink,
            .Padding = New Padding(10),
            .BackColor = If(isIncoming, Color.LightGray, Color.LightBlue),
            .MaximumSize = New Size(MaxWidth, 0)
        }

        ' Label
        messageLabel = New Label With {
            .AutoSize = True,
            .Text = message,
            .MaximumSize = New Size(MaxWidth - 20, 0), ' Adjust for padding
            .Font = New Font("Segoe UI Semibold", 9, FontStyle.Regular)
        }
        AddHandler messageLabel.MouseDoubleClick, Sub(s, e)
                                                      Clipboard.SetText(messageLabel.Text)
                                                  End Sub
        AddHandler bubblePanel.MouseDoubleClick, Sub(s, e)
                                                     Clipboard.SetText(messageLabel.Text)
                                                 End Sub
        bubblePanel.Controls.Add(messageLabel)
        Me.Controls.Add(bubblePanel)

        ' Align bubble
        If isIncoming Then
            Me.Padding = New Padding(10, 5, 50, 5) ' Align left
            messageLabel.Font = New Font("Segoe UI Semibold", 10, FontStyle.Regular)
        Else
            Me.Padding = New Padding(20, 5, 10, 5) ' Align right
        End If
    End Sub

    Private Sub copytext_Click(sender As Object, e As EventArgs)
        Dim message = messageLabel.Text
        If message.StartsWith("Gemini AI") Then message = message.Remove(0, 11)
        Clipboard.SetText(message)
    End Sub
End Class
