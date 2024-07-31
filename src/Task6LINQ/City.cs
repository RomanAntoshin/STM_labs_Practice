namespace Task6LINQ
{
    class City
    {
        public int ID { get; }
        public string Name { get; }
        public int CityCode { get; }
        public City(int id, string name, int cityCode)
        {
            ID = id;
            Name = name;
            CityCode = cityCode;
        }
        public override string ToString() => "ID: " + ID.ToString() + "// Name: " + Name.ToString() + "// CityCode: " + CityCode.ToString();
    }
}
