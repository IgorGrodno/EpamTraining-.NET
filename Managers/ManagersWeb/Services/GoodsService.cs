using ManagersWeb.Models;
using ManagersWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ManagersWeb.Services
{
    public class GoodsService
    {
        private readonly IRepository<Goods> _repository;

        public GoodsService(IRepository<Goods> repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Goods>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Goods> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Goods> UpdateAsync(Goods item)
        {
            return await _repository.UpdateAsync(item);
        }
    }
}