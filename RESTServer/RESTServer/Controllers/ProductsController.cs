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
    public class ProductsController : ControllerBase
    {
        private readonly MagazineContext _context;
        private readonly IMapper _mapper;

        public ProductsController(MagazineContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResource>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var resource = _mapper.Map<ProductResource>(product);
            return resource;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ID)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<ProductResource>> PostProduct(Product a)
        {
            //_context.Products.Add(product);
            /*Product item = new Product();
            item.Amount = a.Amount;
            item.Name = a.Name;
            item.PriceNetto = a.PriceNetto;
            item.CategoryID = a.CategoryID;
            item.Description = a.Description;
            item.UnitID = a.UnitID;
            item.TaxStageID = a.TaxStageID;
            //item.ID = _context.Products.Max(e => e.ID) + 1;
            //item.Category = null;
            //item.Unit = null;
            //item.TaxStage = null;*/
            _context.Products.Add(a);
            await _context.SaveChangesAsync();
            //var src = 
            //var response = product;
            return CreatedAtAction("GetProduct", new { id = a.ID }, a);
        }
        /*[HttpPost]
        public void Post([FromBody] Product product)
        {
            /*Product item = new Product();
            item.Amount = product.Amount;
            item.Name = product.Name;
            item.PriceNetto = product.PriceNetto;
            item.CategoryID = product.CategoryID;
            item.Description = product.Description;
            item.UnitID = product.UnitID;
            item.TaxStageID = product.TaxStageID;
            item.ID = _context.Products.Max(e => e.ID)+1;
            _context.Products.Add(product);
            _context.SaveChangesAsync();
        }*/

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }
}
