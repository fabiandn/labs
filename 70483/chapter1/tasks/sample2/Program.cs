﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample2
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> t = Task.Run(()=> {
                return 42;
            });
            Console.WriteLine(t.Result);
        }
    }
}
