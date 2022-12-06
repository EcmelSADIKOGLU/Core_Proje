using BusinessLayer.Concrete;
using DataAccsessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class SocialMediaController : Controller
    {
        SosialMediaManager socialMediaManager = new SosialMediaManager(new EFSosialMediaDAL());
        public IActionResult Index()
        {
            ViewBag.Page = "Sosyal Medya";
            ViewBag.Controller = "İletişim";
            ViewBag.IndexLink = "/SocialMedia/Index";

            var values =  socialMediaManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            ViewBag.Page = "Yeni Sosyal Medya";
            ViewBag.Controller = "İletişim";
            ViewBag.IndexLink = "/SocialMedia/Index";

            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(SosialMedia p)
        {
            socialMediaManager.TInsert(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var p = socialMediaManager.TGetByID(id);
            socialMediaManager.TDelete(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSocialMedia(int id)
        {
            ViewBag.Page = "Sosyal Medya Düzenleme";
            ViewBag.Controller = "İletişim";
            ViewBag.IndexLink = "/SocialMedia/Index";

            var p = socialMediaManager.TGetByID(id);
            return View(p);
        }

        [HttpPost]
        public IActionResult EditSocialMedia(SosialMedia p)
        {
            socialMediaManager.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
