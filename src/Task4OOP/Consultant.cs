using System.Collections.Generic;

namespace Task4OOP
{
    class Consultant : IConsultant
    {
        protected IList<Client> clients;
        protected Power power;
        public int Length { get { return clients.Count; } }
        public IList<Client> Clients { get { return clients; } }
        public Consultant(Client client, Power power)
        {
            this.clients = new List<Client> { client };
            this.power = power;
        }
        public Consultant(IList<Client> clients, Power power)
        {
            this.clients = clients;
            this.power = power;
        }
        public virtual string View(int ind)
        {
            return clients[ind].PrintSecret();
        }
        public void ChangeData(int ind, Fields.Field field, string newData)
        {
            power.MakeRequest(clients[ind], field, TypesChanges.TypeChange.Update, newData);
        }
    }
}
