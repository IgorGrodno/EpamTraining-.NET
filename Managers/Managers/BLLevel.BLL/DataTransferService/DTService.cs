using AutoMapper;
using BLLevel.BLL.DTO;
using ManagersApp.DAL.Entities;
using ManagersApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLevel.BLL
{
    public class DTService:IDTService
    {

        IUnitOfWork _dataBase;
        Object blockObject = new object();
        public DTService(IUnitOfWork unitOfWork)
            {
                _dataBase = unitOfWork;
            }           

            public void Dispose()
            {
                _dataBase.Dispose();
            }

        public void WriteRecord(RecordDTO recordDTO)
        {
            lock (blockObject)
            {
                Manager manager = new Manager { Id = new Random().Next(), Name = recordDTO.GetManager() };
                Goods goods = new Goods { Id = new Random().Next(), Name = recordDTO.GetGoods() };
                Client client = new Client { Id = new Random().Next(), Name = recordDTO.GetClient() };

                _dataBase.Managers.Add(manager);
                _dataBase.Goodses.Add(goods);
                _dataBase.Clients.Add(client);
                _dataBase.Save();

                _dataBase.Sales.Add(new Sale
                {
                    Id = new Random().Next(),
                    ClientId = GetClient(recordDTO.GetClient()).GetId(),
                    ManagerId = GetManager(recordDTO.GetManager()).GetId(),
                    GoodsId = GetGoods(recordDTO.GetGoods()).GetId(),
                    Date = recordDTO.GetDate(),
                    Summ = recordDTO.GetSumm()
                });


                _dataBase.Save();
            }
        }
        public ClientDTO GetClient(int id)
        {
            var Client = _dataBase.Clients.Get(id);
            if (Client == null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                return new ClientDTO(Client.Id, Client.Name);
            }
        }

        public ClientDTO GetClient(string name)
        {
            var Client = _dataBase.Clients.Get(name);
            if (Client == null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                return new ClientDTO(Client.Id, Client.Name);
            }
        }

        public GoodsDTO GetGoods(int id)
        {
            var Goods = _dataBase.Goodses.Get(id);
            if (Goods == null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                return new GoodsDTO(Goods.Id, Goods.Name);
            }
        }

        public GoodsDTO GetGoods(string name)
        {
            var Goods = _dataBase.Goodses.Get(name);
            if (Goods == null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                return new GoodsDTO(Goods.Id, Goods.Name);
            }
        }

        public ManagerDTO GetManager(string name)
        {
            var Manager = _dataBase.Managers.Get(name);
            if (Manager == null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                return new ManagerDTO(Manager.Id, Manager.Name);
            }
        }

        public ManagerDTO GetManager(int id)
        {
            var Manager = _dataBase.Managers.Get(id);
            if (Manager == null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                return new ManagerDTO(Manager.Id,Manager.Name);
            }
        }

        public SaleDTO GetSale(int id)
        {
            var Sale = _dataBase.Sales.Get(id);
            if (Sale == null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                return new SaleDTO(Sale.Id,Sale.ManagerId,Sale.ClientId, Sale.GoodsId,Sale.Date,Sale.Summ);
            }
        }

        public IEnumerable<ClientDTO> GetClients()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Client, ClientDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Client>, List<ClientDTO>>(_dataBase.Clients.GetAll());
        }

        public IEnumerable<GoodsDTO> GetGoods()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Goods,GoodsDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Goods>, List<GoodsDTO>>(_dataBase.Goodses.GetAll());
        }

        public IEnumerable<ManagerDTO> GetManagers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Manager, ManagerDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Manager>, List<ManagerDTO>>(_dataBase.Managers.GetAll());
        }

        public IEnumerable<SaleDTO> GetSales()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Sale, SaleDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Sale>, List<SaleDTO>>(_dataBase.Sales.GetAll());
        }
    }
    }

