using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6LINQ
{
    class Customer
    {
        readonly int id;
        readonly string name;
        readonly int cityID;
        public int ID { get { return id; } }
        string Name { get; }
        int CityID { get; }
        public Customer(int id, string name, int cityID)
        {
            this.id = id;
            this.name = name;
            this.cityID = cityID;
        }

    }
}
