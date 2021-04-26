using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SidmachStore.Models;
using SidmachStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SidmachStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : Controller
    {
        private readonly ICategory _category;

        public CategorysController(ICategory category)
        {
            _category = category;

        }


        [HttpGet]
        [Route("api/[controller]")]

        public IActionResult GetCategory()
        {
            return Ok(_category.GetCategory());
        }


        [HttpGet]
        [Route("api/[controller]/{id}")]

        public IActionResult GetCategory(Guid id)
        {
            var category = _category.GetCategory(id);

            if (category != null)
            {
                return Ok(category);

            }

            return NotFound($"The category with id : {id} was not found ");
        }


        [HttpPost]
        [Route("api/[controller]")]

        public IActionResult GetCategorys(Category category)
        {
            _category.AddCategory(category);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" +
                category.Id, category);
        }



        [HttpDelete]
        [Route("api/[controller]/{id}")]

        public IActionResult DeleteCategory(Guid id)
        {
            var category = _category.GetCategory(id);

            if (category != null)
            {
                _category.DeleteCategory(category);
                return Ok($"The category with id: { id} was deleted! ");

            }

            return NotFound($"The category with id : {id} was not found ");
        }


        [HttpPatch]
        [Route("api/[controller]/{id}")]


        public IActionResult Editcategory(Guid id, Category category)
        {
            var existingCategory = _category.GetCategory(id);

            if (existingCategory != null)
            {
                category.Id = existingCategory.Id;
                _category.EditCategory(existingCategory);
                return Ok(category);

            }

            return NotFound($"The category with id : {id} was not found ");
        }
    }
}
