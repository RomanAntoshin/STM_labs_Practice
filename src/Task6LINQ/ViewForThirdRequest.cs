using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6LINQ
{
    internal class ViewForThirdRequest
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int CityCode { get; set; }
        public int Count { get; set; }
        public DateTime LastDate { get; set; }
        public ViewForThirdRequest(string name, string city, int cityCode)
        {
            Name = name;
            City = city;
            CityCode = cityCode;
        }
        public override string ToString() => "Name: " + Name + " City: " + City + " Code: " + CityCode.ToString() + " Count: " + Count.ToString() 
            + (LastDate == DateTime.MinValue ? "" : " Date: " + LastDate.ToString());
    }
}
