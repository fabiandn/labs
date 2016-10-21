using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample84
{
    class UnmangedWrapper : IDisposable
    {
        public FileStream Stream { get; set; }

        public UnmangedWrapper()
        {
            this.Stream = File.Open("temp.dat", FileMode.Create);
        }

        ~UnmangedWrapper()
        {
            Dispose(false);
        }

        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            Console.WriteLine("Disposed");
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (true)
            {
                if (Stream != null)
                {
                    Stream.Close();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (UnmangedWrapper res = new UnmangedWrapper())
            {

            }

        }
    }
}
