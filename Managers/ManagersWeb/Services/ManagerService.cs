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

        public Manager Get(int id)
        {
            return _repository.Get(id);
        }

        public async Task<Manager> UpdateAsync(Manager item)
        {
            return await _repository.UpdateAsync(item);
        }
    }
}