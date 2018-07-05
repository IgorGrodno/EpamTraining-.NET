using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLevel.BLL.DTO
{
    public class SaleDTO
    {
        private int _id;
        private int _managerId;
        private int _clientId;
        private int _goodsId;
        private DateTime _date;
        private int _summ;

        public SaleDTO(int id, int managerId, int clientId, int goodsId, DateTime date, int summ)
        {
            _id = id;
            _managerId = managerId;
            _clientId = clientId;
            _goodsId = goodsId;
            _date = date;
            _summ = summ;
        }

        public int GetId()
        {
            return _id;
        }

        public int GetManagerId()
        {
            return _managerId;
        }

        public int GetClientId()
        {
            return _clientId;
        }

        public int GetGoodsId()
        {
            return _goodsId;
        }

        public DateTime GetDate()
        {
            return _date;
        }

        public int GetSumm()
        {
            return _summ;
        }
    }
}
