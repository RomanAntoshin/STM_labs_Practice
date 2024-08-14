using System;
using System.Collections.Generic;
using System.Linq;

namespace Task6LINQ
{
    internal class Requests
    {
        private readonly List<Customer> customers;
        private readonly List<Order> orders;
        public Requests(List<Customer> customers, List<Order> orders)
        {
            this.customers = customers;
            this.orders = orders;
        }
        public List<Customer> FirstRequest()
        {
            return customers.Where(cust => cust.City.Name == "Los Angeles").ToList();
        }
        public int SecondRequest()
        {
            return customers.Count - orders.Select(order => order.Customer).Distinct().Count();
        }
        private Dictionary<Customer, int> GetCustomeraOrdersCount()
        {
            return customers.GroupJoin(orders, customer => customer, order => order.Customer, (customer, customerOrders) =>
            new { Customer = customer, Count = customerOrders.Count() }).ToDictionary(x => x.Customer, x => x.Count);
        }
        public ViewForThirdRequest[] ThirdRequest()
        {
            return customers.Select(customer => new ViewForThirdRequest(customer.Name, customer.City.Name,
                customer.City.CityCode, GetCustomeraOrdersCount()[customer],
                orders.Where(o => o.Customer == customer).DefaultIfEmpty().Max(o => o?.Date ?? DateTime.MinValue))).ToArray();
        }
        public Customer[] FourthRequest()
        {
            return GetCustomeraOrdersCount().Where(el => el.Value > 2).OrderBy(el => el.Key.Name).Select(el => el.Key).ToArray();
        }
        public IEnumerable<IGrouping<City, KeyValuePair<Customer, int>>> FivethRequest()
        {
            return GetCustomeraOrdersCount().Where(el => el.Value > 0).GroupBy(el => el.Key.City);
        }
        public List<Customer> SixthRequest()
        {
            return GetCustomeraOrdersCount().GroupBy(el => el.Key.City).
                SelectMany(group => group.Where(el => el.Value < group.Average(x => x.Value))).Select(el => el.Key).ToList();
        }
        public City SeventhRequest()
        {
            var sums = orders.GroupBy(o => o.Customer.City).ToDictionary(el => el.Key, el => el.Sum(p => p.Price));
            return sums.FirstOrDefault(x => x.Value == sums.Values.Max()).Key;
        }
        public ViewForEightRequest[] EightRequests(int count)
        {
            var pairs = GetCustomeraOrdersCount();
            return customers.Select(customer => new ViewForEightRequest(customer.Name, customer.City.Name, pairs[customer],
                orders.Where(el => el.Customer == customer).Sum(el => el.Price))).
                OrderBy(el => el.Sum).Take(Math.Min(count, customers.Count())).ToArray();
        }
    }
}
