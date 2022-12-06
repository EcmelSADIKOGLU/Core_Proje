using BusinessLayer.Concrete;
using DataAccsessLayer.EntitiyFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    [Authorize]
    public class DefaultController : Controller
    {

        AnnouncementManager announcementManager = new AnnouncementManager(new EFAnnouncementDAL());

        public IActionResult Index()
        {
            var values = announcementManager.TGetList();
            return View(values);
        }

        public IActionResult AnnouncementDetails(int id)
        {
            var value = announcementManager.TGetByID(id);
            return View(value);
        }
    }
}
