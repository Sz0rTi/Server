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
            //if(temp != null)
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
