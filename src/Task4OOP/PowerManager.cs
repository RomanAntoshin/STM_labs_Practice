namespace Task4OOP
{
    class PowerManager : Power
    {
        public override void MakeRequest(Client client, Fields.Field field, TypesChanges.TypeChange typeChange, string newData)
        {
            client.MakeChanges(field, typeChange, Autors.Autor.Manager, newData);
        }
    }
}
