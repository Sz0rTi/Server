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
    internal class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly MagazineContext _context;
        private IHttpContextAccessor _accessor;
        private string UserId { get; set; }

        public CategoryService(IMapper mapper, MagazineContext context, IHttpContextAccessor accessor)
        {
            _mapper = mapper;
            _context = context;
            _accessor = accessor;
            UserId = _context.Users.Where(u => u.UserName == _accessor.HttpContext.User.Identity.Name).First().Id;
        }

        public async Task<CategoryOut> DeleteCategory(Guid id)
        {
            Category temp = await _context.Categories.FirstOrDefaultAsync(e => e.ID == id);
            if (temp != null) _context.Categories.Remove(temp);
            await _context.SaveChangesAsync();
            return _mapper.Map<CategoryOut>(temp);
        }

        public async Task<CategoryOut> GetCategory(Guid id)
        {
            CategoryOut temp = _mapper.Map<CategoryOut>(await _context.Categories.FirstOrDefaultAsync());
            if (temp == null) return null;
            return temp;
        }

        public async Task<List<CategoryOut>> GetCategories()
        {
            List<CategoryOut> temp = _mapper.Map<List<CategoryOut>>(await _context.Categories.Where(e => e.UserID == UserId).ToListAsync());
            return temp;
        }

        public async Task<CategoryOut> PostCategory(CategoryIn category)
        {
            if (_context.Categories.Any(c => c.Name == category.Name)) return null;
            else
            {
                Category temp = _mapper.Map<Category>(category);
                temp.UserID = UserId;
                _context.Categories.Add(temp);
                await _context.SaveChangesAsync();
                return _mapper.Map<CategoryOut>(temp);
            }
        }
    }

    public interface ICategoryService
    {
        Task<CategoryOut> GetCategory(Guid id);
        Task<List<CategoryOut>> GetCategories();
        Task<CategoryOut> PostCategory(CategoryIn category);
        Task<CategoryOut> DeleteCategory(Guid id);
    }
}
