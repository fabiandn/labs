using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace sample24
{
    class Program
    {
        public static void SignAndVerifiy()
        {
            string textToSign = "Test paragraph";
            byte[] signature = Sign(textToSign, "cn=WouterDeKort");
            signature[0] = 0;
            Console.WriteLine(Verify(textToSign, signature));
        }

        private static byte[] Sign(string textToSign, string cerSubject)
        {
            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider)cert.PrivateKey;
            byte[] hash = HashData(textToSign);
            return csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
        }

        private static bool Verify(string textToSign, byte[] signature)
        {
            X509Certificate2 cert = GetCertificate();
            var csp = (RSACryptoServiceProvider)cert.PublicKey.Key;
            byte[] hash = HashData(textToSign);
            return csp.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), signature);  
        }

        private static byte[] HashData(string textToSign)
        {
            HashAlgorithm hashAlgorithm = new SHA1Managed();
            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] data = encoding.GetBytes(textToSign);
            byte[] hash = hashAlgorithm.ComputeHash(data);
            return hash;
        }

        private static X509Certificate2 GetCertificate()
        {
            X509Store my = new X509Store("testCertCtore", StoreLocation.CurrentUser);
            my.Open(OpenFlags.ReadOnly);
            var certificate = my.Certificates[0];
            return certificate;
        }

        static void Main(string[] args)
        {
            SignAndVerifiy();
        }
    }
}
