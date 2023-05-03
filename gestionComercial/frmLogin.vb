Imports gestionComercial
Public Class frmLogin
    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Dim hasher As New classPassword()

        'Dim hashed As String = hasher.HashPassword(txtUser.Text)
        'txtPassword.Text = hashed

        If dbConnect() = True Then
            MessageBox.Show("Se realizó conexión")
        End If

    End Sub
End Class
