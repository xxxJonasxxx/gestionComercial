Imports gestionComercial
Public Class frmLogin


    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Dim hasher As New classPassword()

        Dim hashed As String
        Dim respuesta As Integer
        '= hasher.HashPassword(txtUser.Text)
        'txtPassword.Text = hashed

        If dbConnect() = True Then
            oRecordset = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordset.DoQuery("select Password from MAVIJU_PRO_GES_COM_USUARIOS where Estado = 1 and Usuario = '" & CStr(txtUser.Text) & "'")

            If oRecordset.RecordCount > 0 Then
                hashed = oRecordset.Fields.Item("Password").Value
                respuesta = hasher.VerifyPassword(txtPassword.Text, hashed)

                If respuesta <> 0 Then
                    MessageBox.Show("Su contraseña es correcta.")
                Else
                    MessageBox.Show("Su contraseña es incorrecta.", "Importante:..", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    'Limpia el campo de contraseña
                    txtPassword.Text = ""
                End If
            Else
                MessageBox.Show("Usuario no existe", "Importante:..", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                'Limpia todos los campos 
                txtPassword.Text = ""
                txtUser.Text = ""
            End If
        End If

        oCompany.Disconnect()        ' 
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordset)

        oRecordset = Nothing
        oCompany = Nothing


    End Sub
End Class
