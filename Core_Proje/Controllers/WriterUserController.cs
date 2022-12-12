using BusinessLayer.Concrete;
using DataAccsessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Proje.Controllers
{
    public class WriterUserController : Controller
    {
        WriterManager writerManager = new WriterManager(new EFWriterDAL());
        public IActionResult Index()
        { 
            return View();
        }

        public IActionResult WriterList()
        {
            var writers = writerManager.TGetList();
            var json = JsonConvert.SerializeObject(writers);
            return Json(json);
        }

        public IActionResult AddWriter(WriterUser p)
        {
            writerManager.TInsert(p);
            var json = JsonConvert.SerializeObject(p);
            return Json(json);
        }
    }
}
