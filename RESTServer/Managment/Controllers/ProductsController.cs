using Managment.Models.In;
using Managment.Models.Out;
using Managment.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<List<ProductOut>>> GetProducts()
        {
            return await _service.GetProducts();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductOut>> GetProduct(Guid id)
        {
            return await _service.GetProduct(id);
        }

        // GET: api/Products/ByCategoryID/5
        [HttpGet("ByCategoryID/{id}")]
        public async Task<ActionResult<List<ProductOut>>> GetProductsByCategoryID(Guid id)
        {
            return await _service.GetProductsByCategoryID(id);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<ProductOut>> PostProduct(ProductIn product)
        {
            return await _service.PostProduct(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductOut>> PutProduct(ProductIn product, Guid id)
        {
            return await _service.PutProduct(product, id);
        }

        // DELETE: api/Products/5
        /*[HttpDelete("{id}")]
        public async Task<ActionResult<ProductOut>> DeleteProduct(Guid id)
        {
            
        }*/

    }
}
