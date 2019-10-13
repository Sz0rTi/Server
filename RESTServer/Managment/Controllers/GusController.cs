using GUS;
using Managment.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Managment.Controllers
{
    namespace Managment.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class GusController : ControllerBase
        {
            private readonly IGUSService _service;

            public GusController(IGUSService service)
            {
                _service = service;
            }

            [HttpGet("{nip}")]
            public async Task<ActionResult<Company>> GetCompany(string nip)
            {
                return _service.GetInfo(nip);
            }
        }
    }
}
