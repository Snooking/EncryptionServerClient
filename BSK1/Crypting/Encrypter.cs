using System;
using System.Security.Cryptography;
using System.Text;

namespace BSK1.Crypting
{
    internal class Encrypter
    {
        private string _iV = "asg12eg43h6f7tri"; // initialization vector, 16 chars = 128 bits
        private string _key = "aksjdurngj234ks5kr9i3j2ng5k3p1l2"; // 32 chars = 256 bits

        private string _textToEncrypt;
        private CipherMode _encryptionMode;

        public Encrypter(string textToEncrypt, CipherMode encryptionMode)
        {
            _textToEncrypt = textToEncrypt;
            _encryptionMode = encryptionMode;
        }

        public string Encrypt()
        {
            byte[] textBytes = Encoding.ASCII.GetBytes(_textToEncrypt);

            AesCryptoServiceProvider aesCSP = new AesCryptoServiceProvider
            {
                BlockSize = 128,
                KeySize = 256,
                IV = Encoding.ASCII.GetBytes(_iV),
                Key = Encoding.ASCII.GetBytes(_key),
                Padding = PaddingMode.PKCS7,
                Mode = _encryptionMode
            };

            using (ICryptoTransform aesICTransform = aesCSP.CreateEncryptor(aesCSP.Key, aesCSP.IV))
            {
                byte[] encryptedText = aesICTransform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                return Convert.ToBase64String(encryptedText);
            }
        }
    }
}
