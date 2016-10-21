using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample24
{
    public class Money
    {
        public decimal Amount { get; set; }

        public Money(decimal amount)
        {
            this.Amount = amount;
        }

        public static implicit operator decimal(Money obj)
        {
            return obj.Amount;
        }

        public   static explicit operator int(Money obj)
        {
            return (int)obj.Amount;
        }
    }
    class Program
    {
       
        static void Main(string[] args)
        {
            Money m = new Money(45M);
            decimal amount = m.Amount;
            int explicitAmount = (int)m.Amount;            
        }
    }
}
