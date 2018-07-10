using ManagersWeb.DB;
using ManagersWeb.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ManagersWeb.Repositories
{
    public class ManagerRepository : IRepository<Manager>
    {

        public ManagerRepository()
        { }

        public async Task<Manager> GetAsync(int id)
        {
            Manager result = null;

            using (var Dbcontext = new DBContext())
            {
                result = await Dbcontext.Managers.FirstOrDefaultAsync(f => f.Id == id);
            }

            return result;
        }

        public async Task<IEnumerable<Manager>> GetAllAsync()
        {
            var result = new List<Manager>();

            using (var Dbcontext = new DBContext())
            {
                result = await Dbcontext.Managers.ToListAsync();
            }

            return result;
        }

        public async Task DeleteAsync(int id)
        {
            using (var Dbcontext = new DBContext())
            {
                var manager = await Dbcontext.Managers.FirstOrDefaultAsync(f => f.Id == id);

                Dbcontext.Entry(manager).State = EntityState.Deleted;

                await Dbcontext.SaveChangesAsync();
            }
        }

        public async Task<Manager> UpdateAsync(Manager manager)
        {
            using (var Dbcontext = new DBContext())
            {
                Dbcontext.Entry(manager).State = EntityState.Modified;

                await Dbcontext.SaveChangesAsync();
            }

            return manager;
        }
    }
}
