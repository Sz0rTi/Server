using Managment.Models.In;
using Managment.Models.Out;
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
    public class PaymentController : ControllerBase
    {
        //private readonly MagazineContext _context;
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }

        // GET: api/Units
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<List<PaymentMethodOut>>> GetPaymentMethods()
        {
            return await _service.GetPaymentMethods();
        }

        // GET: api/Units/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentMethodOut>> GetPaymentMethod(Guid id)
        {
            return await _service.GetPaymentMethod(id);
        }

        // POST: api/Units
        [HttpPost]
        public async Task<ActionResult<PaymentMethodOut>> PostPaymentMethod(PaymentMethodIn payment)
        {
            return await _service.PostPaymentMethod(payment);
        }
    }
}
