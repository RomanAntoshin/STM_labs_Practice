namespace Task4OOP
{
    class PowerConsultant : Power
    {
        public override void MakeRequest(Client client, Fields.Field field, TypesChanges.TypeChange typeChange, string newData)
        {
            if (field == Fields.Field.PhoneNumber && newData != "")
            {
                client.MakeChanges(field, typeChange, Autors.Autor.Consultant, newData);
            }
        }
    }
}
