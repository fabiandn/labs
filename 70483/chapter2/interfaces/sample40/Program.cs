using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample40
{
    interface ILeft
    {
        void Move();
    }

    interface IRight
    {
        void Move();
    }

    class MoveableObject : ILeft, IRight
    {
        void IRight.Move()
        {
            Console.WriteLine("Move Right");
        }

        void ILeft.Move()
        {
            Console.WriteLine("Move Left");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MoveableObject obj = new MoveableObject();
            ((IRight)obj).Move();
            ((ILeft)obj).Move();
        }
    }
}
