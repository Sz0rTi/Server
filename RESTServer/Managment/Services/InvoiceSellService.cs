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
    internal class InvoiceSellService : IInvoiceSellService
    {
        private IMapper _mapper;
        private MagazineContext _context;
        public InvoiceSellService(IMapper mapper, MagazineContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<InvoiceSellOut>> GetInvoicesByClientID(Guid id)
        {
            List<InvoiceSellOut> temp = _mapper.Map<List<InvoiceSellOut>>(await _context.InvoicesSell.Where(e => e.ClientID == id).OrderByDescending(e=>e.Date).ToListAsync());
            return temp;
        }

        public async Task<InvoiceSellOut> GetInvoiceSell(Guid id)
        {
            InvoiceSellOut temp = _mapper.Map < InvoiceSellOut > (await _context.InvoicesSell.Include(e=>e.ProductsSell).FirstOrDefaultAsync(e => e.ID == id));
            if (temp == null) return null;
            return temp;
        }

        public async Task<List<InvoiceSellOut>> GetInvoiceSells()
        {
            List<InvoiceSellOut> temp = _mapper.Map<List<InvoiceSellOut>>(await _context.InvoicesSell.OrderByDescending(e => e.Date).ToListAsync());
            return temp;
        }

        public async Task<InvoiceSellOut> PostInvoiceSell(InvoiceSellIn invoice)
        {
            InvoiceSell temp = _mapper.Map<InvoiceSell>(invoice);
            temp.Date = DateTime.Now;
            var tempList = _context.InvoicesSell.Where(i => i.Date.Month == temp.Date.Month).Select(i=>new { i.Name, i.Date });
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
            _context.InvoicesSell.Add(temp);
            await _context.SaveChangesAsync();
            return _mapper.Map<InvoiceSellOut>(temp);
        }
    }

    public interface IInvoiceSellService
    {
        Task<List<InvoiceSellOut>> GetInvoiceSells();
        Task<List<InvoiceSellOut>> GetInvoicesByClientID(Guid id);
        Task<InvoiceSellOut> GetInvoiceSell(Guid id);
        Task<InvoiceSellOut> PostInvoiceSell(InvoiceSellIn invoice);
        //Task<InvoiceSellOut> PutInvoiceSell(Guid id);
    }
}
