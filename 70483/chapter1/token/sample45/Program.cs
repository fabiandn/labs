using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace sample45
{
    class Program
    {
        static void Main(string[] args)
        {
            Task longRunnig = Task.Run(() =>
            {
                Thread.Sleep(1000);
            });

            int index = Task.WaitAny(new[] { longRunnig }, 100);

            if (index == -1)
            {
                Console.WriteLine("Task timed out");
            }
        }
    }
}
