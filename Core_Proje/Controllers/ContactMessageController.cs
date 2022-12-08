using BusinessLayer.Concrete;
using DataAccsessLayer.EntitiyFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EFMessageDAL());
        public IActionResult Index()
        {
            ViewBag.Page = "Gelen Mesajlar";
            ViewBag.Controller = "İletişim";
            ViewBag.IndexLink = "/ContactMessage/Index/";
            var values = messageManager.TGetList();
            return View(values);
        }

        public IActionResult MessageDetails(int id)
        {
            ViewBag.Page = "Mesaj Detayları";
            ViewBag.Controller = "İletişim";
            ViewBag.IndexLink = "/ContactMessage/Index/";
            var message = messageManager.TGetByID(id);
            return View(message);
        }
        public IActionResult DeleteMessage(int id)
        {

            var message = messageManager.TGetByID(id);
            messageManager.TDelete(message);
            return RedirectToAction("Index");
        }
    }
}
