using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
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
