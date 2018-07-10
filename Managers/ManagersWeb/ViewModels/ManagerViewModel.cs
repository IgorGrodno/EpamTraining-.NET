using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagersWeb.ViewModels
{
    public class ManagerViewModel
    {
        public string Title { get; set; }
        public string AddButtonTitle { get; set; }
        public string RedirectUrl { get; set; }

        public int Id { get; set; }

        [Display(Name = "Manager Name")]
        [Required(ErrorMessage = ("Manager Name is required.")), RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Only alphabetic characters are allowed.")]
        public string Name { get; set; }
    }
}