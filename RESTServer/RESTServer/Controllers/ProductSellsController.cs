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
    public class ProductSellsController : ControllerBase
    {
        private readonly MagazineContext _context;

        public ProductSellsController(MagazineContext context)
        {
            _context = context;
        }

        // GET: api/ProductSells
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductSell>>> GetProductsSell()
        {
            return await _context.ProductsSell.ToListAsync();
        }

        // GET: api/ProductSells/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductSell>> GetProductSell(long id)
        {
            var productSell = await _context.ProductsSell.FindAsync(id);

            if (productSell == null)
            {
                return NotFound();
            }

            return productSell;
        }

        // PUT: api/ProductSells/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductSell(long id, ProductSell productSell)
        {
            if (id != productSell.ProductSellId)
            {
                return BadRequest();
            }

            _context.Entry(productSell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductSellExists(id))
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

        // POST: api/ProductSells
        [HttpPost]
        public async Task<ActionResult<ProductSell>> PostProductSell(ProductSell productSell)
        {
            productSell.PricePerItemBrutto = productSell.PricePerItemNetto * (1.0 + (_context.TaxStages.Find(productSell.ProductId).Stage) / 100.0);
            _context.ProductsSell.Add(productSell);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductSell", new { id = productSell.ProductSellId }, productSell);
        }

        // DELETE: api/ProductSells/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductSell>> DeleteProductSell(long id)
        {
            var productSell = await _context.ProductsSell.FindAsync(id);
            if (productSell == null)
            {
                return NotFound();
            }

            _context.ProductsSell.Remove(productSell);
            await _context.SaveChangesAsync();

            return productSell;
        }

        private bool ProductSellExists(long id)
        {
            return _context.ProductsSell.Any(e => e.ProductSellId == id);
        }
    }
}
