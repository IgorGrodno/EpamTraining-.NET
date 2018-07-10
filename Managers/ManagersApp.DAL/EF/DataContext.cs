using ManagersApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagersApp.DAL.EF
{
    public class DataContext : DbContext
    {

       public DbSet<Client> Clients { get; set; }
       public DbSet<Goods> Goodses { get; set; }
       public DbSet<Manager> Managers { get; set; }
       public DbSet<Sale> Sales { get; set; }

      

        public DataContext()
            : base("DefaultConnection")
        {
         
        }

       
    }
     
    
}

