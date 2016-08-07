using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace sample7
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem((s)=>
            {
                Console.WriteLine("Working on a thread from threadpool");
            });

            Console.ReadLine();
        }
    }
}
