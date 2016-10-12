﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample33
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
            queue.Enqueue(42);

            int result;
            if (queue.TryDequeue(out result))
            {
                Console.WriteLine("Dequeue: {0}", result);
            }
        }
    }
}
