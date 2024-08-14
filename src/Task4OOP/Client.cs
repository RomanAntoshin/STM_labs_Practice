using System;
using System.Collections.Generic;

namespace Task4OOP
{
    class Client
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public string SeriesPasport { get; set; }
        public string NumberPasport { get; set; }
        public List<History> History { get; set; }
        public Client(string surname, string name, string patronymic, string phoneNumber, string seriesPasport, string numberPasport)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            SeriesPasport = seriesPasport;
            NumberPasport = numberPasport;
            if (History == null)
            {
                History = new List<History>();
            }
        }
        public string PrintSecret()
        {
            return Surname + "\n" + Name + "\n" + Patronymic + "\n" + PhoneNumber + "\n" + "****" + "\n" + "******" + "\n";
        }
        public string PrintAll()
        {
            return Surname + "\n" + Name + "\n" + Patronymic + "\n" + PhoneNumber + "\n" + SeriesPasport + "\n" + NumberPasport + "\n";
        }
        public void MakeChanges(Fields.Field field, TypesChanges.TypeChange typechange, Autors.Autor autor, string newData)
        {
            switch (field)
            {
                case Fields.Field.Surname:
                    this.Surname = newData;
                    break;
                case Fields.Field.Name:
                    this.Name = newData;
                    break;
                case Fields.Field.Patronymic:
                    this.Patronymic = newData;
                    break;
                case Fields.Field.SeriesPasport:
                    this.SeriesPasport = newData;
                    break;
                case Fields.Field.NumberPasport:
                    this.NumberPasport = newData;
                    break;
                case Fields.Field.PhoneNumber:
                    this.PhoneNumber = newData;
                    break;
                default:
                    throw new Exception();
            }
            History.Add(new History(DateTime.Now, field.ToString(), typechange.ToString(), autor.ToString()));
        }
        public void AddYourself(Autors.Autor autor)
        {
            History.Add(new History(DateTime.Now, Fields.Field.All.ToString(), TypesChanges.TypeChange.Add.ToString(), autor.ToString()));
        }
    }
}
