using BLLevel.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLevel.BLL
{
    
     public interface IDTService
    {
        void WriteRecord(RecordDTO recordDTO);
        ClientDTO GetClient(int id);
        ClientDTO GetClient(string name);
        GoodsDTO GetGoods(int id);
        GoodsDTO GetGoods(string name);
        ManagerDTO GetManager(int id);
        ManagerDTO GetManager(string name);
        SaleDTO GetSale(int id);
       
        IEnumerable<ClientDTO> GetClients();
        IEnumerable<GoodsDTO> GetGoods();
        IEnumerable<ManagerDTO> GetManagers();
        IEnumerable<SaleDTO> GetSales();

        void Dispose();
    }
}
