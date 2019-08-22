using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAO.Context;
using DAO.Models;
using Managment.Services;
using Managment.Models.Out;
using Managment.Models.In;

namespace Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceSellsController : ControllerBase
    {
        private readonly IInvoiceSellService _service;

        public InvoiceSellsController(IInvoiceSellService service)
        {
            _service = service;
        }

        // GET: api/InvoiceSells
        [HttpGet]
        public async Task<ActionResult<List<InvoiceSellOut>>> GetInvoicesSell()
        {
            return await _service.GetInvoiceSells();
        }

        // GET: api/InvoiceSells/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceSellOut>> GetInvoiceSell(Guid id)
        {
            return await _service.GetInvoiceSell(id);
        }

        // GET: api/InvoiceSells/ByClientID/5
        [HttpGet("byclientid/{id}")]
        public async Task<ActionResult<List<InvoiceSellOut>>> GetInvoiceSellsByClientID(Guid id)
        {
            return await _service.GetInvoicesByClientID(id);
        }

        // PUT: api/InvoiceSells/5
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceSell(Guid id, InvoiceSell invoiceSell)
        {
            if (id != invoiceSell.ID)
            {
                return BadRequest();
            }

            _context.Entry(invoiceSell).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceSellExists(id))
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

        // POST: api/InvoiceSells
        [HttpPost]
        public async Task<ActionResult<InvoiceSellOut>> PostInvoiceSell(InvoiceSellIn invoiceSell)
        {
            return await _service.PostInvoiceSell(invoiceSell);
        }

        // DELETE: api/InvoiceSells/5
        /*[HttpDelete("{id}")]
        public async Task<ActionResult<InvoiceSellOut>> DeleteInvoiceSell(Guid id)
        {
            return await _service.DeleteInvoiceSell(id);
        }*/
    }
}
