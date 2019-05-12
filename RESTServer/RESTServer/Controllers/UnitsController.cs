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
    public class UnitsController : ControllerBase
    {
        private readonly MagazineContext _context;
        private readonly IMapper _mapper;

        public UnitsController(MagazineContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Units
        [HttpGet]
        public async Task<IEnumerable<UnitResource>> GetUnits()
        {
            var units = await _context.Units.ToListAsync();
            var resources = _mapper.Map<IEnumerable<Unit>, IEnumerable<UnitResource>>(units);
            return resources;
        }

        // GET: api/Units/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitResource>> GetUnit(int id)
        {
            var unit = await _context.Units.FindAsync(id);
            var response = _mapper.Map<UnitResource>(unit);
            if (unit == null)
            {
                return NotFound();
            }

            return response;
        }

        // PUT: api/Units/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnit(int id, Unit unit)
        {
            if (id != unit.ID)
            {
                return BadRequest();
            }

            _context.Entry(unit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitExists(id))
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

        // POST: api/Units
        [HttpPost]
        public async Task<ActionResult<UnitResource>> PostUnit(Unit unit)
        {
            _context.Units.Add(unit);
            await _context.SaveChangesAsync();
            var src = CreatedAtAction("GetUnit", new { id = unit.ID }, unit);
            var response = _mapper.Map<UnitResource>(unit);
            return response;
        }

        // DELETE: api/Units/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> DeleteUnit(int id)
        {
            var unit = await _context.Units.FindAsync(id);
            if (unit == null)
            {
                return NotFound();
            }

            _context.Units.Remove(unit);
            await _context.SaveChangesAsync();

            return unit;
        }

        private bool UnitExists(int id)
        {
            return _context.Units.Any(e => e.ID == id);
        }
    }
}
