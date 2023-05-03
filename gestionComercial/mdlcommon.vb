Imports SAPbobsCOM
Module mdlcommon
    Public oCompany As Company
    Public oRecordset As Recordset
    Public ErrNum As Integer
    Public Function dbConnect()
        'Se definen las variables de la conexión
        oCompany = New Company
        oCompany.Server = Environment.GetEnvironmentVariable("SAP_DBSERVER")
        oCompany.CompanyDB = Environment.GetEnvironmentVariable("SAP_PRODCOMPANY")
        oCompany.UserName = Environment.GetEnvironmentVariable("SAP_USER")
        oCompany.Password = Environment.GetEnvironmentVariable("SAP_PROD_UPWD")
        oCompany.DbServerType = BoDataServerTypes.dst_MSSQL2019

        ErrNum = oCompany.Connect() 'Se inicia la conexion
        If ErrNum <> 0 Then
            Console.WriteLine("Error de conexión")
            Return False
        Else
            Return True
        End If
    End Function
End Module
