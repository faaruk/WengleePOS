Imports System
Imports System.IO
Imports System.Text
Imports System.Security.Cryptography


Public Module SHA1Encryption

    Public Function Encrypt(ByVal plainText As String) As String

        Dim passPhrase As String = "Pas5pr@se"        ' can be any string
        Dim saltValue As String = "s@1tValue"        ' can be any string

        Dim hashAlgorithm As String = "SHA1"             ' can be "MD5"
        Dim passwordIterations As Integer = 2                  ' can be any number

        Dim initVector As String = "@1B2c3D4e5F6g7H8" ' must be 16 bytes
        Dim keySize As Integer = 256

        Dim initVectorBytes As Byte()
        initVectorBytes = Encoding.ASCII.GetBytes(initVector)

        Dim saltValueBytes As Byte()
        saltValueBytes = Encoding.ASCII.GetBytes(saltValue)

        Dim plainTextBytes As Byte()
        plainTextBytes = Encoding.UTF8.GetBytes(plainText)

        ' First, we must create a password, from which the key will be derived.
        ' This password will be generated from the specified passphrase and 
        ' salt value. The password will be created using the specified hash 
        ' algorithm. Password creation can be done in several iterations.
        Dim password As PasswordDeriveBytes 
        password = New PasswordDeriveBytes(passPhrase, _
                                           saltValueBytes, _
                                           hashAlgorithm, _
                                           passwordIterations)

        ' Use the password to generate pseudo-random bytes for the encryption
        ' key. Specify the size of the key in bytes (instead of bits).
        Dim keyBytes As Byte()
        keyBytes = CType(password.GetBytes(keySize / 8), Byte())

        ' Create uninitialized Rijndael encryption object.
        Dim symmetricKey As RijndaelManaged
        symmetricKey = New RijndaelManaged()

        ' It is reasonable to set encryption mode to Cipher Block Chaining
        ' (CBC). Use default options for other symmetric key parameters.
        symmetricKey.Mode = CipherMode.CBC

        ' Generate encryptor from the existing key bytes and initialization 
        ' vector. Key size will be defined based on the number of the key 
        ' bytes.
        Dim encryptor As ICryptoTransform
        encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)

        ' Define memory stream which will be used to hold encrypted data.
        Dim memoryStream As MemoryStream
        memoryStream = New MemoryStream()

        ' Define cryptographic stream (always use Write mode for encryption).
        Dim cryptoStream As CryptoStream
        cryptoStream = New CryptoStream(memoryStream, _
                                        encryptor, _
                                        CryptoStreamMode.Write)
        ' Start encrypting.
        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length)

        ' Finish encrypting.
        cryptoStream.FlushFinalBlock()

        ' Convert our encrypted data from a memory stream into a byte array.
        Dim cipherTextBytes As Byte()
        cipherTextBytes = memoryStream.ToArray()

        ' Close both streams.
        memoryStream.Close()
        cryptoStream.Close()

        ' Convert encrypted data into a base64-encoded string.
        Dim cipherText As String
        cipherText = Convert.ToBase64String(cipherTextBytes)

        ' Return encrypted string.
        Encrypt = cipherText
    End Function
    Public Function Decrypt(ByVal cipherText As String) As String

        Dim passPhrase As String = "Pas5pr@se"        ' can be any string
        Dim saltValue As String = "s@1tValue"        ' can be any string
        Dim hashAlgorithm As String = "SHA1"             ' can be "MD5"
        Dim passwordIterations As Integer = 2                  ' can be any number
        Dim initVector As String = "@1B2c3D4e5F6g7H8" ' must be 16 bytes
        Dim keySize As Integer = 256
        ' Convert strings defining encryption key characteristics into byte
        ' arrays. Let us assume that strings only contain ASCII codes.
        ' If strings include Unicode characters, use Unicode, UTF7, or UTF8
        ' encoding.
        Dim initVectorBytes As Byte()
        initVectorBytes = Encoding.ASCII.GetBytes(initVector)

        Dim saltValueBytes As Byte()
        saltValueBytes = Encoding.ASCII.GetBytes(saltValue)

        ' Convert our ciphertext into a byte array.
        Dim cipherTextBytes As Byte()
        cipherTextBytes = Convert.FromBase64String(cipherText)

        ' First, we must create a password, from which the key will be 
        ' derived. This password will be generated from the specified 
        ' passphrase and salt value. The password will be created using
        ' the specified hash algorithm. Password creation can be done in
        ' several iterations.
        Dim password As PasswordDeriveBytes
        password = New PasswordDeriveBytes(passPhrase, _
                                           saltValueBytes, _
                                           hashAlgorithm, _
                                           passwordIterations)

        ' Use the password to generate pseudo-random bytes for the encryption
        ' key. Specify the size of the key in bytes (instead of bits).
        Dim keyBytes As Byte()
        keyBytes = CType(password.GetBytes(keySize / 8), Byte())

        ' Create uninitialized Rijndael encryption object.
        Dim symmetricKey As RijndaelManaged
        symmetricKey = New RijndaelManaged()

        ' It is reasonable to set encryption mode to Cipher Block Chaining
        ' (CBC). Use default options for other symmetric key parameters.
        symmetricKey.Mode = CipherMode.CBC

        ' Generate decryptor from the existing key bytes and initialization 
        ' vector. Key size will be defined based on the number of the key 
        ' bytes.
        Dim decryptor As ICryptoTransform
        decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)

        ' Define memory stream which will be used to hold encrypted data.
        Dim memoryStream As MemoryStream
        memoryStream = New MemoryStream(cipherTextBytes)

        ' Define memory stream which will be used to hold encrypted data.
        Dim cryptoStream As CryptoStream
        cryptoStream = New CryptoStream(memoryStream, _
                                        decryptor, _
                                        CryptoStreamMode.Read)

        Dim plainTextBytes As Byte()
        ReDim plainTextBytes(cipherTextBytes.Length)

        ' Start decrypting.
        Dim decryptedByteCount As Integer
        decryptedByteCount = cryptoStream.Read(plainTextBytes, _
                                               0, _
                                               plainTextBytes.Length)

        ' Close both streams.
        memoryStream.Close()
        cryptoStream.Close()

        ' Convert decrypted data into a string. 
        ' Let us assume that the original plaintext string was UTF8-encoded.
        Dim plainText As String
        plainText = Encoding.UTF8.GetString(plainTextBytes, _
                                            0, _
                                            decryptedByteCount)

        ' Return decrypted string.
        Decrypt = plainText
    End Function
