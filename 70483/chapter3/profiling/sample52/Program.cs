using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample52
{
    class Program
    {
        const int numberOfIterations = 10000;

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            Algorithm1();
            sw.Stop();

            Console.WriteLine($"Time Enlapsed :{sw.Elapsed}");

            sw.Reset();
            sw.Start();
            Algorithm2();
            sw.Stop();

            Console.WriteLine($"Time Enlapsed :{sw.Elapsed}");

            Console.WriteLine("Ready...");
            Console.ReadLine();
        }

        private static void Algorithm2()
        {
            string result = "";

            for (int i = 0; i < numberOfIterations; i++)
            {
                result += "a";
            }
        }

        private static void Algorithm1()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < numberOfIterations; i++)
            {
                sb.Append("a");
            }

            string result = sb.ToString();    
        }
    }
}
