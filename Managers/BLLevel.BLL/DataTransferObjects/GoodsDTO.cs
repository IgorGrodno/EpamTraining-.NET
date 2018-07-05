using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLevel.BLL.DTO
{
    public class GoodsDTO
    {
        private int _id;
        private string _name;

        public GoodsDTO(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public int GetId()
        {
            return _id;
        }

        public string GetName()
        {
            return _name;
        }
    }
}
