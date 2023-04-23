Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Module Crypto
    Dim word As String = "Mohamed3713317?!"

    Function AES(text As String, encrypt As Boolean) As String
        Try
            Dim AEScrypt As New AesCryptoServiceProvider()
            AEScrypt.BlockSize = 128
            Dim encoding As Encoding = Encoding.UTF8
            Dim key = encoding.GetBytes(word)
            AEScrypt.Key = key
            AEScrypt.IV = key.Take(16).ToArray
            AEScrypt.Mode = CipherMode.CBC
            AEScrypt.Padding = PaddingMode.PKCS7

            If encrypt Then
                Dim txt = encoding.GetBytes(text)

                Dim memoryStream As New MemoryStream()
                Dim cryptoStream As New CryptoStream(memoryStream, AEScrypt.CreateEncryptor(), CryptoStreamMode.Write)

                cryptoStream.Write(txt, 0, txt.Length)
                cryptoStream.FlushFinalBlock()

                Return Convert.ToBase64String(memoryStream.ToArray())
            Else
                Dim txt = Convert.FromBase64String(text)

                Dim memoryStream As New MemoryStream(txt)
                Dim cryptoStream As New CryptoStream(memoryStream, AEScrypt.CreateDecryptor(), CryptoStreamMode.Read)

                cryptoStream.Read(txt, 0, txt.Length)
                Return encoding.GetString(txt)
            End If

        Catch ex As Exception
            Return ""
        End Try
    End Function


    ' SHA-256 (not encryption method)
    Function ComputeHash(text As String) As String
        Dim SHA256 As SHA256 = SHA256.Create()
        Dim encoding As Encoding = Encoding.UTF8
        Dim txt = encoding.GetBytes(text)
        Return Convert.ToBase64String(SHA256.ComputeHash(txt))
    End Function

    Function CheckHash(text As String, hash256 As String) As Boolean
        Return ComputeHash(text).Equals(hash256)
    End Function
End Module
