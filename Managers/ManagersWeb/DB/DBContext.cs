using ManagersWeb.Models;
using System.Data.Entity;

namespace ManagersWeb.DB
{
    public class DBContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Goods> Goodses { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Sale> Sales { get; set; }

        public DBContext()
            : base("DefaultConnection")
        {

        }
    }
}