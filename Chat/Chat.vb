Imports System.IO
Imports System.Net.Sockets

Public Class Chat

    Public myIp As String
    Public friendIp As String
    Public user As String

    Dim listener As New TcpListener(6060)
    Dim client As New TcpClient

    Private Sub Chat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            listener.Start()
        Catch ex As Exception
            MessageBox.Show("Erro ao Conectar ao Servidor!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        client = New TcpClient(friendIp, 6060)
        Dim sw As New StreamWriter(client.GetStream())
        sw.Write(user + ": " + TextBox2.Text)
        sw.Flush()

        TextBox1.AppendText(user + ": " + TextBox2.Text + vbNewLine)

        TextBox2.Clear()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim mensagem As String = ""

        If listener.Pending = True Then

            client = listener.AcceptTcpClient
            Dim sr As New StreamReader(client.GetStream)

            While sr.Peek > -1

                mensagem &= Convert.ToChar(sr.Read()).ToString

            End While

            TextBox1.AppendText(mensagem + vbNewLine)

        End If

    End Sub
End Class