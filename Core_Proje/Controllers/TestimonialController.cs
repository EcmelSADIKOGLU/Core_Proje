using BusinessLayer.Concrete;
using DataAccsessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Core_Proje.Controllers
{
    public class TestimonialController : Controller
    {
        TestimonialManager testimonialManager = new TestimonialManager(new EFTestimonialDAL());
        public IActionResult Index()
        {
            ViewBag.Page = "Referans Listesi";
            ViewBag.Controller = "Referans";
            ViewBag.IndexLink = "/Testimonial/Index";
            var values = testimonialManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddTestimonial()
        {
            ViewBag.Page = "Referans Ekle";
            ViewBag.Controller = "Referans";
            ViewBag.IndexLink = "/Testimonial/Index";
            return View();

        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {
            testimonialManager.TInsert(testimonial);
            return RedirectToAction("Index");

        }

        public IActionResult DeleteTestimonial(int id)
        {
            var testimonial = testimonialManager.TGetByID(id);
            testimonialManager.TDelete(testimonial);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditTestimonial(int id)
        {
            var testimonial = testimonialManager.TGetByID(id);
            ViewBag.Page = "Referans Detayları";
            ViewBag.Controller = "Referans";
            ViewBag.IndexLink = "/Testimonial/Index";
            return View(testimonial);

        }
        [HttpPost]
        public IActionResult EditTestimonial(Testimonial testimonial)
        {
            testimonialManager.TUpdate(testimonial);
            return RedirectToAction("Index");
        }

    }
}
