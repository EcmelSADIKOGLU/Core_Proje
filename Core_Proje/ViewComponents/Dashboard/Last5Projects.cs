using DataAccsessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class Last5Projects:ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            
            return View(c.Portfolios.ToList());
        }
    }
}
