using BusinessLayer.Concrete;
using DataAccsessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
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
            p.Status = true;
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
