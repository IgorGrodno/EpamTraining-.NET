using BLLevel.BLL;
using BLLevel.BLL.DTO;
using ManagersApp.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managers
{
    public static class ShowDataBase
    {
        public static void Show()
        {
            BLLevel.BLL.DTService dTService = new DTService(new UnitOfWork());

            foreach (ManagerDTO item in dTService.GetManagers())
            {
                Console.WriteLine(item.GetName());
            }
            Console.WriteLine();

            foreach (ClientDTO item in dTService.GetClients())
            {
                Console.WriteLine(item.GetName());
            }
            Console.WriteLine();

            foreach (GoodsDTO item in dTService.GetGoods())
            {
                Console.WriteLine(item.GetName());
            }
            Console.WriteLine();

            foreach (SaleDTO item in dTService.GetSales())
            {
                ManagerDTO manager= dTService.GetManager(item.GetManagerId());
                ClientDTO client= dTService.GetClient(item.GetClientId());
                GoodsDTO goodsd=dTService.GetGoods(item.GetGoodsId());

                Console.WriteLine(item.GetDate() + " " +manager.GetName() + " " 
                    + client.GetName() + " " + goodsd.GetName() + " "
                    + item.GetSumm());
            }
        }
    }
}
