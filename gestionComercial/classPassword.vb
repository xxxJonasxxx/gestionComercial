Imports System.Security.Cryptography
Imports System.Text
Public Class classPassword
    Public Shared Function HashPassword(ByVal password As String) As String
        Dim salt As Byte() = GenerateSalt()
        Dim hash As Byte() = HashPassword(password, salt)
        Return Convert.ToBase64String(salt) & "|" & Convert.ToBase64String(hash)
    End Function

    Public Shared Function VerifyPassword(ByVal password As String, ByVal hashedPassword As String) As Boolean
        Dim parts As String() = hashedPassword.Split(New Char() {"|"c})
        Dim salt As Byte() = Convert.FromBase64String(parts(0))
        Dim hash As Byte() = Convert.FromBase64String(parts(1))
        Dim computedHash As Byte() = HashPassword(password, salt)
        Return SlowEquals(hash, computedHash)
    End Function

    Private Shared Function GenerateSalt() As Byte()
        Dim salt As Byte() = New Byte(31) {}
        Using rng As New RNGCryptoServiceProvider()
            rng.GetBytes(salt)
        End Using
        Return salt
    End Function

    Private Shared Function HashPassword(ByVal password As String, ByVal salt As Byte()) As Byte()
        Using sha512 As New SHA512Managed()
            Dim saltedPassword As Byte() = Encoding.UTF8.GetBytes(password).Concat(salt).ToArray()
            Return sha512.ComputeHash(saltedPassword)
        End Using
    End Function

    Private Shared Function SlowEquals(ByVal a As Byte(), ByVal b As Byte()) As Boolean
        Dim diff As UInteger = CUInt(a.Length) Xor CUInt(b.Length)
        Dim i As Integer = 0
        While i < a.Length AndAlso i < b.Length
            diff = diff Or CUInt(a(i) Xor b(i))
            i += 1
        End While
        Return diff = 0
    End Function

End Class
