using Microsoft.AspNetCore.Http;

namespace Core_Proje.Areas.Writer.Models
{
    public class UserEditViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
        public string ImageURL { get; set; }
        public string Email { get; set; }
        public IFormFile Image { get; set; }



    }
}
