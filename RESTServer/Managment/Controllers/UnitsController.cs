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
