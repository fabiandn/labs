using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace sample19
{
    class Program
    {
        static void Main(string[] args)
        {
            string publicKeyXml = string.Empty;
            string privateKeyXml = string.Empty;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                publicKeyXml = rsa.ToXmlString(false);
                privateKeyXml = rsa.ToXmlString(true);
            }

            Console.WriteLine(publicKeyXml);
            Console.WriteLine(privateKeyXml);

            UnicodeEncoding byteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = byteConverter.GetBytes("My secret Data!");

            byte[] encryptedData;

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(publicKeyXml);
                encryptedData = rsa.Encrypt(dataToEncrypt, false);
            }

            byte[] decryptedData;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(privateKeyXml);
                decryptedData = rsa.Decrypt(encryptedData, false);
            }

            string decryptedString = byteConverter.GetString(decryptedData);
            Console.WriteLine(decryptedString);

            CspParameters csp = new CspParameters { KeyContainerName = "SecretContainer" };
            byte[] encryptedData2;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(csp))
            {
                encryptedData2 = rsa.Encrypt(dataToEncrypt, false);               
            }

            CspParameters csp2 = new CspParameters { KeyContainerName = "SecretContainer" };

            byte[] decryptedData2;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(csp2))
            {
                decryptedData2= rsa.Decrypt(encryptedData2, false);
            }

            string decryptedString2 = byteConverter.GetString(decryptedData2);
            Console.WriteLine(decryptedString2);
        }
    }
}
