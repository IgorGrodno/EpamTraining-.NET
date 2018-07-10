using ManagersApp.DAL.EF;
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
    class GoodsRepository:IRepository<Goods>
    {

        private DataContext db;

        public GoodsRepository(DataContext context)
        {
            this.db = context;
        }

        public IEnumerable<Goods> GetAll()
        {
            return db.Goodses;
        }

        public Goods Get(int id)
        {
            Goods goods = db.Goodses.ToList<Goods>().Find(x => x.Id == id);
            return goods;
        }

        public Goods Get(string name)
        {
            Goods goods = db.Goodses.ToList<Goods>().Find(x => x.Name == name);
            return goods;
        }

        public void Add(Goods goods)
        {
            Goods tmpGoods = Get(goods.Name);
            if (tmpGoods==null)
            {
                db.Goodses.Add(goods);
            }                         
        }

        public void Update(Goods goods)
        {
            db.Entry(goods).State = EntityState.Modified;
        }

       

        public void Delete(int id)
        {
            Goods goods = Get(id);
            if (goods != null)
                db.Goodses.Remove(goods);
        }
    }
}
