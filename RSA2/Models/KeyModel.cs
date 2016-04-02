using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;


namespace RSA2.Models
{
    public class KeyModel
    {
        public RSAParameters PublicKey { get; set; }
        public RSAParameters PrivateKey { get; set; }
        public string PublicKeyXml { get; set; }
    }
}