using ManagersWeb.Models;
using ManagersWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ManagersWeb.Services
{
    public class ManagerService
    {
        private readonly IRepository<Manager> _repository;

        public ManagerService(IRepository<Manager> repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Manager>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Manager> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<Manager> UpdateAsync(Manager item)
        {
            return await _repository.UpdateAsync(item);
        }
    }
}