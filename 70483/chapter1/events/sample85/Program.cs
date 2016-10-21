using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample85
{
    public class MyArgs : EventArgs
    {
        public MyArgs(int value)
        {
            this.Value = value;
        }

        public int Value { get; set; }
    }

    public class Pub
    {
        private event EventHandler<MyArgs> onChange = delegate { };

        public event EventHandler<MyArgs> OnChange
        {
            add
            {
                lock (onChange)
                {
                    onChange += value;
                }
            }
            remove
            {
                lock (onChange)
                {
                    onChange -= value;
                }
            }
        }

        public void Raise()
        {
            onChange(this, new MyArgs(42));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Pub p = new Pub();
            p.OnChange += (sender, e) =>
            {
                Console.WriteLine("Event raised: {0}", e.Value);
            };

            p.Raise();
        }
    }
}
