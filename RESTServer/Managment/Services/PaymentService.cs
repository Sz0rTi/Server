using AutoMapper;
using DAO.Context;
using DAO.Models;
using Managment.Models.In;
using Managment.Models.Out;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managment.Services
{
    public class PaymentService : IPaymentService
    {
        private IMapper _mapper;
        private MagazineContext _context;
        private IHttpContextAccessor _accessor;
        private string UserId { get; set; }

        public PaymentService(IMapper mapper, MagazineContext context, IHttpContextAccessor accessor)
        {
            _mapper = mapper;
            _context = context;
            _accessor = accessor;
            UserId = _context.Users.Where(u => u.UserName == _accessor.HttpContext.User.Identity.Name).First().Id;
        }

        public async Task<PaymentMethodOut> GetPaymentMethod(Guid id)
        {
            var temp = _context.PaymentMethods.Where(p => p.UserID == UserId).Where(p => p.ID == id).First();
            if (temp == null) return null;
            else
            {
                return _mapper.Map<PaymentMethodOut>(temp);
            }
        }

        public async Task<List<PaymentMethodOut>> GetPaymentMethods()
        {
            var temp = await _context.PaymentMethods.Where(p => p.UserID == UserId).ToListAsync();
            return _mapper.Map<List<PaymentMethodOut>>(temp);
        }

        public async Task<PaymentMethodOut> PostPaymentMethod(PaymentMethodIn payment)
        {
            PaymentMethod temp = new PaymentMethod();
            temp.Name = payment.Name;
            temp.UserID = UserId;
            _context.PaymentMethods.Add(temp);
            await _context.SaveChangesAsync();
            return _mapper.Map<PaymentMethodOut>(temp);
        }
    }

    public interface IPaymentService
    {
        Task<PaymentMethodOut> GetPaymentMethod(Guid id);
        Task<List<PaymentMethodOut>> GetPaymentMethods();
        Task<PaymentMethodOut> PostPaymentMethod(PaymentMethodIn payment);
    }
}
