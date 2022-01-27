using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Store.Filtrs;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ApiProductController : ControllerBase
    {
        private ICRUDProductRepository products;

        public ApiProductController(ICRUDProductRepository products)
        {
            this.products = products;
        }

        [HttpGet]
        [DisableBasicAuthorization]
        public IList<Product> GetProducts()
        {
            return products.FindAll();
        }

        [HttpPost]
        public ActionResult<Product> AddProduct([FromBody] Product product)
        {
            Product product1 = products.Add(product);
            return new CreatedResult($"/api/products/{product1.Id}", product1);
        }


        [HttpGet("{id}")]
        [DisableBasicAuthorization]
        public ActionResult<Product> GetProduct(int id)
        {
            Product product = products.FindById(id);
            if (product != null)
            {
                return new OkObjectResult(product);
            }
            else
            {
                return new NotFoundResult();
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Product> EditProduct(int id, [FromBody] Product product)
        {  
            if (id < 5 && id > 0)
            {
                product.Id = id;
                return new OkObjectResult(product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            if (id < 5 && id > 0)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
