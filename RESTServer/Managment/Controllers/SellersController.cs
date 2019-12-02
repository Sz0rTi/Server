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
    public class SellersController : ControllerBase
    {
        //private readonly MagazineContext _context;
        private readonly ISellerService _service;

        public SellersController(ISellerService service)
        {
            _service = service;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<List<SellerOut>>> GetSellers()
        {
            return await _service.GetSellers();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SellerOut>> GetSeller(Guid id)
        {
            return await _service.GetSeller(id);
        }

        // PUT: api/Clients/5
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutClients(Guid id, Clients Clients)
        {
            if (id != Clients.ID)
            {
                return BadRequest();
            }

            _context.Entry(Clients).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // POST: api/Clients
        [HttpPost]
        public async Task<ActionResult<SellerOut>> PostClient(SellerIn seller)
        {
            return await _service.PostSeller(seller);
        }

        // DELETE: api/Clients/5
        /*[HttpDelete("{id}")]
        public async Task<ActionResult<ClientsOut>> DeleteClient(Guid id)
        {
            return await _service.DeleteClient(id);
        }*/

        [HttpGet("check/{nip}")]
        public async Task<ActionResult<bool>> CheckSeller(string nip)
        {
            return await _service.CheckSeller(nip);
        }

    }
}
