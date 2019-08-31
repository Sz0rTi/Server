using AutoMapper;
using DAO.Context;
using DAO.Models;
using Managment.Models.In;
using Managment.Models.Out;
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

        public UnitService(IMapper mapper, MagazineContext context)
        {
            _mapper = mapper;
            _context = context;
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
            List<UnitOut> temp = _mapper.Map<List<UnitOut>>(await _context.Units.ToListAsync());
            return temp;
        }

        public async Task<UnitOut> PostUnit(UnitIn unit)
        {
            Unit temp = _mapper.Map<Unit>(unit);
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
