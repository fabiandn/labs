using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample46
{
    interface IEntity
    {
        int Id { get; }
    }

    class Repository<T> where T : IEntity
    {
        protected IEnumerable<T> _elements;

        public Repository(IEnumerable<T> elements)
        {
            _elements = elements;
        }

        public T FindById(int id)
        {
            return _elements.SingleOrDefault(e => e.Id == id);
        }
    }

    class Order : IEntity
    {
        public int Id
        {
            get; set;
        }

        public int Amount { get; set; }
    }

    class OrderRepository: Repository<Order>
    {
        public OrderRepository(IEnumerable<Order> orders): base(orders)
        {

        }

        public IEnumerable<Order> FilterOrdersOnAmount(int amount)
        {
            return _elements.Where(o => o.Amount == amount);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order> { new Order { Id = 1, Amount = 10 }, new Order { Id = 2, Amount = 5 } };
            OrderRepository repo = new OrderRepository(orders);
            var order = repo.FilterOrdersOnAmount(10).FirstOrDefault();

            Console.WriteLine("My answer is: {0}", order.Amount);
        }
    }
}
