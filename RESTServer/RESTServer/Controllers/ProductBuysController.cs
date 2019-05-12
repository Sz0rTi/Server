using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTServer.Data;
using RESTServer.Models;
using RESTServer.Resources;

namespace RESTServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBuysController : ControllerBase
    {
        private readonly MagazineContext _context;
        private readonly IMapper _mapper;

        public ProductBuysController(MagazineContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ProductBuys
        [HttpGet]
        public async Task<IEnumerable<ProductBuyResource>> GetProductsBuy()
        {
            var products = await _context.ProductsBuy.ToListAsync();
            var resources = _mapper.Map<IEnumerable<ProductBuy>, IEnumerable<ProductBuyResource>>(products);
            return resources;
        }

        // GET: api/ProductBuys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductBuyResource>> GetProductBuy(int id)
        {
            var productBuy = await _context.ProductsBuy.FindAsync(id);
            var response = _mapper.Map<ProductBuyResource>(productBuy);
            if (productBuy == null)
            {
                return NotFound();
            }

            return response;
        }

        // PUT: api/ProductBuys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductBuy(int id, ProductBuy productBuy)
        {
            if (id != productBuy.ID)
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
        public async Task<ActionResult<ProductBuyResource>> PostProductBuy(ProductBuy productBuy)
        {
            _context.ProductsBuy.Add(productBuy);
            await _context.SaveChangesAsync();
            var src = CreatedAtAction("GetProductBuy", new { id = productBuy.ID }, productBuy);
            var response = _mapper.Map<ProductBuyResource>(productBuy);
            return response;
        }

        // DELETE: api/ProductBuys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductBuy>> DeleteProductBuy(int id)
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

        private bool ProductBuyExists(int id)
        {
            return _context.ProductsBuy.Any(e => e.ID == id);
        }
    }
}
