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
    public class TaxStagesController : ControllerBase
    {
        private readonly MagazineContext _context;
        private readonly IMapper _mapper;

        public TaxStagesController(MagazineContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/TaxStages
        [HttpGet]
        public async Task<IEnumerable<TaxStageResource>> GetTaxStages()
        {
            var taxstages = await _context.TaxStages.ToListAsync();
            var resources = _mapper.Map<IEnumerable<TaxStage>, IEnumerable<TaxStageResource>>(taxstages);
            return resources;
        }

        // GET: api/TaxStages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxStageResource>> GetTaxStage(int id)
        {
            var taxStage = await _context.TaxStages.FindAsync(id);
            var response = _mapper.Map<TaxStageResource>(taxStage);
            if (taxStage == null)
            {
                return NotFound();
            }
            return response;
        }

        // PUT: api/TaxStages/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaxStage(int id, TaxStage taxStage)
        {
            if (id != taxStage.ID)
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
        public async Task<ActionResult<TaxStageResource>> PostTaxStage(TaxStage taxStage)
        {
            _context.TaxStages.Add(taxStage);
            await _context.SaveChangesAsync();
            var src = CreatedAtAction("GetTaxStage", new { id = taxStage.ID }, taxStage);
            var response = _mapper.Map<TaxStageResource>(taxStage);
            return response;
        }

        // DELETE: api/TaxStages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaxStage>> DeleteTaxStage(int id)
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

        private bool TaxStageExists(int id)
        {
            return _context.TaxStages.Any(e => e.ID == id);
        }
    }
}
