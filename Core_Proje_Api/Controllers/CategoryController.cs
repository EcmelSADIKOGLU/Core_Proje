using Core_Proje_Api.DAL.ApiContext;
using Core_Proje_Api.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Core_Proje_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        Context c = new Context();

        [HttpGet]
        public IActionResult CategoryList()
        {
            return Ok(c.Categories.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryByID(int id)
        {
            var category = c.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }
        }

        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {

            c.Add(category);
            c.SaveChanges();
            return Created("", category);
        }

        [HttpDelete]

        public IActionResult DeleteCategory(int id)
        {
            var value = c.Categories.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                c.Categories.Remove(value);
                c.SaveChanges();
                return NoContent();
            }
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category p)
        {
            var category = c.Categories.Find(p.CategoryID);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                category.CategoryName = p.CategoryName;
                c.Update(category);
                c.SaveChanges();
                return NoContent();
            }
        }
    }
}
