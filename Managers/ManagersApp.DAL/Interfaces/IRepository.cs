using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagersApp.DAL.Interfaces
{
    
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Get(string name);
        
        void Add(T item);
        void Update(T item);
        void Delete(int id);
    }
}
