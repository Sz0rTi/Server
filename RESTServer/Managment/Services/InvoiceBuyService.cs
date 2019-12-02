using AutoMapper;
using DAO.Context;
using DAO.Models;
using Managment.Models.In;
using Managment.Models.Out;
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
        public InvoiceBuyService(IMapper mapper, MagazineContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<InvoiceBuyOut>> GetInvoicesBySellerID(Guid id)
        {
            List<InvoiceBuyOut> temp = _mapper.Map<List<InvoiceBuyOut>>(await _context.InvoicesBuy.Where(i => i.SellerID == id).ToListAsync());
            return _mapper.Map<List<InvoiceBuyOut>>(temp);
        }

        public async Task<InvoiceBuyOut> GetInvoiceBuy(Guid id)
        {
            var temp = await _context.InvoicesBuy.Where(i => i.ID == id).FirstOrDefaultAsync();
            if (temp == null) return null;
            else return _mapper.Map<InvoiceBuyOut>(temp);
        }

        public async Task<List<InvoiceBuyOut>> GetInvoiceBuys()
        {
            var temp = await _context.InvoicesBuy.ToListAsync();
            return _mapper.Map<List<InvoiceBuyOut>>(temp);
        }

        public async Task<InvoiceBuyOut> PostInvoiceBuy(InvoiceBuyIn invoice)
        {
            InvoiceBuy temp = _mapper.Map<InvoiceBuy>(invoice);
            temp.Date = DateTime.Now;
            var tempList = _context.InvoicesBuy.Where(i => i.Date.Month == temp.Date.Month).Select(i => new { i.Name, i.Date });
            if (tempList.Count() == 0)
            {
                temp.Code = $"1/{temp.Date.Month.ToString()}/{temp.Date.Year.ToString()}";
            }
            else
            {
                var tempInvoice = tempList.Last();
                string[] tempString = tempInvoice.Name.Split('/');
                temp.Code = $"{(int.Parse(tempString[0]) + 1).ToString()}/{temp.Date.Month.ToString()}/{temp.Date.Year.ToString()}";
            }
            temp.Name = $"{temp.Code} {_context.Sellers.Where(c => c.ID == temp.SellerID).First().Name}";
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
            }
            _context.InvoicesBuy.Add(temp);
            await _context.SaveChangesAsync();
            return _mapper.Map<InvoiceBuyOut>(temp);
        }
    }

    public interface IInvoiceBuyService
    {
        Task<List<InvoiceBuyOut>> GetInvoiceBuys();
        Task<List<InvoiceBuyOut>> GetInvoicesBySellerID(Guid id);
        Task<InvoiceBuyOut> GetInvoiceBuy(Guid id);
        Task<InvoiceBuyOut> PostInvoiceBuy(InvoiceBuyIn invoice);
    }
}
