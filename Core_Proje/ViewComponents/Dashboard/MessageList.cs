using BusinessLayer.Concrete;
using DataAccsessLayer.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Policy;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class MessageList:ViewComponent
    {
        MessageManager messageManager = new MessageManager(new EFMessageDAL());
        public IViewComponentResult Invoke()
        {
            var values = messageManager.TGetList().OrderByDescending(x=>x.MessageID).Take(5).ToList();
            return View(values);
        }
    }
}
