using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample41
{
    public interface IExample
    {
        string GetResult();
        int Value { get; set; }
        event EventHandler ResultRetrieved;
        int this[string index] { get;  }
    }

    public class ExampleImplementation : IExample
    {
        public int this[string index]
        {
            get
            {
                return 42;
            }

            set
            {
                
            }
        }

        public int Value
        {
            get; set;
        }

        private event EventHandler resultRetrieved = delegate { };
        public event EventHandler ResultRetrieved
        {
            add
            {
                lock (resultRetrieved)
                {
                    resultRetrieved += value;
                }
            }
            remove
            {
                lock (resultRetrieved)
                {
                    resultRetrieved -= value;
                }
            }
        }

        public string GetResult()
        {
            resultRetrieved(this, new EventArgs());
            return "result";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ExampleImplementation obj = new ExampleImplementation();

            obj.ResultRetrieved += (sender, e) =>
            {
                Console.WriteLine("My value {0}", obj["0"]);
            };

            Console.WriteLine(obj.GetResult());
        }
    }
}
