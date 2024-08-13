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
        public ViewForThirdRequest[] ThirdRequest()
        {
            ViewForThirdRequest[] views = new ViewForThirdRequest[customers.Count];
            var pairs = GetCustomeraOrdersCount();
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
                };
            }
            return views;
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
            List<Customer> ret = new List<Customer>();
            var filteredPairs = GetCustomeraOrdersCount().GroupBy(el => el.Key.City);
            foreach (var group in filteredPairs)
            {
                double averageValue = group.Average(el => el.Value);
                foreach (var el in group)
                {
                    if (el.Value < averageValue)
                    {
                        ret.Add(el.Key);
                    }
                }
            }
            return ret;
        }
        public City SeventhRequest()
        {
            var sums = orders.GroupBy(o => o.Customer.City).ToDictionary(el => el.Key, el => el.Sum(p => p.Price));
            return sums.FirstOrDefault(x => x.Value == sums.Values.Max()).Key;
        }
        public ViewForEightRequest[] EightRequests()
        {
            ViewForEightRequest[] views = new ViewForEightRequest[customers.Count];
            var pairs = GetCustomeraOrdersCount();
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
            return views.OrderBy(el => el.Sum).ToArray();
        }
    }
}
