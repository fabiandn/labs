using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sample41_1
{
    class Program
    {
        private static int value;

        static void Main(string[] args)
        {
            Task t1 = Task.Run(() =>
            {
                if (Interlocked.CompareExchange(ref value, 2, 1) == 1)
                {
                    Thread.Sleep(1000);
                    value = 2;
                }
            });

            Task t2 = Task.Run(() =>
            {
                value = 3;
            });

            Task.WaitAll(t1, t2);

            Console.WriteLine(value);
        }
    }
}
