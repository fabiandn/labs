using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample85
{
    
    class Program
    {
        static WeakReference data;

        public static void Run()
        {
            object result = GetData();
            result = GetData();
        }

        public static object GetData()
        {
            if (data == null)
            {
                data = new WeakReference(LoadLargerList());
            }

            if (data.Target == null)
            {
                data.Target = LoadLargerList();
            }

            return data.Target;
        }

        private static object LoadLargerList()
        {
            return Enumerable.Range(0, 1000000);
        }

        static void Main(string[] args)
        {
            Run();
            Console.WriteLine("Run");
        }
    }
}
