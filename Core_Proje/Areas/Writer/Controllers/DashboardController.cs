using DataAccsessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class DashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public DashboardController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v1 = user.Name + " " + user.Surname;

            //weather API
            string api = "c3642e33a8770358191ef99369b472bb";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=" + api;
            XDocument document = XDocument.Load(connection);
            ViewBag.v6 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            //statistics
            using (Context c = new Context())
            {
                ViewBag.v2 = c.WriterMessages.Where(x=> x.Receiver == user.Email).Count();
                ViewBag.v3 = c.Announcements.Count();
                ViewBag.v4 = c.Users.Count();
                ViewBag.v5 = c.Skills.Count();

            }

            return View();
        }
    }
}
//https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric%appid=c3642e33a8770358191ef99369b472bb