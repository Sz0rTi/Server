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
using PDF;

namespace Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceBuysController : ControllerBase
    {
        private readonly IInvoiceBuyService _service;
        private readonly IPDFService _pdf;

        public InvoiceBuysController(IInvoiceBuyService service, IPDFService pdf)
        {
            _service = service;
            _pdf = pdf;
        }

        // GET: api/InvoiceBuys
        [HttpGet]
        public async Task<ActionResult<List<InvoiceBuyOut>>> GetInvoicesBuy()
        {
            return await _service.GetInvoiceBuys();
        }

        // GET: api/InvoiceBuys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceBuyOut>> GetInvoiceBuy(Guid id)
        {
            return await _service.GetInvoiceBuy(id);
        }

        // GET: api/InvoiceBuys/ByClientID/5
        [HttpGet("bysellerid/{id}")]
        public async Task<ActionResult<List<InvoiceBuyOut>>> GetInvoiceBuysBySellerID(Guid id)
        {
            return await _service.GetInvoicesBySellerID(id);
        }

        [HttpGet("pdf")]
        public async Task<ActionResult<bool>> GetPDF()
        {
            return _pdf.CreateHTML();
        }

        // PUT: api/InvoiceBuys/5
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceBuy(Guid id, InvoiceBuy invoiceBuy)
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
        }*/

        // POST: api/InvoiceBuys
        [HttpPost]
        public async Task<ActionResult<InvoiceBuyOut>> PostInvoiceBuy(InvoiceBuyIn invoiceBuy)
        {
            var user = User.Identity.Name;
            return await _service.PostInvoiceBuy(invoiceBuy);//, user);
        }

        // DELETE: api/InvoiceBuys/5
        /*[HttpDelete("{id}")]
        public async Task<ActionResult<InvoiceBuyOut>> DeleteInvoiceBuy(Guid id)
        {
            return await _service.DeleteInvoiceBuy(id);
        }*/
    }
}
