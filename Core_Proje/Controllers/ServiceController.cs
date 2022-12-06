using BusinessLayer.Concrete;
using DataAccsessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EFServiceDAL());
        public IActionResult Index()
        {
            ViewBag.Page = "Hizmet Listesi";
            ViewBag.Controller = "Hizmetlerim";
            ViewBag.IndexLink = "/Service/Index";

            var values = serviceManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddService()
        {
            ViewBag.Page = "Hizmet Ekleme";
            ViewBag.Controller = "Hizmetlerim";
            ViewBag.IndexLink = "/Service/Index";
;
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            serviceManager.TInsert(service);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteService(int id)
        {
            var service =  serviceManager.TGetByID(id);
            serviceManager.TDelete(service);   
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditService(int id)
        {
            ViewBag.Page = "Hizmet Güncelleme";
            ViewBag.Controller = "Hizmetlerim";
            ViewBag.IndexLink = "/Service/Index";

            var service = serviceManager.TGetByID(id);
            return View(service);
        }

        [HttpPost]
        public IActionResult EditService(Service service)
        {
            serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }
    }
}
