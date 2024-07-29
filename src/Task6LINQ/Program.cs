using System;
using System.Collections.Generic;

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
            customers.Add(new Customer(1, "Tom", 1));
            customers.Add(new Customer(2, "Ben", 3));
            customers.Add(new Customer(3, "Helen", 1));
            customers.Add(new Customer(4, "John", 4));
            customers.Add(new Customer(5, "Donald", 4));
            customers.Add(new Customer(6, "Gwen", 1));
            customers.Add(new Customer(7, "Helen", 4));
        }
    }
}
