using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz...")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz...")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz...")]
        [Compare("Password",ErrorMessage ="Şifreler birbiriyle aynı olmalı...")]
        public string ContifmPassword { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz...")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz...")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz...")]
        public string Surname { get; set; }
        public string ImageURL { get; set; }

    }
}
