using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.ViewModel
{
    public class UserViewModel
    {
        [Display(Name = "E-Posta")]
        [Required(ErrorMessage = "E-Posta adresi gereklidir")]
        public String Email { get; set; }

        [Display(Name = "Parola")]
        [Required(ErrorMessage = "Parola gereklidir")]
        public String Password { get; set; }
    }
}