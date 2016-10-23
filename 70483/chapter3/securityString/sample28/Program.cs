using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace sample28
{
    class Program
    {
        public static void ConvertToUnSecureString(SecureString secure)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secure);
                Console.WriteLine(Marshal.PtrToStringUni(unmanagedString));
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }

        static void Main(string[] args)
        {
            using (SecureString ss = new SecureString())
            {
                Console.Write("Please enter the password: ");
                while (true)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);

                    if (cki.Key == ConsoleKey.Enter)
                    {
                        break;
                    }

                    ss.AppendChar(cki.KeyChar);
                    Console.Write("*");
                }
                ss.MakeReadOnly();

                ConvertToUnSecureString(ss);
            }
        }
    }
}
