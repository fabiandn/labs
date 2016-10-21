using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace sample97
{
    class Program
    {
        static void Main(string[] args)
        {
            ExceptionDispatchInfo info = null;

            try
            {
                var value = Console.ReadLine();
                int convertValue = int.Parse(value);
            }
            catch (FormatException e)
            {
                info = ExceptionDispatchInfo.Capture(e);
            }

            if (info != null)
            {
                info.Throw();
            }
        }
    }
}
