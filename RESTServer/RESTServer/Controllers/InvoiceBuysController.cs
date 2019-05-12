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
    public class InvoiceBuysController : ControllerBase
    {
        private readonly MagazineContext _context;
        private readonly IMapper _mapper;

        public InvoiceBuysController(MagazineContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/InvoiceBuys
        [HttpGet]
        public async Task<IEnumerable<InvoiceBuyResource>> GetInvoicesBuy()
        {
            var invoices = await _context.InvoicesBuy.ToListAsync();
            var resources = _mapper.Map<IEnumerable<InvoiceBuy>, IEnumerable<InvoiceBuyResource>>(invoices);
            return resources;
        }

        // GET: api/InvoiceBuys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceBuyResource>> GetInvoiceBuy(int id)
        {
            var invoiceBuy = await _context.InvoicesBuy.FindAsync(id);
            var response = _mapper.Map<InvoiceBuyResource>(invoiceBuy);

            if (invoiceBuy == null)
            {
                return NotFound();
            }

            return response;
        }

        // PUT: api/InvoiceBuys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceBuy(int id, InvoiceBuy invoiceBuy)
        {
            if (id != invoiceBuy.ID)
            {
                return BadRequest();
            }

            _context.Entry(invoiceBuy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceBuyExists(id))
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

        // POST: api/InvoiceBuys
        [HttpPost]
        public async Task<ActionResult<InvoiceBuyResource>> PostInvoiceBuy(InvoiceBuy invoiceBuy)
        {
            _context.InvoicesBuy.Add(invoiceBuy);
            await _context.SaveChangesAsync();
            var src = CreatedAtAction("GetInvoiceBuy", new { id = invoiceBuy.ID }, invoiceBuy);
            var response = _mapper.Map<InvoiceBuyResource>(invoiceBuy);
            return response;
        }

        // DELETE: api/InvoiceBuys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InvoiceBuy>> DeleteInvoiceBuy(int id)
        {
            var invoiceBuy = await _context.InvoicesBuy.FindAsync(id);
            if (invoiceBuy == null)
            {
                return NotFound();
            }

            _context.InvoicesBuy.Remove(invoiceBuy);
            await _context.SaveChangesAsync();

            return invoiceBuy;
        }

        private bool InvoiceBuyExists(int id)
        {
            return _context.InvoicesBuy.Any(e => e.ID == id);
        }
    }
}
