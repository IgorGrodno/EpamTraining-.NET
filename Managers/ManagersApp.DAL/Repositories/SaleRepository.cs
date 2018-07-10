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
    class SaleRepository : IRepository<Sale>
    {
        private DataContext db;

        public SaleRepository(DataContext context)
        {
            this.db = context;
        }

        public IEnumerable<Sale> GetAll()
        {
            return db.Sales;
        }

        public Sale Get(int id)
        {
            return db.Sales.Find(id);
        }

        public void Add(Sale sale)
        {
            db.Sales.Add(sale);
        }

        public void Update(Sale sale)
        {
            db.Entry(sale).State = EntityState.Modified;
        }

       

        public void Delete(int id)
        {
            Sale sale = Get(id);
            if (sale != null)
                db.Sales.Remove(sale);
        }

        public Sale Get(string name)
        {
            throw new NotImplementedException();
        }
    }
}
