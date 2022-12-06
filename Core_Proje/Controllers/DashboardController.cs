using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Page = "Dashboard Sayfası";
            ViewBag.Controller = "Dashboard";
            ViewBag.IndexLink = "/Dashboard/Index";
            return View();
        }
    }
}
