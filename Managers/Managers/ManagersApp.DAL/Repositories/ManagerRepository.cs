using ManagersApp.DAL.EF;
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
    class ManagerRepository : IRepository<Manager>
    {

        private DataContext db;

        public ManagerRepository(DataContext context)
        {
            this.db = context;
        }

        public IEnumerable<Manager> GetAll()
        {
            return db.Managers;
        }

        public Manager Get(int id)
        {
            Manager manager = db.Managers.ToList<Manager>().Find(x => x.Id == id);
            return manager;
        }

        public Manager Get(string name)
        {
            Manager manager = db.Managers.ToList<Manager>().Find(x => x.Name == name);
            return manager;
        }

        public void Add(Manager manager)
        {
            Manager tmpManager = Get(manager.Name);
            if (tmpManager == null)
            {
                db.Managers.Add(manager);
            }
        }

        public void Update(Manager manager)
        {
            db.Entry(manager).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Manager manager = Get(id);
            if (manager != null)
            {
                db.Managers.Remove(manager);
            }
        }
    }
}
