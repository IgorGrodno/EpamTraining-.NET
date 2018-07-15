using ManagersWeb.Models;
using ManagersWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ManagersWeb.Services
{
    public class ClientService: IService<Client>
    {
        
        private readonly IRepository<Client> _repository;

        public ClientService(IRepository<Client> repository)
        {
            _repository = repository;
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public Client Get(int id)
        {
            return  _repository.Get(id);
        }

        public async Task<Client> UpdateAsync(Client item)
        {
            return await _repository.UpdateAsync(item);
        }
    }
}
