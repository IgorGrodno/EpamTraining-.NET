using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLevel.BLL.DTO
{
    public class RecordDTO
    {
        private int _id;
        private string _manager;
        private string _client;
        private string _goods;
        private DateTime _date;
        private int _summ;

        public RecordDTO(int id, string manager, string client, string goods, DateTime date, int summ)
        {
            _id = id;
            _manager = manager;
            _client = client;
            _goods = goods;
            _date = date;
            _summ = summ;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetManager()
        {
            return _manager;
        }

        public string GetClient()
        {
            return _client;
        }

        public string GetGoods()
        {
            return _goods;
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
