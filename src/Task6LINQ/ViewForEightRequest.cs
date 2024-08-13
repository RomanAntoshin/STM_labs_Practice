using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6LINQ
{
    internal class ViewForEightRequest
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
