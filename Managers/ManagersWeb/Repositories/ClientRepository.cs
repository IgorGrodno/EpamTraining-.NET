using ManagersWeb.DB;
using ManagersWeb.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ManagersWeb.Repositories
{
    public class ClientRepository : IRepository<Client>
    {

        public ClientRepository()
        { }

        public async Task<Client> GetAsync(int id)
        {
            Client result = null;

            using (var Dbcontext = new DBContext())
            {
                result = await Dbcontext.Clients.FirstOrDefaultAsync(f => f.Id == id);
            }

            return result;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            var result = new List<Client>();

            using (var Dbcontext = new DBContext())
            {
                result = await Dbcontext.Clients.ToListAsync();
            }

            return result;
        }

        public async Task DeleteAsync(int id)
        {
            using (var Dbcontext = new DBContext())
            {
                var client = await Dbcontext.Clients.FirstOrDefaultAsync(f => f.Id == id);

                Dbcontext.Entry(client).State = EntityState.Deleted;

                await Dbcontext.SaveChangesAsync();
            }
        }

        public async Task<Client> UpdateAsync(Client client)
        {
            using (var Dbcontext = new DBContext())
            {
                Dbcontext.Entry(client).State = EntityState.Modified;

                await Dbcontext.SaveChangesAsync();
            }

            return client;
        }
    }
}
