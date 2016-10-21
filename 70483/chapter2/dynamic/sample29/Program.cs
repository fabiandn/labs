using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample29
{
    public class SampleObject : DynamicObject
    {
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = binder.Name;
            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            dynamic obj = new SampleObject();
            Console.WriteLine(obj.MyProperty);
        }
    }
}
