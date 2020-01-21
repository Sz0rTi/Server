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
using Managment.Models.TwoWay;

namespace Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceSellsController : ControllerBase
    {
        private readonly IInvoiceSellService _service;
        private readonly IPDFService _pdf;

        public InvoiceSellsController(IInvoiceSellService service, IPDFService pdf)
        {
            _service = service;
            _pdf = pdf;
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

        [HttpGet("min")]
        public async Task<ActionResult<InvoicesDate>> GetMinDate()
        {
            return await _service.GetMinDate();
        }

        [HttpGet("pdf/{id}")]
        public async Task<ActionResult<bool>> GetPDF(Guid id)
        {
            return await _pdf.CreateHTML(id);
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
            return Created("invoicesells",await _service.PostInvoiceSell(invoiceSell));
        }

        [HttpPost("bydate")]
        public async Task<ActionResult<List<InvoiceSell>>> PostInvoicesByDate(InvoicesDate date)
        {
            return await _service.PostInvoicesByDate(date);
        }

        // DELETE: api/InvoiceSells/5
        /*[HttpDelete("{id}")]
        public async Task<ActionResult<InvoiceSellOut>> DeleteInvoiceSell(Guid id)
        {
            return await _service.DeleteInvoiceSell(id);
        }*/
    }
}
