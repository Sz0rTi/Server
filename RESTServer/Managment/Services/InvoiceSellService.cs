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
    internal class InvoiceSellService : IInvoiceSellService
    {
        private IMapper _mapper;
        private MagazineContext _context;
        private IHttpContextAccessor _accessor;
        private string UserId { get; set; }

        public InvoiceSellService(IMapper mapper, MagazineContext context, IHttpContextAccessor accessor)
        {
            _mapper = mapper;
            _context = context;
            _accessor = accessor;
            UserId = _context.Users.Where(u => u.UserName == _accessor.HttpContext.User.Identity.Name).First().Id;
        }

        public async Task<List<InvoiceSellOut>> GetInvoicesByClientID(Guid id)
        {
            List<InvoiceSellOut> temp = _mapper.Map<List<InvoiceSellOut>>(await _context.InvoicesSell.Where(e => e.ClientID == id).OrderByDescending(e=>e.Date).ToListAsync());
            return temp;
        }

        public async Task<InvoiceSellOut> GetInvoiceSell(Guid id)
        {
            InvoiceSellOut temp = _mapper.Map < InvoiceSellOut > (await _context.InvoicesSell.Where(e => e.UserID == UserId).Include(e=>e.ProductsSell).FirstOrDefaultAsync(e => e.ID == id));
            if (temp == null) return null;
            return temp;
        }

        public async Task<List<InvoiceSellOut>> GetInvoiceSells()
        {
            List<InvoiceSellOut> temp = _mapper.Map<List<InvoiceSellOut>>(await _context.InvoicesSell.Where(e => e.UserID == UserId).OrderByDescending(e => e.Date).ToListAsync());
            return temp;
        }

        public async Task<InvoicesDate> GetMinDate()
        {
            InvoicesDate MinDate = new InvoicesDate();
            try
            {
                var temp = (from d in _context.InvoicesSell.Where(i => i.UserID == UserId) select d.Date).Min();
                MinDate.Month = temp.Month;
                MinDate.Year = temp.Year;
            }
            catch (InvalidOperationException e)
            {
                return null;
            }
            return new InvoicesDate { Year = MinDate.Year, Month = MinDate.Month };
        }

        public async Task<InvoiceSellOut> PostInvoiceSell(InvoiceSellIn invoice)
        {
            InvoiceSell temp = _mapper.Map<InvoiceSell>(invoice);
            temp.Date = DateTime.Now;
            var tempList = _context.InvoicesSell.Where(i => i.UserID == UserId).Where(i => i.Date.Month == temp.Date.Month).Select(i=>new { i.Name, i.Date });
            if(tempList.Count() == 0)
            {
                temp.Code = $"1/{temp.Date.Month.ToString()}/{temp.Date.Year.ToString()}";
            }
            else
            {
                var tempInvoice = tempList.Last();
                string[] tempString = tempInvoice.Name.Split('/');
                temp.Code = $"{(int.Parse(tempString[0])+1).ToString()}/{temp.Date.Month.ToString()}/{temp.Date.Year.ToString()}";
            }
            temp.Name = $"{temp.Code} {_context.Clients.Where(c => c.ID == temp.ClientID).First().Name}";
            foreach(var item in temp.ProductsSell)
            {
                var tempProduct = _context.Products.Where(p => p.ID == item.ProductID).First();
                tempProduct.Amount -= item.Amount;
            }
            temp.UserID = UserId;
            _context.InvoicesSell.Add(temp);
            await _context.SaveChangesAsync();
            return _mapper.Map<InvoiceSellOut>(temp);
        }

        public async Task<List<InvoiceSell>> PostInvoicesByDate(InvoicesDate date)
        {
            var temp = _mapper.Map<List<InvoiceSell>>(await _context.InvoicesSell.Where(i => i.UserID == UserId)
                .Where(i => i.Date.Year == date.Year && i.Date.Month == date.Month).ToListAsync());
            return temp;
        }
    }

    public interface IInvoiceSellService
    {
        Task<List<InvoiceSellOut>> GetInvoiceSells();
        Task<List<InvoiceSellOut>> GetInvoicesByClientID(Guid id);
        Task<InvoiceSellOut> GetInvoiceSell(Guid id);
        Task<InvoiceSellOut> PostInvoiceSell(InvoiceSellIn invoice);
        Task<List<InvoiceSell>> PostInvoicesByDate(InvoicesDate date);
        Task<InvoicesDate> GetMinDate();
        //Task<InvoiceSellOut> PutInvoiceSell(Guid id);
    }
}
