
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core_Proje.Areas.Writer.ViewComponents
{
    [Area("Writer")]
    public class NavbarProfil:ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public NavbarProfil(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = user.ImagerURL;
            return View();
        }
    }
}
