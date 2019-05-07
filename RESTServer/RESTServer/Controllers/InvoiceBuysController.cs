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
    public class InvoiceBuysController : ControllerBase
    {
        private readonly MagazineContext _context;

        public InvoiceBuysController(MagazineContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceBuys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceBuy>>> GetInvoicesBuy()
        {
            return await _context.InvoicesBuy.ToListAsync();
        }

        // GET: api/InvoiceBuys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceBuy>> GetInvoiceBuy(long id)
        {
            var invoiceBuy = await _context.InvoicesBuy.FindAsync(id);

            if (invoiceBuy == null)
            {
                return NotFound();
            }

            return invoiceBuy;
        }

        // PUT: api/InvoiceBuys/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceBuy(long id, InvoiceBuy invoiceBuy)
        {
            if (id != invoiceBuy.InvoiceBuyId)
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
        public async Task<ActionResult<InvoiceBuy>> PostInvoiceBuy(InvoiceBuy invoiceBuy)
        {
            double sumnetto = 0;
            double sumbrutto = 0;
            foreach (ProductBuy item in _context.ProductsBuy.Where(e => e.InvoiceBuyId == invoiceBuy.InvoiceBuyId))
            {
                sumnetto += item.PricePerItemNetto * item.Amount;
                sumbrutto += item.PricePerItemBrutto * item.Amount;
            }
            invoiceBuy.PriceNetto = sumnetto;
            invoiceBuy.PriceBrutto = sumbrutto;
            _context.InvoicesBuy.Add(invoiceBuy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceBuy", new { id = invoiceBuy.InvoiceBuyId }, invoiceBuy);
        }

        // DELETE: api/InvoiceBuys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<InvoiceBuy>> DeleteInvoiceBuy(long id)
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

        private bool InvoiceBuyExists(long id)
        {
            return _context.InvoicesBuy.Any(e => e.InvoiceBuyId == id);
        }
    }
}
