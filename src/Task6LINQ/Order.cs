using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6LINQ
{
    class Order
    {
        readonly int id;
        readonly string customerID;
        readonly decimal price;
        readonly DateTime date;
        public int ID { get; }
        public string CustomerID { get; }
        public decimal Price { get; }
        public DateTime Date { get; }
        public Order(int id, string customerID, decimal price, DateTime date)
        {
            this.id = id;
            this.customerID = customerID;
            this.price = price;
            this.date = date;
        }

    }
}
