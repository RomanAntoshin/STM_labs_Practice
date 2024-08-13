using System;

namespace Task4OOP
{
    class History
    {
        public DateTime DateTime { get; }
        public string DataChanged { get; }
        public string Type { get; }
        public string Autor { get; }
        public History(DateTime dateTime, string dataChanged, string type, string autor)
        {
            DateTime = dateTime;
            DataChanged = dataChanged;
            Type = type;
            Autor = autor;
        }
    }
}
