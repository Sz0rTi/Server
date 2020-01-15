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
    internal class TaxStageService : ITaxStageService
    {
        private readonly IMapper _mapper;
        private readonly MagazineContext _context;
        private IHttpContextAccessor _accessor;
        private string UserId { get; set; }

        public TaxStageService(IMapper mapper, MagazineContext context, IHttpContextAccessor accessor)
        {
            _mapper = mapper;
            _context = context;
            _accessor = accessor;
            UserId = _context.Users.Where(u => u.UserName == _accessor.HttpContext.User.Identity.Name).First().Id;
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
            TaxStage temp2 = _context.TaxStages.Where(c => c.UserID == UserId).Where(e=>e.ID == id).First();
            if (temp2 == null) return null;
            TaxStageOut temp = _mapper.Map<TaxStageOut>(temp2);
            return temp;
        }

        public async Task<List<TaxStageOut>> GetTaxStages()
        {
            List<TaxStageOut> temp = _mapper.Map<List<TaxStageOut>>(await _context.TaxStages.Where(e=>e.UserID == UserId).ToListAsync());
            return temp;
        }

        public async Task<TaxStageOut> PostTaxStage(TaxStageIn TaxStage)
        {
            TaxStage temp = _mapper.Map<TaxStage>(TaxStage);
            temp.UserID = UserId;
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
