Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Chat.myIp = TextBox1.Text
        Chat.friendIp = TextBox2.Text
        Chat.user = TextBox3.Text
        Chat.Show()
        Me.Hide()
    End Sub
End Class
