using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagersWeb.ViewModels
{
    public class SaleViewModel
    {
        public string Title { get; set; }
        public string AddButtonTitle { get; set; }
        public string RedirectUrl { get; set; }

        public int Id { get; set; }

        [Display(Name = "Start date")]
        [Required(ErrorMessage = ("Date is required."))]
        public DateTime StartDate { get; set; }

        [Display(Name = "End date")]
        [Required(ErrorMessage = ("Date is is required."))]
        public DateTime EndDate { get; set; }
    }
}