using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample17
{
    class Program
    {
        static void Main(string[] args)
        {
            ParallelLoopResult result = Parallel.For(0, 100, (int i, ParallelLoopState loopState) =>
            {
                if (i==500)
                {
                    Console.WriteLine("Breaking Loop");
                    loopState.Break();
                }

                return;
            });
        }
    }
}
