using System;
using System.Collections.Generic;

namespace Task6LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<City> cities = new List<City>
            {
            new City(0, "Anchorage", 907),
            new City(1, "Boston", 617),
            new City(2, "Chicago", 312),
            new City(3, "Los Angeles", 213),
            new City(4, "New York", 212)
            };
            List<Customer> customers = new List<Customer>()
            {
                 new Customer(0, "Tom", cities[0]),
                 new Customer(1, "Ben", cities[2]),
                 new Customer(2, "Helen", cities[4]),
                 new Customer(3, "Alex", cities[3]),
                 new Customer(4, "Donald", cities[3]),
                 new Customer(5, "Gwen", cities[0]),
                 new Customer(6, "Helen", cities[3])
            };
            List<Order> orders = new List<Order>()
            {
                new Order(1, customers[3], 50, new DateTime(2024, 5, 1)),
                new Order(2, customers[6], 91, new DateTime(2023, 11, 30)),
                new Order(3, customers[3], 234, new DateTime(2024, 9, 12)),
                new Order(4, customers[5], 121, new DateTime(2024, 5, 6)),
                new Order(5, customers[2], 78, new DateTime(2024, 1, 9)),
                new Order(0, customers[3], 150, new DateTime(2024, 5, 21)),
                new Order(6, customers[2], 94, new DateTime(2024, 1, 9)),
                new Order(7, customers[2], 178, new DateTime(2024, 10, 9))
            };
            Requests requests = new Requests(customers, orders);
            Console.WriteLine("First request:");
            Print(requests.FirstRequest());
            Console.WriteLine("Second request");
            Console.WriteLine(requests.SecondRequest());
            Console.WriteLine("Third Request");
            Print(requests.ThirdRequest());
            Console.WriteLine("Fourth Request");
            Print(requests.FourthRequest());
            Console.WriteLine("Fiveth Request");
            foreach (var group in requests.FivethRequest())
            {
                Console.WriteLine(group.Key.Name);
                foreach (var el in group)
                {
                    Console.WriteLine(el.Key.Name + " " + el.Value);
                }
            }
            Console.WriteLine("Sixth Request");
            Print(requests.SixthRequest());
            Console.WriteLine("Seventh request");
            Console.WriteLine(requests.SeventhRequest().ToString());
            Console.WriteLine("Eight request");
            Print(requests.EightRequests(3));
            long sequential;
            long parallel;
            LinqVsPLinq.Run(out sequential, out parallel);
            Console.WriteLine("Sequential operation time: " + sequential);
            Console.WriteLine("Parallel operation time: " + parallel);
        }
        public static void Print(IEnumerable<object> values)
        {
            foreach (var value in values) Console.WriteLine(value.ToString());
        }
    }
}
