using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6LINQ
{
    class Customer
    {
        /*readonly int id;
        readonly string name;
        readonly int cityID;*/
        public int ID { get;  }
        public string Name { get; }
        public City City { get;  }
        public Customer(int id, string name, City city)
        {
            ID = id;
            Name = name;
            City = city;
        }

    }
}
