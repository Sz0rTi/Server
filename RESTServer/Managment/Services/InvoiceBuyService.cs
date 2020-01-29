using AutoMapper;
using DAO.Context;
using DAO.Models;
using Managment.Models.In;
using Managment.Models.Out;
using Managment.Models.TwoWay;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managment.Services
{
    internal class InvoiceBuyService : IInvoiceBuyService
    {
        private IMapper _mapper;
        private MagazineContext _context;
        private IHttpContextAccessor _accessor;
        private string UserId { get; set; }

        public InvoiceBuyService(IMapper mapper, MagazineContext context, IHttpContextAccessor accessor)
        {
            _mapper = mapper;
            _context = context;
            _accessor = accessor;
            UserId = _context.Users.Where(u => u.UserName == _accessor.HttpContext.User.Identity.Name).First().Id;
        }

        public async Task<List<InvoiceBuyOut>> GetInvoicesBySellerID(Guid id)
        {
            List<InvoiceBuyOut> temp = _mapper.Map<List<InvoiceBuyOut>>(await _context.InvoicesBuy.Where(i => i.UserID == UserId).Where(i => i.SellerID == id).ToListAsync());
            return _mapper.Map<List<InvoiceBuyOut>>(temp);
        }

        public async Task<InvoiceBuyOut> GetInvoiceBuy(Guid id)
        {
            var temp = await _context.InvoicesBuy.Where(i=>i.UserID == UserId).Where(i => i.ID == id).Include(p=>p.ProductsBuy).FirstOrDefaultAsync();
            if (temp == null) return null;
            else return _mapper.Map<InvoiceBuyOut>(temp);
        }

        public async Task<List<InvoiceBuyOut>> GetInvoiceBuys()
        {
            var temp = await _context.InvoicesBuy.Where(i => i.UserID == UserId).ToListAsync();
            return _mapper.Map<List<InvoiceBuyOut>>(temp);
        }

        public async Task<InvoiceBuyOut> GetPayInvoice(Guid id)
        {
            var temp = _context.InvoicesBuy.Where(i => i.UserID == UserId).Where(i => i.ID == id).First();
            temp.IsPaid = true;
            _context.SaveChanges();
            return _mapper.Map <InvoiceBuyOut>(temp);
        }

        public async Task<InvoicesDate> GetMinDate()
        {
            InvoicesDate MinDate = new InvoicesDate();
            try
            {
                var temp = (from d in _context.InvoicesBuy.Where(i => i.UserID == UserId) select d.Date).Min();
                MinDate.Month = temp.Month;
                MinDate.Year = temp.Year;
            }
            catch(InvalidOperationException e)
            {
                return null;
            }
            return new InvoicesDate { Year = MinDate.Year, Month = MinDate.Month };
        }

        public async Task<InvoiceBuyOut> PostInvoiceBuy(InvoiceBuyIn invoice)//, string user)
        {
            InvoiceBuy temp = _mapper.Map<InvoiceBuy>(invoice);
            temp.Date = DateTime.Now;
            temp.Name = $"{_context.Sellers.Where(i => i.UserID == UserId).Where(c => c.ID == temp.SellerID).First().Name} {temp.Code} ";
            foreach (var item in temp.ProductsBuy)
            {
                var tempProduct = _context.Products.Where(p => p.ID == item.ProductID).First();
                if (tempProduct.Amount == 0)
                {
                    tempProduct.PriceNetto = item.PricePerItemNetto;
                    tempProduct.Amount = item.Amount;
                }
                else
                {
                    tempProduct.PriceNetto = (double)(tempProduct.PriceNetto * tempProduct.Amount + item.PricePerItemNetto * item.Amount) / (tempProduct.Amount + item.Amount);
                    tempProduct.Amount += item.Amount;
                }
                item.UserID = UserId;
            }
            //temp.UserID = _context.Users.Where(u => u.UserName == user).FirstOrDefault().Id;
            temp.UserID = UserId;
            _context.InvoicesBuy.Add(temp);
            await _context.SaveChangesAsync();
            return _mapper.Map<InvoiceBuyOut>(temp);
        }

        public async Task<List<InvoiceBuy>> PostInvoicesByDate(InvoicesDate date)
        {
            var temp = _mapper.Map<List<InvoiceBuy>>(await _context.InvoicesBuy.Where(i => i.UserID == UserId)
                .Where(i => i.Date.Year == date.Year && i.Date.Month == date.Month).ToListAsync());
            return temp;
        }
    }

    public interface IInvoiceBuyService
    {
        Task<List<InvoiceBuyOut>> GetInvoiceBuys();
        Task<List<InvoiceBuyOut>> GetInvoicesBySellerID(Guid id);
        Task<InvoiceBuyOut> GetInvoiceBuy(Guid id);
        Task<InvoiceBuyOut> GetPayInvoice(Guid id);
        Task<InvoiceBuyOut> PostInvoiceBuy(InvoiceBuyIn invoice);//, string user);
        Task<InvoicesDate> GetMinDate();
        Task<List<InvoiceBuy>> PostInvoicesByDate(InvoicesDate date);
    }
}
