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
    public class TaxStagesController : ControllerBase
    {
        private readonly MagazineContext _context;

        public TaxStagesController(MagazineContext context)
        {
            _context = context;
        }

        // GET: api/TaxStages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaxStage>>> GetTaxStages()
        {
            return await _context.TaxStages.ToListAsync();
        }

        // GET: api/TaxStages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxStage>> GetTaxStage(long id)
        {
            var taxStage = await _context.TaxStages.FindAsync(id);

            if (taxStage == null)
            {
                return NotFound();
            }

            return taxStage;
        }

        // PUT: api/TaxStages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxStage(long id, TaxStage taxStage)
        {
            if (id != taxStage.TaxStageId)
            {
                return BadRequest();
            }

            _context.Entry(taxStage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaxStageExists(id))
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

        // POST: api/TaxStages
        [HttpPost]
        public async Task<ActionResult<TaxStage>> PostTaxStage(TaxStage taxStage)
        {
            _context.TaxStages.Add(taxStage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaxStage", new { id = taxStage.TaxStageId }, taxStage);
        }

        // DELETE: api/TaxStages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaxStage>> DeleteTaxStage(long id)
        {
            var taxStage = await _context.TaxStages.FindAsync(id);
            if (taxStage == null)
            {
                return NotFound();
            }

            _context.TaxStages.Remove(taxStage);
            await _context.SaveChangesAsync();

            return taxStage;
        }

        private bool TaxStageExists(long id)
        {
            return _context.TaxStages.Any(e => e.TaxStageId == id);
        }
    }
}
