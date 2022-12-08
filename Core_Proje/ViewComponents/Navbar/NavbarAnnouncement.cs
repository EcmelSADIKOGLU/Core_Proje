using BusinessLayer.Concrete;
using DataAccsessLayer.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje.ViewComponents.Navbar
{
    public class NavbarAnnouncement:ViewComponent
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EFAnnouncementDAL());
        public IViewComponentResult Invoke()
        {
            var values = announcementManager.TGetList().OrderByDescending(x => x.AnnouncementID).Take(5).ToList();
            return View(values);
        }
    }
}
