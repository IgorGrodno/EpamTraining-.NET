using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagersWeb.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ManagerId { get; set; }
        public int GoodsId { get; set; }
        public DateTime Date { get; set; }
        public int Summ { get; set; }
    }
}
