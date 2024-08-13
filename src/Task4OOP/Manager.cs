using System.Collections.Generic;

namespace Task4OOP
{
    class Manager : Consultant, IManager
    {
        public Manager(Client client, Power power) : base(client, power) { }
        public Manager(IList<Client> clients, Power power) : base(clients, power) { }
        public override string View(int ind)
        {
            return clients[ind].PrintAll();
        }
        public void AddClient(Client client)
        {
            this.clients.Add(client);
            client.AddYourself(Autors.Autor.Manager);
        }
    }
}
