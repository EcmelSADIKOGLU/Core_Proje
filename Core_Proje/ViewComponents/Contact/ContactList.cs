using BusinessLayer.Concrete;
using DataAccsessLayer.EntitiyFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Contact
{
    public class ContactList:ViewComponent
    {
        ContectManager contectManager = new ContectManager(new EFContectDAL());
        
        public IViewComponentResult Invoke()
        {
            var values = contectManager.TGetList();
            return View(values);
        }
    }
}
