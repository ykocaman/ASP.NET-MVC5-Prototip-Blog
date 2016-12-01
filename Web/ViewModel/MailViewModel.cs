using System.ComponentModel.DataAnnotations;

namespace Web.ViewModel
{
    public class MailViewModel
    {
        [Required, Display(Name = "İsminiz")]
        public string FromName { get; set; }

        [Required, Display(Name = "E-Posta adresi"), EmailAddress]
        public string FromEmail { get; set; }

        [Required,Display(Name= "Cep Telefonu"), Phone]
        public string Phone { get; set; }

        [Display(Name = "Kategori")]
        public string Category { get; set; }

        [Display(Name = "Gönderi")]
        public string Post { get; set; }

        [Required, Display(Name = "Konu"),]
        public string Subject { get; set; }

        [Required, Display(Name = "Mesaj"),]
        public string Message { get; set; }
    }
}