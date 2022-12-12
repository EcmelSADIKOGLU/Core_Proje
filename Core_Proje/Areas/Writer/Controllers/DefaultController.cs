using BusinessLayer.Concrete;
using DataAccsessLayer.EntitiyFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Default")]
    [Authorize]
    public class DefaultController : Controller
    {

        AnnouncementManager announcementManager = new AnnouncementManager(new EFAnnouncementDAL());
        [Route("Index")]
        public IActionResult Index()
        {
            var values = announcementManager.TGetList();
            return View(values);
        }
        [Route("AnnouncementDetails/{id}")]
        public IActionResult AnnouncementDetails(int id)
        {
            var value = announcementManager.TGetByID(id);
            return View(value);
        }
    }
}
