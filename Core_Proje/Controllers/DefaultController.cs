using BusinessLayer.Concrete;
using DataAccsessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace Core_Proje.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            MessageManager messageManager = new MessageManager(new EFMessageDAL());
            message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.Status = true;
            messageManager.TInsert(message);
            var json = JsonConvert.SerializeObject(message);
            return Json(json);
        }
    }
}
