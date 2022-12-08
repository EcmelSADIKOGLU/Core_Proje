using BusinessLayer.Concrete;
using DataAccsessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {

        SkillManager skillManager = new SkillManager(new EFSkillDAL());
        public IActionResult Index()
        {
            ViewBag.Page = "Yetenek Listesi";
            ViewBag.Controller = "Yetenek";
            ViewBag.IndexLink = "/Skill/Index";
            var values = skillManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.Page = "Yetenek Ekleme";
            ViewBag.Controller = "Yetenek";
            ViewBag.IndexLink = "/Skill/Index";
            
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            skillManager.TInsert(skill);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteSkill(int id)
        {
            var skill = skillManager.TGetByID(id);
            skillManager.TDelete(skill);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            ViewBag.Page = "Yetenek Güncelleme";
            ViewBag.Controller = "Yetenek";
            ViewBag.IndexLink = "/Skill/Index";
            var skill = skillManager.TGetByID(id);
            return View(skill);
        }
        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            skillManager.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}
