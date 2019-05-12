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
    public class SellersController : ControllerBase
    {
        private readonly MagazineContext _context;
        private readonly IMapper _mapper;

        public SellersController(MagazineContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Sellers
        [HttpGet]
        public async Task<IEnumerable<SellerResource>> GetSellers()
        {
            var sellers = await _context.Sellers.ToListAsync();
            var resources = _mapper.Map<IEnumerable<Seller>, IEnumerable<SellerResource>>(sellers);
            return resources;
        }

        // GET: api/Sellers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SellerResource>> GetSeller(int id)
        {
            var seller = await _context.Sellers.FindAsync(id);
            var response = _mapper.Map<SellerResource>(seller);
            if (seller == null)
            {
                return NotFound();
            }

            return response;
        }

        // PUT: api/Sellers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeller(int id, Seller seller)
        {
            if (id != seller.ID)
            {
                return BadRequest();
            }

            _context.Entry(seller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellerExists(id))
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

        // POST: api/Sellers
        [HttpPost]
        public async Task<ActionResult<SellerResource>> PostSeller(Seller seller)
        {
            _context.Sellers.Add(seller);
            await _context.SaveChangesAsync();
            var src = CreatedAtAction("GetSeller", new { id = seller.ID }, seller);
            var response = _mapper.Map<SellerResource>(seller);
            return response;
        }

        // DELETE: api/Sellers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Seller>> DeleteSeller(int id)
        {
            var seller = await _context.Sellers.FindAsync(id);
            if (seller == null)
            {
                return NotFound();
            }

            _context.Sellers.Remove(seller);
            await _context.SaveChangesAsync();

            return seller;
        }

        private bool SellerExists(int id)
        {
            return _context.Sellers.Any(e => e.ID == id);
        }
    }
}
