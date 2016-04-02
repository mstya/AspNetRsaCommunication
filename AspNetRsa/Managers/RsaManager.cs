using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using AspNetRsa.Models;

namespace AspNetRsa.Managers
{
    public class RsaManager
    {
        private const int KEY_SIZE = 2048;

        private const char COMMA = ',';

        public KeyModel GetKeys()
        {
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider(KEY_SIZE);
            return new KeyModel
            {
                PublicKeyXml = csp.ToXmlString(false),
                PrivateKeyXml = csp.ToXmlString(true)
            };
        }

        public string Decrypt(string data, string privateKeyXml)
        {
            // dog-nail
            byte[] encryptedBytes = data.Split(COMMA).Select(byte.Parse).ToArray();

            RSACryptoServiceProvider csp = new RSACryptoServiceProvider(KEY_SIZE);
            csp.FromXmlString(privateKeyXml);
            byte[] decrypted = csp.Decrypt(encryptedBytes, false);
            return Encoding.ASCII.GetString(decrypted);
        }
    }
}