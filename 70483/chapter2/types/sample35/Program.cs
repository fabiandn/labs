using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample35
{ 
    internal class MyInternalClass
    {
        public void MyMethod()
        {
            Console.WriteLine("Hello World");
        }
    }

    internal class MyAnotherClass : MyInternalClass
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
            MyAnotherClass obj = new MyAnotherClass();
            obj.MyMethod();
        }
    }
}
