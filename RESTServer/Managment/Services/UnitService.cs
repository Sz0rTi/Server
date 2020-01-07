using AutoMapper;
using DAO.Context;
using DAO.Models;
using Managment.Models.In;
using Managment.Models.Out;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Managment.Services
{
    internal class UnitService : IUnitService
    {
        private readonly IMapper _mapper;
        private readonly MagazineContext _context;
        private IHttpContextAccessor _accessor;
        private string UserId { get; set; }

        public UnitService(IMapper mapper, MagazineContext context, IHttpContextAccessor accessor)
        {
            _mapper = mapper;
            _context = context;
            _accessor = accessor;
            UserId = _context.Users.Where(u => u.UserName == _accessor.HttpContext.User.Identity.Name).First().Id;
        }

        public async Task<UnitOut> DeleteUnit(Guid id)
        {
            Unit temp = await _context.Units.FirstOrDefaultAsync(e => e.ID == id);
            if (temp != null) _context.Units.Remove(temp);
            await _context.SaveChangesAsync();
            return _mapper.Map<UnitOut>(temp);

            
        }

        public async Task<UnitOut> GetUnit(Guid id)
        { 
            UnitOut temp = _mapper.Map<UnitOut>(await _context.Units.FirstOrDefaultAsync());
            if (temp == null) return null;
            return temp;
        }

        public async Task<UnitOut> GetUnitByProductId(Guid id)
        {
            Product product = _context.Products.First(e => e.ID == id);
            UnitOut temp = _mapper.Map<UnitOut>(await _context.Units.Where(e => e.ID == product.UnitID).FirstAsync());
            return temp;
        }

        public async Task<List<UnitOut>> GetUnits()
        {
            List<UnitOut> temp = _mapper.Map<List<UnitOut>>(await _context.Units.Where(e => e.UserID == UserId).ToListAsync());
            return temp;
        }

        public async Task<UnitOut> PostUnit(UnitIn unit)
        {
            Unit temp = _mapper.Map<Unit>(unit);
            temp.UserID = UserId;
            _context.Units.Add(temp);
            await _context.SaveChangesAsync();
            return _mapper.Map<UnitOut>(temp);
        }
    }

    public interface IUnitService
    {
        Task<UnitOut> GetUnit(Guid id);
        Task<List<UnitOut>> GetUnits();
        Task<UnitOut> PostUnit(UnitIn unit);
        Task<UnitOut> DeleteUnit(Guid id);
        Task<UnitOut> GetUnitByProductId(Guid id);
    }
}
