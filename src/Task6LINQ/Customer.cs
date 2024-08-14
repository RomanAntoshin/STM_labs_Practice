namespace Task6LINQ
{
    class Customer
    {
        public int ID { get; }
        public string Name { get; }
        public City City { get; }
        public Customer(int id, string name, City city)
        {
            ID = id;
            Name = name;
            City = city;
        }
        public override string ToString() => "ID: " + ID.ToString() + "// Name: " + Name.ToString() + "// City: " + City.ID.ToString();
    }
}
