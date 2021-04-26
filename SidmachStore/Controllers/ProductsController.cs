using Microsoft.AspNetCore.Mvc;
using SidmachStore.Models;
using SidmachStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SidmachStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProduct _product;

        public ProductsController(IProduct product)
        {
            _product = product;

        }


        [HttpGet]
        [Route("api/[controller]")]

        public IActionResult GetProduct()
        {
            return Ok(_product.GetProduct());
        }
        
  
        [HttpGet]
        [Route("api/[controller]/{id}")]

        public IActionResult GetProduct(Guid id)
        {
            var product = _product.GetProduct(id);

            if (product != null)
            {
                return Ok(product);

            }

            return NotFound($"The product with id : {id} was not found ");
        }


        [HttpPost]
        [Route("api/[controller]")]

        public IActionResult GetProduct(Product product)
        {
            _product.AddProduct(product);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" +
                product.Id, product);
        }



        [HttpDelete]
        [Route("api/[controller]/{id}")]

        public IActionResult DeleteProduct(Guid id)
        {
            var product = _product.GetProduct(id);

            if (product != null)
            {
                _product.DeleteProduct(product);
                return Ok($"The product with id: { id} was deleted! ");

            }

            return NotFound($"The product with id : {id} was not found ");
        }


        [HttpPatch]
        [Route("api/[controller]/{id}")]

        public IActionResult EditProduct(Guid id, Product product)
        {
            var existingProduct = _product.GetProduct(id);

            if (existingProduct != null)
            {
                product.Id = existingProduct.Id;
                _product.EditProduct(existingProduct);
                return Ok(product);

            }

            return NotFound($"The product with id : {id} was not found ");
        }

    }
}
