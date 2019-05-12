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
    public class InvoiceSellsController : ControllerBase
    {
        private readonly MagazineContext _context;
        private readonly IMapper _mapper;

        public InvoiceSellsController(MagazineContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/InvoiceSells
        [HttpGet]
        public async Task<IEnumerable<InvoiceSellResource>> GetInvoicesSell()
        {
            var invoices = await _context.InvoicesSell.ToListAsync();
            var resources = _mapper.Map<IEnumerable<InvoiceSell>, IEnumerable<InvoiceSellResource>>(invoices);
            return resources;
        }

        // GET: api/InvoiceSells/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceSellResource>> GetInvoiceSell(int id)
        {
            var invoiceSell = await _context.InvoicesSell.FindAsync(id);
            var response = _mapper.Map<InvoiceSellResource>(invoiceSell);
            if (invoiceSell == null)
            {
                return NotFound();
            }

            return response;
        }

        // PUT: api/InvoiceSells/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceSell(int id, InvoiceSell invoiceSell)
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
        }

        // POST: api/InvoiceSells
        [HttpPost]
        public async Task<ActionResult<InvoiceSellResource>> PostInvoiceSell(InvoiceSell invoiceSell)
        {
            _context.InvoicesSell.Add(invoiceSell);
            await _context.SaveChangesAsync();
            var src = CreatedAtAction("GetInvoiceSell", new { id = invoiceSell.ID }, invoiceSell);
            var response = _mapper.Map<InvoiceSellResource>(invoiceSell);
            return response;
        }

        // DELETE: api/InvoiceSells/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InvoiceSell>> DeleteInvoiceSell(int id)
        {
            var invoiceSell = await _context.InvoicesSell.FindAsync(id);
            if (invoiceSell == null)
            {
                return NotFound();
            }

            _context.InvoicesSell.Remove(invoiceSell);
            await _context.SaveChangesAsync();

            return invoiceSell;
        }

        private bool InvoiceSellExists(int id)
        {
            return _context.InvoicesSell.Any(e => e.ID == id);
        }
    }
}
