using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace sample27
{
    class Program
    {
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
            }
        }
    }
}
