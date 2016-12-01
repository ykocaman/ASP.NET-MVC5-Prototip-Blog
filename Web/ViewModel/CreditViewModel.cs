using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.ViewModel
{
    public class CreditViewModel
    {
        [Required, Display(Name= "Kart Sahibi")]
        public string Holder { get; set; }

        [Required, Display(Name="Numara"), StringLength(4)]
        public string Number1 { get; set; }

        [Required, Display(Name = "Numara"), StringLength(4)]
        public string Number2 { get; set; }

        [Required, Display(Name = "Numara"), StringLength(4)]
        public string Number3 { get; set; }

        [Required, Display(Name = "Numara"), StringLength(4)]
        public string Number4 { get; set; }

        [Required, Display(Name = "Son Kullanma Tarihi"), StringLength(2)]
        public string Month { get; set; }

        [Required, Display(Name = "Son Kullanma Tarihi"), StringLength(2)]
        public string Year { get; set; }

        [Required, Display(Name="Güvenlik Kodu"), StringLength(3)]
        public string CVC { get; set; }
    }
}