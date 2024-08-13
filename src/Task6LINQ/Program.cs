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
            Console.WriteLine("Third Request");
            foreach (var el in requests.ThirdRequest())
            {
                Console.WriteLine(el.ToString());
            }
            Console.WriteLine("Fourth Request");
            foreach (var el in requests.FourthRequest())
            {
                Console.WriteLine(el.ToString());
            }
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
            foreach (var el in requests.SixthRequest())
            {
                Console.WriteLine(el.ToString());
            }
            Console.WriteLine("Seventh request");
            Console.WriteLine(requests.SeventhRequest().ToString());
            Console.WriteLine("Eight request");
            for(int i = 0; i<3; i++)
            {
                Console.WriteLine(requests.EightRequests()[i].ToString());
            }
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
    }
}
