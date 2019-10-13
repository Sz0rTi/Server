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
    internal class TaxStageService : ITaxStageService
    {
        private readonly IMapper _mapper;
        private readonly MagazineContext _context;

        public TaxStageService(IMapper mapper, MagazineContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<TaxStageOut> DeleteTaxStage(Guid id)
        {
            TaxStage temp = await _context.TaxStages.FirstOrDefaultAsync(e => e.ID == id);
            if (temp != null) _context.TaxStages.Remove(temp);
            await _context.SaveChangesAsync();
            return _mapper.Map<TaxStageOut>(temp);
        }

        public async Task<TaxStageOut> GetTaxStage(Guid id)
        {
            TaxStage temp2 = _context.TaxStages.Where(e=>e.ID == id).First();
            TaxStageOut temp = _mapper.Map<TaxStageOut>(temp2);
            return temp;
        }

        public async Task<List<TaxStageOut>> GetTaxStages()
        {
            List<TaxStageOut> temp = _mapper.Map<List<TaxStageOut>>(await _context.TaxStages.ToListAsync());
            return temp;
        }

        public async Task<TaxStageOut> PostTaxStage(TaxStageIn TaxStage)
        {
            TaxStage temp = _mapper.Map<TaxStage>(TaxStage);
            _context.TaxStages.Add(temp);
            await _context.SaveChangesAsync();
            return _mapper.Map<TaxStageOut>(temp);
        }
    }

    public interface ITaxStageService
    {
        Task<TaxStageOut> GetTaxStage(Guid id);
        Task<List<TaxStageOut>> GetTaxStages();
        Task<TaxStageOut> PostTaxStage(TaxStageIn tax);
        Task<TaxStageOut> DeleteTaxStage(Guid id);
    }
}
