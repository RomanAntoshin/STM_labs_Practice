using System;

namespace Task6LINQ
{
    internal class ViewForThirdRequest
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int CityCode { get; set; }
        public int Count { get; set; }
        public DateTime LastDate { get; set; }
        public ViewForThirdRequest(string name, string city, int cityCode, int count, DateTime lastDate)// : this(name, city, cityCode)
        {
            Name = name;
            City = city;
            CityCode = cityCode;
            Count = count;
            LastDate = lastDate;
        }

        public override string ToString() => "Name: " + Name + " City: " + City + " Code: " + CityCode.ToString() + " Count: " + Count.ToString()
            + (LastDate == DateTime.MinValue ? "" : " Date: " + LastDate.ToString());
    }
}
