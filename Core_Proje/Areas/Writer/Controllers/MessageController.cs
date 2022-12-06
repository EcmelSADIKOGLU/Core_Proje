using BusinessLayer.Concrete;
using BusinessLayer.ValidationRule;
using DataAccsessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Message")]
    public class MessageController : Controller
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDAL());
        private readonly UserManager<WriterUser> userManager;

        public MessageController(UserManager<WriterUser> _userManager)
        {
            userManager = _userManager;
        }

        [Route("Inbox")]
        public async Task<IActionResult> Inbox()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var values =  writerMessageManager.TGetList(x=>x.Receiver == user.Email && x.Status);
            return View(values);
        }

        [Route("Sendbox")]
        public async Task<IActionResult> Sendbox()
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var values = writerMessageManager.TGetList(x => x.Sender == user.Email && x.Status);
            return View(values);
        }

        [Route("Trashbox")]
        public IActionResult Trashbox(int id)
        {
            var values = writerMessageManager.TGetList(x => !x.Status);
            return View(values);
        }

        [Route("RecycleMessage/{id}")]
        public IActionResult RecycleMessage(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            values.Status = true;
            writerMessageManager.TUpdate(values);
            return RedirectToAction("Inbox");
        }

        [Route("TrashMessage/{id}")]
        public IActionResult TrashMessage(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            values.Status = false;
            writerMessageManager.TUpdate(values);
            return RedirectToAction("Sendbox");
        }

        [Route("DeleteMessage/{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            writerMessageManager.TDelete(values);
            return RedirectToAction("Inbox");
        }

        [Route("MessageDetailsForInbox/{id}")]
        public IActionResult MessageDetailsForInbox(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            return View(values);
        }

        [Route("MessageDetailsForSendbox/{id}")]
        public IActionResult MessageDetailsForSendbox(int id)
        {
            var values = writerMessageManager.TGetByID(id);
            return View(values);
        }

        [Route("NewMessage")]
        [HttpGet]
        public IActionResult NewMessage()
        {
            return View();
        }
        [Route("NewMessage")]
        [HttpPost]
        public async Task<IActionResult> NewMessage(WriterMessage writerMessage)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            writerMessage.Status = true;
            writerMessage.Sender = user.Email;
            writerMessage.SenderName = user.Name + " " + user.Surname;
            writerMessage.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            writerMessage.ReceiverName = writerMessageManager.TGetNameByMail(writerMessage.Receiver);

            WriterMessageValidator validator = new WriterMessageValidator();
            ValidationResult result = validator.Validate(writerMessage);

            if (result.IsValid)
            {
                writerMessageManager.TInsert(writerMessage);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
