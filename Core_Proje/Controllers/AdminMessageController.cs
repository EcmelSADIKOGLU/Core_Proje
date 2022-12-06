using BusinessLayer.Concrete;
using DataAccsessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Core_Proje.Controllers
{
    public class AdminMessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDAL());

        public IActionResult Inbox()
        {
            ViewBag.Page = "Gelen Mesajlar";
            ViewBag.Controller = "Mesajlar";
            ViewBag.IndexLink = "/AdminMessage/Inbox/";

            string mail = "admin@gmail.com";
            var messages = writerMessageManager.TGetList(x => x.Receiver == mail && x.Status);
            return View(messages);
        }
        public IActionResult Sendbox()
        {
            ViewBag.Page = "Gönderilen Mesajlar";
            ViewBag.Controller = "Mesajlar";
            ViewBag.IndexLink = "/AdminMessage/Inbox/";

            string mail = "admin@gmail.com";
            var messages = writerMessageManager.TGetList(x => x.Sender == mail && x.Status);
            return View(messages);
        }

        public IActionResult MessageDetailsForInbox(int id)
        {
            ViewBag.Page = "Mesaj Detayları";
            ViewBag.Controller = "Mesajlar";
            ViewBag.IndexLink = "/AdminMessage/Inbox/";
            var message = writerMessageManager.TGetByID(id);
            return View(message);
        }

        public IActionResult MessageDetailsForSendbox(int id)
        {
            ViewBag.Page = "Mesaj Detayları";
            ViewBag.Controller = "Mesajlar";
            ViewBag.IndexLink = "/AdminMessage/Inbox/";
            var message = writerMessageManager.TGetByID(id);
            return View(message);
        }
        public IActionResult Trashbox()
        {
            var message = writerMessageManager.TGetList(x => !x.Status);
            return View(message);
        }
        [HttpGet]
        public IActionResult NewMessage()
        {
            ViewBag.Page = "Yeni Mesaj";
            ViewBag.Controller = "Mesajlar";
            ViewBag.IndexLink = "/AdminMessage/Inbox/";
            return View();
        }
        [HttpPost]
        public IActionResult NewMessage(WriterMessage writerMessage)
        {
            writerMessage.Sender = "admin@gmail.com";
            writerMessage.SenderName = "Admin";
            writerMessage.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            writerMessage.ReceiverName = writerMessageManager.TGetNameByMail(writerMessage.Receiver);
            writerMessage.Status = true;
            writerMessageManager.TInsert(writerMessage);
            return RedirectToAction("Sendbox");
        }

        public IActionResult DeleteMessage(int id)
        {
            var message = writerMessageManager.TGetByID(id);
            writerMessageManager.TDelete(message);
            return RedirectToAction("Inbox");
        }

        public IActionResult TrashMessage(int id)
        {
            var message = writerMessageManager.TGetByID(id);
            message.Status = false;
            writerMessageManager.TUpdate(message);
            return RedirectToAction("Inbox");
        }

        public IActionResult RecycleMessage(int id)
        {
            var message = writerMessageManager.TGetByID(id);
            message.Status = true;
            writerMessageManager.TUpdate(message);
            return RedirectToAction("Trashbox");
        }

    }
}
