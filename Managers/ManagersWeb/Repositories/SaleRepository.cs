using ManagersWeb.DB;
using ManagersWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ManagersWeb.Repositories
{
    public class SaleRepository : IRepository<Sale>
    {

        public SaleRepository()
        { }

        public  Sale Get(int id)
        {
            Sale result = null;

            using (var Dbcontext = new DBContext())
            {
                result = Dbcontext.Sales.FirstOrDefault(f => f.Id == id);
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

        public async Task<IEnumerable<Sale>> GetByClientAsync(int clientId)
        {
            var result = new List<Sale>();

            using (var Dbcontext = new DBContext())
            {
                result = await (from sale in Dbcontext.Sales
                                where sale.ClientId == clientId
                                select sale).ToListAsync();
            }

            return result;
        }

        public async Task<IEnumerable<Sale>> GetByGoodsAsync(int godsId)
        {
            var result = new List<Sale>();

            using (var Dbcontext = new DBContext())
            {
                result = await (from sale in Dbcontext.Sales
                                where sale.GoodsId == godsId
                                select sale).ToListAsync();
            }

            return result;
        }

        public async Task<IEnumerable<Sale>> GetByManagerAsync(int managerId)
        {
            var result = new List<Sale>();

            using (var Dbcontext = new DBContext())
            {
                result = await (from sale in Dbcontext.Sales
                                where sale.ManagerId == managerId
                                select sale).ToListAsync();
            }

            return result;
        }

        public async Task<IEnumerable<Sale>> GetByDateAsync(DateTime startDate, DateTime endDate)
        {
            var result = new List<Sale>();

            using (var Dbcontext = new DBContext())
            {
                result = await (from sale in Dbcontext.Sales
                                where ((sale.Date >= startDate) && (sale.Date <= endDate))
                                select sale).ToListAsync();
            }

            return result;
        }

    }
}
