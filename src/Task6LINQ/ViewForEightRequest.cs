namespace Task6LINQ
{
    internal class ViewForEightRequest
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public ViewForEightRequest(string name, string city, int count, decimal sum)// : this(name, city)
        {
            Name = name;
            City = city;
            Count = count;
            Sum = sum;
        }
        public override string ToString() => "Name: " + Name.ToString() + " City: " + City.ToString() + " Count: " + Count.ToString() + " Sum: " + Sum.ToString();
    }
}
