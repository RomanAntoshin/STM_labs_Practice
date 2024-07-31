using System;

namespace Task6LINQ
{
    class Order
    {
        public int ID { get; }
        public Customer Customer { get; }
        public decimal Price { get; }
        public DateTime Date { get; }
        public Order(int id, Customer customer, decimal price, DateTime date)
        {
            ID = id;
            Customer = customer;
            Price = price;
            Date = date;
        }
        public override string ToString() => "ID: " + ID.ToString() + " Customer: //" + Customer.ID.ToString() + " Price: //" + Price.ToString() + "Date: //" + Date.ToString();
    }
}
