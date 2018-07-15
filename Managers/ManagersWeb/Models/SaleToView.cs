using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagersWeb.Models
{
    public class SaleToView
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string ManagerName { get; set; }
        public string GoodsName { get; set; }
        public DateTime Date { get; set; }
        public int Summ { get; set; }
    }
}