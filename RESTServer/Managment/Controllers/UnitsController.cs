using Managment.Models.In;
using Managment.Models.Out;
using Managment.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        //private readonly MagazineContext _context;
        private readonly IUnitService _service;

        public UnitsController(IUnitService service)
        {
            _service = service;
        }

        // GET: api/Units
        [HttpGet]
        public async Task<ActionResult<List<UnitOut>>> GetUnits()
        {
            return await _service.GetUnits();
        }

        // GET: api/Units/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitOut>> GetUnit(Guid id)
        {
            return await _service.GetUnit(id);
        }

        //GET: api/Units/ByProductId/5
        [HttpGet("ByProductId/{id}")]
        public async Task<ActionResult<UnitOut>> GetUnitByProductId(Guid id)
        {
            return await _service.GetUnitByProductId(id);
        }

        // POST: api/Units
        [HttpPost]
        public async Task<ActionResult<UnitOut>> PostUnit(UnitIn unit)
        {
            return await _service.PostUnit(unit);
        }

        // DELETE: api/Units/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UnitOut>> DeleteUnit(Guid id)
        {
            return await _service.DeleteUnit(id);
        }
    }
}
