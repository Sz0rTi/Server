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
    public class InvoiceSellsController : ControllerBase
    {
        private readonly MagazineContext _context;

        public InvoiceSellsController(MagazineContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceSells
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceSell>>> GetInvoicesSell()
        {
            return await _context.InvoicesSell.ToListAsync();
        }

        // GET: api/InvoiceSells/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceSell>> GetInvoiceSell(int id)
        {
            var invoiceSell = await _context.InvoicesSell.FindAsync(id);

            if (invoiceSell == null)
            {
                return NotFound();
            }

            return invoiceSell;
        }

        // PUT: api/InvoiceSells/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceSell(int id, InvoiceSell invoiceSell)
        {
            if (id != invoiceSell.InvoiceSellId)
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
        public async Task<ActionResult<InvoiceSell>> PostInvoiceSell(InvoiceSell invoiceSell)
        {
            double sumnetto = 0;
            double sumbrutto = 0;
            foreach(ProductSell item in _context.ProductsSell.Where(e => e.InvoiceSellId == invoiceSell.InvoiceSellId))
            {
                sumnetto += item.PricePerItemNetto * item.Amount;
                sumbrutto += item.PricePerItemBrutto * item.Amount;
            }
            invoiceSell.PriceNetto = sumnetto;
            invoiceSell.PriceBrutto = sumbrutto;
            _context.InvoicesSell.Add(invoiceSell);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceSell", new { id = invoiceSell.InvoiceSellId }, invoiceSell);
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
            return _context.InvoicesSell.Any(e => e.InvoiceSellId == id);
        }
    }
}