End Module

' <summary>
' The main entry point for the application.
'' </summary>
'Sub Main()
'    Dim plainText As String
'    Dim cipherText As String

'    Dim passPhrase As String
'    Dim saltValue As String
'    Dim hashAlgorithm As String
'    Dim passwordIterations As Integer
'    Dim initVector As String
'    Dim keySize As Integer

'    plainText = "Hello, World!"    ' original plaintext

'    passPhrase = "Pas5pr@se"        ' can be any string
'    saltValue = "s@1tValue"        ' can be any string
'    hashAlgorithm = "SHA1"             ' can be "MD5"
'    passwordIterations = 2                  ' can be any number
'    initVector = "@1B2c3D4e5F6g7H8" ' must be 16 bytes
'    keySize = 256                ' can be 192 or 128

'    Console.WriteLine(String.Format("Plaintext : {0}", plainText))

'    cipherText = bidyutSample.Encrypt(plainText, _
'                                        passPhrase, _
'                                        saltValue, _
'                                        hashAlgorithm, _
'                                        passwordIterations, _
'                                        initVector, _
'                                        keySize)
'    Console.WriteLine(String.Format("Encrypted : {0}", cipherText))
'    plainText = bidyutSample.Decrypt(cipherText, _
'                                        passPhrase, _
'                                        saltValue, _
'                                        hashAlgorithm, _
'                                        passwordIterations, _
'                                        initVector, _
'                                        keySize)
'    Console.WriteLine(String.Format("Decrypted : {0}", plainText))
'End Sub
' 
' END OF FILE
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

