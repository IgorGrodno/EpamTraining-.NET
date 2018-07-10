using ManagersWeb.DB;
using ManagersWeb.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ManagersWeb.Repositories
{
    public class SaleRepository : IRepository<Sale>
    {

        public SaleRepository()
        { }

        public async Task<Sale> GetAsync(int id)
        {
            Sale result = null;

            using (var Dbcontext = new DBContext())
            {
                result = await Dbcontext.Sales.FirstOrDefaultAsync(f => f.Id == id);
            }

            return result;
        }

        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            var result = new List<Sale>();

            using (var Dbcontext = new DBContext())
            {
                result = await Dbcontext.Sales.ToListAsync();
            }

            return result;
        }

        public async Task DeleteAsync(int id)
        {
            using (var Dbcontext = new DBContext())
            {
                var sale = await Dbcontext.Sales.FirstOrDefaultAsync(f => f.Id == id);

                Dbcontext.Entry(sale).State = EntityState.Deleted;

                await Dbcontext.SaveChangesAsync();
            }
        }

        public async Task<Sale> UpdateAsync(Sale sale)
        {
            using (var Dbcontext = new DBContext())
            {
                Dbcontext.Entry(sale).State = EntityState.Modified;

                await Dbcontext.SaveChangesAsync();
            }

            return sale;
        }
    }
}
