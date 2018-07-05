using ManagersApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagersApp.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Client> Clients { get; }
        IRepository<Goods> Goodses { get; }
        IRepository<Manager> Managers { get; }
        IRepository<Sale> Sales { get; }
        void Save();
    }
}
