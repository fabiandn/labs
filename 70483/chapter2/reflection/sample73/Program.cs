using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace sample73
{
    public class MyClassA
    {
        private int MyProperty { get; set; }
        public MyClassA()
        {
            this.MyProperty = 55;
        }
    }

    public class MyClassB
    {
        public static void DumpObject(object obj)
        {
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var fieldInfo in fields)
            {
                if (fieldInfo.FieldType == typeof(int))
                {
                    Console.WriteLine(fieldInfo.GetValue(obj));
                }
            }            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClassB.DumpObject(new MyClassA());
            int i = 42;
            MethodInfo compareToMethod = i.GetType().GetMethod("CompareTo", new Type[] { typeof(int)});
            int result = (int)compareToMethod.Invoke(i, new object[] { 41 });
            Console.WriteLine("The result: {0}", result);
        }
    }
}
