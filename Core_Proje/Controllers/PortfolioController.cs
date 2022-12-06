using BusinessLayer.Concrete;
using BusinessLayer.ValidationRule;
using DataAccsessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class PortfolioController : Controller
    {
        PortfolioManager portfolioManager = new PortfolioManager(new EFPortfolioDAL());
        public IActionResult Index()
        {
            ViewBag.Page = "Proje Listesi";
            ViewBag.Controller = "Projelerim";
            ViewBag.IndexLink = "/Portfolio/Index";

            var values = portfolioManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddPortfolio()
        {
            ViewBag.Page = "Proje Ekle";
            ViewBag.Controller = "Projelerim";
            ViewBag.IndexLink = "/Portfolio/Index";

            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            PortfolioValidator validation = new PortfolioValidator();
            ValidationResult result = validation.Validate(portfolio);

            if (result.IsValid)
            {
                portfolioManager.TInsert(portfolio);
                return RedirectToAction("Index");
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

        public IActionResult DeletePortfolio(int id)
        {
            var portfolio = portfolioManager.TGetByID(id);
            portfolioManager.TDelete(portfolio);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            ViewBag.Page = "Proje Güncelle";
            ViewBag.Controller = "Projelerim";
            ViewBag.IndexLink = "/Portfolio/Index";

            var portfolio = portfolioManager.TGetByID(id);
            return View(portfolio);
        }

        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {

            PortfolioValidator validation = new PortfolioValidator();
            ValidationResult result = validation.Validate(portfolio);

            if (result.IsValid)
            {
                portfolioManager.TUpdate(portfolio);
                return RedirectToAction("Index");
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
