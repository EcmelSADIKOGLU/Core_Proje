using BusinessLayer.Concrete;
using DataAccsessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EFExperienceDAL());
        public IActionResult Index()
        {
            ViewBag.Page = "Deneyim Listesi";
            ViewBag.Controller = "Deneyim";
            ViewBag.IndexLink = "/Experience/Index/";

            var values = experienceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddExperience()
        {
            ViewBag.Page = "Deneyim Ekle";
            ViewBag.Controller = "Deneyim";
            ViewBag.IndexLink = "/Experience/Index/";

            return View();
        }

        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            experienceManager.TInsert(experience);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteExperience(int id)
        {
            var experience = experienceManager.TGetByID(id);
            experienceManager.TDelete(experience);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditExperience(int id)
        {
            ViewBag.Page = "Deneyim Güncelle";
            ViewBag.Controller = "Deneyim";
            ViewBag.IndexLink = "/Experience/Index/";

            var experience = experienceManager.TGetByID(id);
            return View(experience);
        }

        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            experienceManager.TUpdate(experience);
            return RedirectToAction("Index");
        }
    }
}
