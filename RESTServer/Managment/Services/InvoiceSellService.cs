using AutoMapper;
using DAO.Context;
using Managment.Models.Out;
using System;
using System.Collections.Generic;
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

        public Task<InvoiceSellOut> GetInvoiceSell(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<InvoiceSellOut>> GetInvoiceSells()
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceSellOut> PostInvoiceSell()
        {
            throw new NotImplementedException();
        }

        public Task<List<InvoiceSellOut>> PostInvoiceSellsByDate()
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceSellOut> PutInvoiceSell(Guid id)
        {
            throw new NotImplementedException();
        }
    }

    public interface IInvoiceSellService
    {
        Task<List<InvoiceSellOut>> GetInvoiceSells();
        Task<InvoiceSellOut> GetInvoiceSell(Guid id);
        Task<InvoiceSellOut> PostInvoiceSell();
        Task<InvoiceSellOut> PutInvoiceSell(Guid id);
        Task<List<InvoiceSellOut>> PostInvoiceSellsByDate();
    }
}
