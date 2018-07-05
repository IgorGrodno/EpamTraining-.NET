using ManagersApp.DAL.EF;
using ManagersApp.DAL.Entities;
using ManagersApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagersApp.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataContext db;
        private ClientRepository clientRepository;
        private GoodsRepository goodsRepository;
        private ManagerRepository managerRepository;
        private SaleRepository saleRepository;

        public UnitOfWork()
        {
            db = new DataContext();
        }
        public IRepository<Client> Clients
        {
            get
            {
                if (clientRepository == null)
                    clientRepository = new ClientRepository(db);
                return clientRepository;
            }
        }

        public IRepository<Goods> Goodses
        {
            get
            {
                if (goodsRepository == null)
                    goodsRepository = new GoodsRepository(db);
                return goodsRepository;
            }
        }
        public IRepository<Manager> Managers
        {
            get
            {
                if (managerRepository == null)
                    managerRepository = new ManagerRepository(db);
                return managerRepository;
            }
        }

        public IRepository<Sale> Sales
        {
            get
            {
                if (saleRepository == null)
                    saleRepository = new SaleRepository(db);
                return saleRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
