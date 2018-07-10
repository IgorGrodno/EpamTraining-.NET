using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagersWeb.Services
{
    public interface IService<T> where T : class
    {        
            Task<T> GetAsync(int id);
            Task<IEnumerable<T>> GetAllAsync();
            Task DeleteAsync(int id);
            Task<T> UpdateAsync(T item);        
    }
}
