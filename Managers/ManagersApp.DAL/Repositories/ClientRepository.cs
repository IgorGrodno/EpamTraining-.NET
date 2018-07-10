using ManagersApp.DAL.DC;
using ManagersApp.DAL.Entities;
using ManagersApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagersApp.DAL.Repositories
{
    class ClientRepository: IRepository<Client>
    {        
        private DataContext db;

        public ClientRepository(DataContext context)
        {
            this.db = context;
        }

        public IEnumerable<Client> GetAll()
        {
            return db.Clients;
        }

        public Client Get(int id)
        {
            Client client = db.Clients.ToList<Client>().Find(x => x.Id ==id);
            return client;
        }

        public Client Get(string name)
        {
            Client client = db.Clients.ToList<Client>().Find(x => x.Name == name);
            return client;
        }

        public void Add(Client client)
        {
            Client tmpClient = Get(client.Name);
            if (tmpClient==null)
            {
                db.Clients.Add(client);
            }
        }

        public void Update(Client client)
        {
            db.Entry(client).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Client client = Get(id);
            if (client != null)
            {
                db.Clients.Remove(client);
            }
        }
    }
}

