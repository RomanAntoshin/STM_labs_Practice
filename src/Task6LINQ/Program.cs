using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Task6LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<City> cities = new List<City>();
            cities.Add(new City(0, "Anchorage", 907));
            cities.Add(new City(1, "Boston", 617));
            cities.Add(new City(2, "Chicago", 312));
            cities.Add(new City(3, "Los Angeles", 213));
            cities.Add(new City(4, "New York", 212));
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer(0, "Tom", cities[0]));
            customers.Add(new Customer(1, "Ben", cities[2]));
            customers.Add(new Customer(2, "Helen", cities[4]));
            customers.Add(new Customer(3, "Alex", cities[3]));
            customers.Add(new Customer(4, "Donald", cities[3]));
            customers.Add(new Customer(5, "Gwen", cities[0]));
            customers.Add(new Customer(6, "Helen", cities[3]));
            List<Order> orders = new List<Order>();
            orders.Add(new Order(1, customers[3], 50, new DateTime(2024, 5, 1)));
            orders.Add(new Order(2, customers[6], 91, new DateTime(2023, 11, 30)));
            orders.Add(new Order(3, customers[3], 234, new DateTime(2024, 9, 12)));
            orders.Add(new Order(4, customers[5], 121, new DateTime(2024, 5, 6)));
            orders.Add(new Order(5, customers[2], 78, new DateTime(2024, 1, 9)));
            orders.Add(new Order(0, customers[3], 150, new DateTime(2024, 5, 21)));
            orders.Add(new Order(6, customers[2], 94, new DateTime(2024, 1, 9)));
            orders.Add(new Order(7, customers[2], 178, new DateTime(2024, 10, 9)));
            FirstRequest(customers);
            SecondRequest(customers, orders);
            //ThirdRequest
            Console.WriteLine("ThirdRequest");
            View[] views=new View[customers.Count];
            //DateTime[] lastOrders=new DateTime[views.Length];
            var pairs= GetCustomeraOrdersCount(customers, orders);
            for (int i=0;i<views.Length;i++)
            {
                //System.InvalidOperationException
                views[i] = new View();
                views[i].Name = customers[i].Name;
                views[i].City = customers[i].City.Name;
                views[i].CityCode = customers[i].City.CityCode;
                //var pairs = GetCustomeraOrdersCount(customers, orders);
                views[i].Count = pairs[customers[i]];
                try 
                {
                    views[i].LastDate = orders.Where(el => el.Customer == customers[i]).Max(o => o.Date);
                }
                catch(InvalidOperationException)
                {
                    views[i].LastDate = DateTime.MinValue;
                }
                Console.WriteLine(views[i].ToString());
            }
            FourthRequest(customers, orders);
            FivethRequest(customers, orders);
            SixthRequest(customers, orders);
            SeventhRequest(customers, orders);
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
            var pairs = GetCustomeraOrdersCount(customers, orders);
            var filteredPairs = pairs.Where(el => el.Value > 2).OrderBy(el => el.Key.Name);
            foreach (var el in filteredPairs)
            {
                Console.WriteLine(el.Key.ToString());
            }
        }
        static void FivethRequest(List<Customer> customers, List<Order> orders)
        {
            Console.WriteLine("FivethRequest");
            var pairs = GetCustomeraOrdersCount(customers, orders);
            var filteredPairs = pairs.Where(el => el.Value > 0).GroupBy(el => el.Key.City);
            foreach (var group in filteredPairs)
            {
                Console.WriteLine(group.Key.Name);
                foreach (var el in group)
                {
                    Console.WriteLine(el.Key.Name + " " + el.Value);
                }
            }
        }
        static void SixthRequest(List<Customer> customers, List<Order> orders)
        {
            Console.WriteLine("Sixth Request");
            var pairs=GetCustomeraOrdersCount(customers, orders);
            var filteredPairs = pairs.GroupBy(el => el.Key.City);
            foreach (var group in filteredPairs)
            {
                double averageValue = group.Average(el => el.Value);
                foreach (var el in group)
                {
                    if (el.Value < averageValue)
                    {
                        Console.WriteLine(el.Key.ToString());
                    }
                }
            }
        }
        static Dictionary<Customer, int> GetCustomeraOrdersCount(List<Customer> customers, List<Order> orders)
        {
            var pairs = customers.ToDictionary(el => el, el => 0);
            foreach (var customer in orders.Select(o => o.Customer))
            {
                if (pairs.ContainsKey(customer))
                {
                    pairs[customer]++;
                }
            }
            return pairs;
        }
        /*static Dictionary<Customer, int> GetCustomeraOrdersCount(List<Customer> customers, List<Order> orders, DateTime[] lastOrder)
        {
            var pairs = customers.ToDictionary(el => el, el => 0);
            var _customers=orders.Select(o => o.Customer);
            for(int i=0; i<orders.Count; i++)
            {
                //DateTime date;
                if(pairs.ContainsKey(orders[i].Customer))
                {
                    pairs[orders[i].Customer]++;
                    lastOrder[i] = orders[i].Date;
                    //date=orders[i].Date;
                }
            }
            return pairs;
        }*/
        static void SeventhRequest(List<Customer> customers, List<Order> orders)
        {
            Console.WriteLine("Seventh Request:");
            var sums = orders.GroupBy(o => o.Customer.City).ToDictionary(el => el.Key, el => el.Sum(p => p.Price));
            Console.WriteLine(sums.FirstOrDefault(x => x.Value == sums.Values.Max()).Key);
        }
        struct View
        {
            public string Name { get; set; }
            public string City { get; set; }
            public int CityCode { get; set; }
            public int Count { get; set; }
            public DateTime LastDate { get; set; }
            public override string ToString() => "Name: " + Name + " City: " + City + " Code: " + CityCode.ToString() + " Count: " + Count.ToString() + (LastDate==DateTime.MinValue ? "" :" Date: " + LastDate.ToString());
        }

    }
}
