using System;
using System.Security.Cryptography;
using System.Text;

namespace BSK1.Crypting
{
    internal class Decrypter
    {
        private string _iV = "asg12eg43h6f7tri"; // initialization vector, 16 chars = 128 bits
        private string _key = "aksjdurngj234ks5kr9i3j2ng5k3p1l2"; // 32 chars = 256 bits

        private string _textToDecrypt;
        private CipherMode _decryptionMode;

        public Decrypter(string textToDecrypt, CipherMode decryptionMode)
        {
            _textToDecrypt = textToDecrypt;
            _decryptionMode = decryptionMode;
        }

        public string Decrypt()
        {
            byte[] textBytes = Convert.FromBase64String(_textToDecrypt);

            AesCryptoServiceProvider aesCSP = new AesCryptoServiceProvider
            {
                BlockSize = 128,
                KeySize = 256,
                IV = Encoding.ASCII.GetBytes(_iV),
                Key = Encoding.ASCII.GetBytes(_key),
                Padding = PaddingMode.PKCS7,
                Mode = _decryptionMode
            };

            using (ICryptoTransform aesICTransform = aesCSP.CreateDecryptor(aesCSP.Key, aesCSP.IV))
            {
                byte[] decryptedText = aesICTransform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                return Encoding.ASCII.GetString(decryptedText);
            }
        }
    }
}
