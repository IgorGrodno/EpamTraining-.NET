using ManagersWeb.Models;
using ManagersWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ManagersWeb.Services
{
    public class SaleService 
    {
        private readonly SaleRepository _repository;

        public SaleService(SaleRepository repository)
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

        public Sale GetAsync(int id)
        {
            return _repository.Get(id);
        }

        public async Task<IEnumerable<Sale>> GetByManagerAsync(int id)
        {
            return await _repository.GetByManagerAsync(id);
        }

        public async Task<IEnumerable<Sale>> GetByClientAsync(int id)
        {
            return await _repository.GetByClientAsync(id);
        }

        public async Task<IEnumerable<Sale>> GetByGoodsAsync(int id)
        {
            return await _repository.GetByGoodsAsync(id);
        }

        public async Task<IEnumerable<Sale>> GetByDateAsync(DateTime startDate, DateTime endDate)
        {
            return await _repository.GetByDateAsync(startDate,endDate);
        }


    }
}