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
    public class ProductBuysController : ControllerBase
    {
        private readonly MagazineContext _context;

        public ProductBuysController(MagazineContext context)
        {
            _context = context;
        }

        // GET: api/ProductBuys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductBuy>>> GetProductsBuy()
        {
            return await _context.ProductsBuy.ToListAsync();
        }

        // GET: api/ProductBuys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductBuy>> GetProductBuy(long id)
        {
            var productBuy = await _context.ProductsBuy.FindAsync(id);

            if (productBuy == null)
            {
                return NotFound();
            }

            return productBuy;
        }

        // PUT: api/ProductBuys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductBuy(long id, ProductBuy productBuy)
        {
            if (id != productBuy.ProductBuyId)
            {
                return BadRequest();
            }

            _context.Entry(productBuy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductBuyExists(id))
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

        // POST: api/ProductBuys
        [HttpPost]
        public async Task<ActionResult<ProductBuy>> PostProductBuy(ProductBuy productBuy)
        {
            productBuy.PricePerItemBrutto = productBuy.PricePerItemNetto * (1.0 + (_context.TaxStages.Find(productBuy.ProductId).Stage) / 100.0);
            _context.ProductsBuy.Add(productBuy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductBuy", new { id = productBuy.ProductBuyId }, productBuy);
        }

        // DELETE: api/ProductBuys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductBuy>> DeleteProductBuy(long id)
        {
            var productBuy = await _context.ProductsBuy.FindAsync(id);
            if (productBuy == null)
            {
                return NotFound();
            }

            _context.ProductsBuy.Remove(productBuy);
            await _context.SaveChangesAsync();

            return productBuy;
        }

        private bool ProductBuyExists(long id)
        {
            return _context.ProductsBuy.Any(e => e.ProductBuyId == id);
        }
    }
}
