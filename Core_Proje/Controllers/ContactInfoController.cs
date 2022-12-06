using BusinessLayer.Concrete;
using DataAccsessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ContactInfoController : Controller
    {

        ContectManager contectManager = new ContectManager(new EFContectDAL());

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Page = "İletişim Bilgisi";
            ViewBag.Controller = "İletişim";
            ViewBag.IndexLink = "/Contact/Index";

            var values = contectManager.TGetByID(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(Contect contect)
        {
            contectManager.TUpdate(contect);
            return RedirectToAction("Index", "Default");
        }
    }
}
