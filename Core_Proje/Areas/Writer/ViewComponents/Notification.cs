using BusinessLayer.Concrete;
using DataAccsessLayer.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Core_Proje.Areas.Writer.ViewComponents
{
    [Area("Writer")]
    public class Notification: ViewComponent
    {
        AnnouncementManager announcementManager = new AnnouncementManager(new EFAnnouncementDAL());
       
        public IViewComponentResult Invoke()
        {
            var values = announcementManager.TGetList().Take(5).ToList();
            return View(values);
        }
    }
}
