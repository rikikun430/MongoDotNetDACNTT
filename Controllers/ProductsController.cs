using mongodb_dotnet_example.Models;
using mongodb_dotnet_example.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mongodb_dotnet_example.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsService _productService;

        public ProductsController(ProductsService productsService)
        {
			_productService = productsService;
        }

		
        [HttpGet]
        public ActionResult<List<Products>> Get() =>
            _productService.Get();

        [HttpGet("{id:length(24)}", Name = "GetProduct")]
        public ActionResult<Products> Get(string id)
        {
            var product = _productService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public ActionResult<Products> Create(Products product)
        {
			_productService.Create(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id.ToString() }, product);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Products productIn)
        {
            var product = _productService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

			_productService.Update(id, product);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var product = _productService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

			_productService.Delete(product.Id);

            return NoContent();
        }
    }
}