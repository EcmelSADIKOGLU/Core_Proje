using BusinessLayer.Concrete;
using DataAccsessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;


namespace Core_Proje.ViewComponents.Navbar
{
    public class NavbarMessage:ViewComponent
    {
        WriterMessageManager writerMessageManager = new WriterMessageManager(new EFWriterMessageDAL());

        public IViewComponentResult Invoke()
        {
            var mail = "admin@gmail.com";
            var values = writerMessageManager.TGetList(x=>x.Receiver == mail && x.Status).OrderByDescending(x=>x.WriterMessageID).Take(3).ToList();

            return View(values);
        }
    }
}
