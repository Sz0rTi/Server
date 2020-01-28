using DAO.Models;
using Managment.Models.TwoWay;
using Managment.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Managment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummariesController : ControllerBase
    {
        //private readonly MagazineContext _context;
        private readonly ISummaryService _service;

        public SummariesController(ISummaryService service)
        {
            _service = service;
        }

        // GET: api/Units
        //[Authorize(Roles = "Admin")]
        [HttpPost("list")]
        public async Task<ActionResult<List<Summary>>> PostSummaries(InvoicesDate date)
        {
            return await _service.PostSummaries(date);
        }

        // GET: api/Units/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Summary>> GetSummary(Guid id)
        {
            return await _service.GetSummary(id);
        }

        [HttpGet("min")]
        public async Task<ActionResult<InvoicesDate>> GetMin()
        {
            return await _service.GetMinDate();
        }

        // POST: api/Units
        [HttpPost]
        public async Task<ActionResult<Summary>> PostSummary(InvoicesDate date)
        {
            return await _service.PostSummary(date);
        }
    }
}
