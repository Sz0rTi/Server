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
    public class ProductSellsController : ControllerBase
    {
        private readonly MagazineContext _context;
        private readonly IMapper _mapper;

        public ProductSellsController(MagazineContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ProductSells
        [HttpGet]
        public async Task<IEnumerable<ProductSellResource>> GetProductsSells()
        {
            var products = await _context.ProductsSell.ToListAsync();
            var resources = _mapper.Map<IEnumerable<ProductSell>, IEnumerable<ProductSellResource>>(products);
            return resources;
        }

        // GET: api/ProductSells/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductSellResource>> GetProductSell(int id)
        {
            var productSell = await _context.ProductsSell.FindAsync(id);
            var response = _mapper.Map<ProductSellResource>(productSell);
            if (productSell == null)
            {
                return NotFound();
            }

            return response;
        }

        // PUT: api/ProductSells/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductSell(int id, ProductSell productSell)
        {
            if (id != productSell.ID)
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
        public async Task<ActionResult<ProductSellResource>> PostProductSell(ProductSell productSell)
        {
            _context.ProductsSell.Add(productSell);
            await _context.SaveChangesAsync();
            var src = CreatedAtAction("GetProductSell", new { id = productSell.ID }, productSell);
            var response = _mapper.Map<ProductSellResource>(productSell);
            return response;
        }

        // DELETE: api/ProductSells/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductSell>> DeleteProductSell(int id)
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

        private bool ProductSellExists(int id)
        {
            return _context.ProductsSell.Any(e => e.ID == id);
        }
    }
}
