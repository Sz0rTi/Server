using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTServer.Data;
using RESTServer.Models;

namespace RESTServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductInOrdersController : ControllerBase
    {
        private readonly MagazineContext _context;

        public ProductInOrdersController(MagazineContext context)
        {
            _context = context;
        }

        // GET: api/ProductInOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductInOrder>>> GetProductInOrders()
        {
            return await _context.ProductInOrders.ToListAsync();
        }

        // GET: api/ProductInOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductInOrder>> GetProductInOrder(long id)
        {
            var productInOrder = await _context.ProductInOrders.FindAsync(id);

            if (productInOrder == null)
            {
                return NotFound();
            }

            return productInOrder;
        }

        // PUT: api/ProductInOrders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductInOrder(long id, ProductInOrder productInOrder)
        {
            if (id != productInOrder.ProductInOrderId)
            {
                return BadRequest();
            }

            _context.Entry(productInOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductInOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductInOrders
        [HttpPost]
        public async Task<ActionResult<ProductInOrder>> PostProductInOrder(ProductInOrder productInOrder)
        {
            _context.ProductInOrders.Add(productInOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductInOrder", new { id = productInOrder.ProductInOrderId }, productInOrder);
        }

        // DELETE: api/ProductInOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductInOrder>> DeleteProductInOrder(long id)
        {
            var productInOrder = await _context.ProductInOrders.FindAsync(id);
            if (productInOrder == null)
            {
                return NotFound();
            }

            _context.ProductInOrders.Remove(productInOrder);
            await _context.SaveChangesAsync();

            return productInOrder;
        }

        private bool ProductInOrderExists(long id)
        {
            return _context.ProductInOrders.Any(e => e.ProductInOrderId == id);
        }
    }
}
