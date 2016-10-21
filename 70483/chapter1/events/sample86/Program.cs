using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample86
{
    public class Pub
    {
        public event EventHandler OnChange;

        public void Raise()
        {
            var exceptions = new List<Exception>();

            foreach (Delegate  handler in OnChange.GetInvocationList())
            {
                try
                {
                    handler.DynamicInvoke(this, EventArgs.Empty);
                }
                catch (Exception e)
                {
                    exceptions.Add(e);
                }
            }

            if (exceptions.Any())
            {
                throw new AggregateException(exceptions);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Pub p = new Pub();

            p.OnChange += (sender, e) =>
            {
                Console.WriteLine("Evento 1");
            };

            p.OnChange += (sender, e) =>
            {
                throw new Exception("Opps");
            };

            p.OnChange += (sender, e) =>
            {
                Console.WriteLine("Evento 3");
            };

            try
            {
                p.Raise();
            }
            catch (AggregateException e)
            {
                Console.WriteLine("Count {0}", e.InnerExceptions.Count());
            }
        }
    }
}
