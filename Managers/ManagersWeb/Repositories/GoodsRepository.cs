using ManagersWeb.DB;
using ManagersWeb.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ManagersWeb.Repositories
{
    public class GoodsRepository:IRepository<Goods>
    {
        
            public GoodsRepository()
            { }

            public async Task<Goods> GetAsync(int id)
            {
                Goods result = null;

                using (var Dbcontext = new DBContext())
                {
                    result = await Dbcontext.Goodses.FirstOrDefaultAsync(f => f.Id == id);
                }

                return result;
            }

            public async Task<IEnumerable<Goods>> GetAllAsync()
            {
                var result = new List<Goods>();

            using (var Dbcontext = new DBContext())
            {
                    result = await Dbcontext.Goodses.ToListAsync();
                }

                return result;
            }

            public async Task DeleteAsync(int id)
            {
            using (var Dbcontext = new DBContext())
            {
                    var goods = await Dbcontext.Goodses.FirstOrDefaultAsync(f => f.Id == id);

                   Dbcontext.Entry(goods).State = EntityState.Deleted;

                    await Dbcontext.SaveChangesAsync();
                }
            }

            public async Task<Goods> UpdateAsync(Goods goods)
            {
            using (var Dbcontext = new DBContext())
            {
                    Dbcontext.Entry(goods).State = EntityState.Modified;

                    await Dbcontext.SaveChangesAsync();
                }

                return goods;
            }
        }
    }
