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
            List<Customer> customers=new List<Customer>();
            customers.Add(new Customer(1, "Tom", cities[0]));
            customers.Add(new Customer(2, "Ben", cities[2]));
            customers.Add(new Customer(3, "Helen", cities[0]));
            customers.Add(new Customer(4, "John", cities[3]));
            customers.Add(new Customer(5, "Donald", cities[3]));
            customers.Add(new Customer(6, "Gwen", cities[0]));
            customers.Add(new Customer(7, "Helen", cities[3]));
            List<Order> orders = new List<Order>();
            orders.Add(new Order(1, customers[3], 50, new DateTime(2024, 5, 1)));
            orders.Add(new Order(2, customers[6], 91, new DateTime(2023, 11, 30)));
            orders.Add(new Order(3, customers[3], 234, new DateTime(2024, 9, 12)));
            orders.Add(new Order(4, customers[5], 121, new DateTime(2024, 5, 6)));
            FirstPequest(customers);
        }
        static void FirstPequest(List<Customer> customers)
        {
            List<Customer> data = customers.Where(cust => cust.City.Name == "Los Angeles").ToList();
            foreach (var el in data)
                Console.WriteLine(el.ToString());
        }

    }
}
