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
    public class ClientsController : ControllerBase
    {
        //private readonly MagazineContext _context;
        private readonly IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<List<ClientOut>>> GetClients()
        {
            return await _service.GetClients();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientOut>> GetClient(Guid id)
        {
            return await _service.GetClient(id);
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
        public async Task<ActionResult<ClientOut>> PostClient(ClientIn client)
        {
            return await _service.PostClient(client);
        }

        // DELETE: api/Clients/5
        /*[HttpDelete("{id}")]
        public async Task<ActionResult<ClientsOut>> DeleteClient(Guid id)
        {
            return await _service.DeleteClient(id);
        }*/

        [HttpGet("check/{nip}")]
        public async Task<ActionResult<bool>> CheckClient(string nip)
        {
            return await _service.CheckClient(nip);
        }

    }
}
