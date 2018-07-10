using ManagersWeb.Models;
using ManagersWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ManagersWeb.Services
{
    public class SaleService : IService<Sale>
    {
        private readonly IRepository<Sale> _repository;

        public SaleService(IRepository<Sale> repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(int id)
        {
             await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Sale>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Sale> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Sale> UpdateAsync(Sale item)
        {
            return await _repository.UpdateAsync(item);
        }
    }
}