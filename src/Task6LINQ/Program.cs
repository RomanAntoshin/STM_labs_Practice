using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

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
            Requests requests = new Requests(customers, orders);
            Console.WriteLine("First request:");
            foreach(var el in requests.FirstRequest())
            {
                Console.WriteLine(el.ToString());
            }
            Console.WriteLine("Second request");
            Console.WriteLine(requests.SecondRequest());
            Console.WriteLine("ThirdRequest");
            foreach (var el in requests.ThirdRequest())
            {
                Console.WriteLine(el.ToString());
            }
            //FirstRequest(customers);
            //SecondRequest(customers, orders);
            ThirdRequest(customers, orders);  
            FourthRequest(customers, orders);
            FivethRequest(customers, orders);
            SixthRequest(customers, orders);
            SeventhRequest(customers, orders);
            EightRequest(customers, orders);
            PointF[] square = new PointF[] { new PointF(0, 0), new PointF(0, 1), new PointF(1, 0), new PointF(1, 1) };
            Random rnd = new Random();
            double size = 1e8;
            //double count = 0;
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Start();
            PointF[] points = new PointF[(int)size];
            for(int i=0;i<size;i++)
            {
                points[i] = new PointF((float)rnd.NextDouble(), (float)rnd.NextDouble());
            }
            var part = points.SelectMany(p => square.Select(s => GetDistance(s, p))).Where(d => d < 0.5).Count();
            stopwatch.Stop();
            Console.WriteLine("Sequential operation time: " + stopwatch.ElapsedMilliseconds);
            stopwatch.Restart();
            part=points.AsParallel().SelectMany(p=> square.Select(s => GetDistance(s, p))).Where(d => d < 0.5).Count();
            stopwatch.Stop();
            Console.WriteLine("Parallel operation time: " + stopwatch.ElapsedMilliseconds);
            Console.WriteLine(4 * (part/size));
        }
        static double GetDistance(PointF a, PointF b)
        {
            double deltaX = b.X - a.X;
            double deltaY = b.Y - a.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
        /*static void FirstRequest(List<Customer> customers)
        {
            Console.WriteLine("First request:");
            List<Customer> data = customers.Where(cust => cust.City.Name == "Los Angeles").ToList();
            foreach (var el in data)
                Console.WriteLine(el.ToString());
        }*/
        /*static void SecondRequest(List<Customer> customers, List<Order> orders)
        {
            Console.WriteLine("Second request:");
            int pairs = customers.Count - orders.Select(order => order.Customer).Distinct().Count();
            Console.WriteLine(pairs);
        }*/
        static void ThirdRequest(List<Customer> customers, List<Order> orders)
        {
            Console.WriteLine("ThirdRequest");
            ViewForThirdRequest[] views = new ViewForThirdRequest[customers.Count];
            var pairs = GetCustomeraOrdersCount(customers, orders);
            for (int i = 0; i < views.Length; i++)
            {
                views[i] = new ViewForThirdRequest(customers[i].Name, customers[i].City.Name, customers[i].City.CityCode);
                views[i].Count = pairs[customers[i]];
                try
                {
                    views[i].LastDate = orders.Where(el => el.Customer == customers[i]).Max(o => o.Date);
                }
                catch (InvalidOperationException)
                {
                    views[i].LastDate = DateTime.MinValue;
                }
                Console.WriteLine(views[i].ToString());
            }
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
        static void SeventhRequest(List<Customer> customers, List<Order> orders)
        {
            Console.WriteLine("Seventh Request:");
            var sums = orders.GroupBy(o => o.Customer.City).ToDictionary(el => el.Key, el => el.Sum(p => p.Price));
            Console.WriteLine(sums.FirstOrDefault(x => x.Value == sums.Values.Max()).Key);
        }
        static void EightRequest(List<Customer> customers, List<Order> orders)
        {
            Console.WriteLine("Eight request");
            ViewForEightRequest[] views = new ViewForEightRequest[customers.Count];
            var pairs = GetCustomeraOrdersCount(customers, orders);
            decimal[] sums = new decimal[views.Length];
            for (int i = 0; i < views.Length; i++)
            {
                views[i] = new ViewForEightRequest(customers[i].Name, customers[i].City.Name);
                views[i].Count = pairs[customers[i]];
                try
                {
                    views[i].Sum = orders.Where(el => el.Customer == customers[i]).Select(el => el.Price).Sum();
                }
                catch (InvalidOperationException)
                {
                    views[i].Sum = 0;
                }
            }
            var sortedViews = views.OrderBy(el => el.Sum).ToArray();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(sortedViews[i].ToString());
            }
        }
        class ViewForThirdRequest
        {
            public string Name { get; set; }
            public string City { get; set; }
            public int CityCode { get; set; }
            public int Count { get; set; }
            public DateTime LastDate { get; set; }
            public ViewForThirdRequest(string name, string city, int cityCode)
            {
                Name = name;
                City = city;
                CityCode = cityCode;
            }
            public override string ToString() => "Name: " + Name + " City: " + City + " Code: " + CityCode.ToString() + " Count: " + Count.ToString() + (LastDate==DateTime.MinValue ? "" :" Date: " + LastDate.ToString());
        }
        class ViewForEightRequest
        {
            public string Name { get; set; }
            public string City { get; set; }
            public int Count { get; set; }
            public decimal Sum { get; set; }
            public ViewForEightRequest(string name, string city)
            {
                Name = name;
                City = city;
            }
            public override string ToString() => "Name: " + Name.ToString() + " City: " + City.ToString() + " Count: " + Count.ToString() + " Sum: " + Sum.ToString();
        }
    }
}
