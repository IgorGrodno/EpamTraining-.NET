using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagersWeb.ViewModels
{
    public class SaleViewModel
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string Manager { get; set; }
        public string Goods { get; set; }
        public DateTime Date { get; set; }
        public int Summ { get; set; }   
        public string RedirectUrl { get; set; }
    }
}