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
    public class TaxStagesController : ControllerBase
    {
        private readonly ITaxStageService _service;

        public TaxStagesController(ITaxStageService service)
        {
            _service = service;
        }

        // GET: api/TaxStages
        [HttpGet]
        public async Task<ActionResult<List<TaxStageOut>>> GetTaxStages()
        {
            return await _service.GetTaxStages();
        }

        // GET: api/TaxStages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaxStageOut>> GetTaxStage(Guid id)
        {
            return await _service.GetTaxStage(id);
        }

        // POST: api/TaxStages
        [HttpPost]
        public async Task<ActionResult<TaxStageOut>> PostTaxStage(TaxStageIn taxStage)
        {
            return await _service.PostTaxStage(taxStage);
        }

        // DELETE: api/TaxStages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TaxStageOut>> DeleteTaxStage(Guid id)
        {
            return await _service.DeleteTaxStage(id);
        }
    }
}
