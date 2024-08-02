using System;
using System.Collections.Generic;
using System.Linq;

namespace Task6LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<City> cities = new List<City>();
            cities.Add(new City(1, "Anchorage", 907));
            cities.Add(new City(2, "Boston", 617));
            cities.Add(new City(3, "Chicago", 312));
            cities.Add(new City(4, "Los Angeles", 213));
            cities.Add(new City(5, "New York", 212));
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer(1, "Tom", cities[0]));
            customers.Add(new Customer(2, "Ben", cities[2]));
            customers.Add(new Customer(3, "Helen", cities[0]));
            customers.Add(new Customer(4, "Alex", cities[3]));
            customers.Add(new Customer(5, "Donald", cities[3]));
            customers.Add(new Customer(6, "Gwen", cities[0]));
            customers.Add(new Customer(7, "Helen", cities[3]));
            List<Order> orders = new List<Order>();
            orders.Add(new Order(2, customers[3], 50, new DateTime(2024, 5, 1)));
            orders.Add(new Order(3, customers[6], 91, new DateTime(2023, 11, 30)));
            orders.Add(new Order(4, customers[3], 234, new DateTime(2024, 9, 12)));
            orders.Add(new Order(5, customers[5], 121, new DateTime(2024, 5, 6)));
            orders.Add(new Order(6, customers[2], 78, new DateTime(2024, 1, 9)));
            orders.Add(new Order(1, customers[3], 150, new DateTime(2024, 5, 21)));
            orders.Add(new Order(7, customers[2], 94, new DateTime(2024, 1, 9)));
            orders.Add(new Order(8, customers[2], 178, new DateTime(2024, 10, 9)));
            FirstRequest(customers);
            SecondRequest(customers, orders);
            //ThirdRequest
            /*View[] views = new View[customers.Count];
            Dictionary<Customer, int> pairs = new Dictionary<Customer, int>();
            for(int i=0; i<views.Count(); i++)
            {
                views[i] = new View();
                views[i].Name = customers[i].Name;
            }
            for(int i=0; i<orders.Count; i++)
            {
                if(pairs.ContainsKey(orders[i].Customer))
                {
                    pairs[orders[i].Customer]++;
                }
            }*/
            //FourthRequest
            FourthRequest(customers, orders);
        }
        static void FirstRequest(List<Customer> customers)
        {
            Console.WriteLine("First request:");
            List<Customer> data = customers.Where(cust => cust.City.Name == "Los Angeles").ToList();
            foreach (var el in data)
                Console.WriteLine(el.ToString());
        }
        static void SecondRequest(List<Customer> customers, List<Order> orders)
        {
            Console.WriteLine("Second request:");
            int pairs = customers.Count - orders.Select(order => order.Customer).Distinct().Count();
            Console.WriteLine(pairs);
        }
        static void FourthRequest(List<Customer> customers, List<Order> orders)
        {
            Console.WriteLine("Fourth request:");
            var pairs = customers.ToDictionary(el => el, el => 0);
            foreach (var customer in orders.Select(o => o.Customer))
            {
                if (pairs.ContainsKey(customer))
                {
                    pairs[customer]++;
                }
            }
            var filteredPairs = pairs.Where(el => el.Value > 2).OrderBy(el => el.Key.Name);
            foreach (var el in filteredPairs)
            {
                Console.WriteLine(el.Key.ToString());
            }
        }
        struct View
        {
            public string Name { get; set; }
            public string City { get; set; }
            public int CityCode { get; set; }
            public int Count { get; set; }
            public DateTime LastDate { get; set; }
            public override string ToString() => "Name: " + Name + " City: " + City + " Code: " + CityCode.ToString() + " Count: " + Count.ToString() + " Date: " + LastDate.ToString();
        }

    }
}
