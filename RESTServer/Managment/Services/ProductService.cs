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
    internal class ProductService : IProductService
    {
        private readonly MagazineContext _context;
        private readonly IMapper _mapper;
        private IHttpContextAccessor _accessor;
        private string UserId { get; set; }

        public ProductService(MagazineContext context, IMapper mapper, IHttpContextAccessor accessor)
        {
            _context = context;
            _mapper = mapper;
            _accessor = accessor;
            UserId = _context.Users.Where(u => u.UserName == _accessor.HttpContext.User.Identity.Name).First().Id;
        }

        public async Task<ProductOut> GetProduct(Guid id)
        {
            ProductOut temp = _mapper.Map<ProductOut>(await _context.Products.Include(e=>e.Category).Include(e=>e.TaxStage).Include(e=>e.Unit).FirstOrDefaultAsync(e => e.ID == id));
            if (temp == null) return null;
            return temp;
        }

        public async Task<List<ProductOut>> GetProducts()
        {
            List<ProductOut> temp = _mapper.Map<List<ProductOut>>(await _context.Products.Where(e => e.UserID == UserId).Include(e => e.Category).Include(e => e.TaxStage).Include(e => e.Unit).ToListAsync());
            return temp;
        }

        public async Task<List<ProductOut>> GetProductsByCategoryID(Guid id)
        {
            List<ProductOut> temp = _mapper.Map<List<ProductOut>>(await _context.Products.Where(e => e.UserID == UserId).Include(e => e.Category).Include(e => e.TaxStage).Include(e => e.Unit).Where(e=>e.CategoryID == id).Take(10).ToListAsync());
            return temp;
        }

        public async Task<TaxStageOut> GetTaxStageByProductId(Guid id)
        {
            TaxStageOut temp = _mapper.Map<TaxStageOut>(_context.TaxStages.Where(e => e.ID == _context.Products.Where(w => w.ID == id).First().TaxStageID));
            return temp;
        }

        public async Task<ProductOut> PostProduct(ProductIn product)
        {
            Product temp = _mapper.Map<Product>(product);
            temp.UserID = UserId;
            _context.Products.Add(temp);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductOut>(temp);
        }

        public async Task<ProductOut> PutProduct(ProductIn product, Guid id)
        {
            Product stock = _context.Products.Where(p=>p.ID == id).First();
            stock.Description = product.Description;
            _context.Entry(stock).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductOut>(stock);
        }
    }

    public interface IProductService
    {
        Task<ProductOut> GetProduct(Guid id);
        Task<List<ProductOut>> GetProducts();
        Task<List<ProductOut>> GetProductsByCategoryID(Guid id);
        Task<ProductOut> PostProduct(ProductIn product);
        Task<TaxStageOut> GetTaxStageByProductId(Guid id);
        Task<ProductOut> PutProduct(ProductIn product, Guid id);
    }
}
