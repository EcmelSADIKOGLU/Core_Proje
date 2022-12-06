using BusinessLayer.Concrete;
using DataAccsessLayer.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.SocialMedia
{
    public class SocialMediaList:ViewComponent
    {
        SosialMediaManager sosialMediaManager = new SosialMediaManager(new EFSosialMediaDAL());
        public IViewComponentResult Invoke()
        {
            var values = sosialMediaManager.TGetList();
            return View(values);
        }
    }
}
