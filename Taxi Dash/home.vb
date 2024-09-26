Public Class HomeScreen
    Private Sub btnPlay_Click(sender As Object, e As EventArgs) Handles btnPlay.Click
        Me.Visible = False
        Form1.Visible = True
    End Sub

    Private Sub btnCredits_Click(sender As Object, e As EventArgs) Handles btnCredits.Click
        MessageBox.Show("This is the first game i have " & Environment.NewLine &
                        "ever made and I hope you will " & Environment.NewLine &
                        "enjoy it")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("                  Controls : " & Environment.NewLine &
               "Turn left <-  Taxi  -> Turn right ")
    End Sub
End Class