namespace Task4OOP
{
    abstract class Power
    {
        abstract public void MakeRequest(Client client, Fields.Field field, TypesChanges.TypeChange typeChange, string newData);
    }
}
