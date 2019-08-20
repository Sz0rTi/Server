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
    internal class ProductService : IProductService
    {
        private readonly MagazineContext _context;
        private readonly IMapper _mapper;

        public ProductService(MagazineContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductOut> GetProduct(Guid id)
        {
            ProductOut temp = _mapper.Map<ProductOut>(_context.Products.FirstOrDefaultAsync(e => e.ID == id));
            return temp;
        }

        public async Task<List<ProductOut>> GetProducts()
        {
            List<ProductOut> temp = _mapper.Map<List<ProductOut>>(await _context.Products.ToListAsync());
            return temp;
        }

        public async Task<List<ProductOut>> GetProductsByCategoryID(Guid id)
        {
            List<ProductOut> temp = _mapper.Map<List<ProductOut>>(await _context.Products.Where(e=>e.CategoryID == id).ToListAsync());
            return temp;
        }

        public async Task<ProductOut> PostProduct(ProductIn product)
        {
            Product temp = _mapper.Map<Product>(product);
            _context.Products.Add(temp);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductOut>(temp);
        }
    }

    public interface IProductService
    {
        Task<ProductOut> GetProduct(Guid id);
        Task<List<ProductOut>> GetProducts();
        Task<List<ProductOut>> GetProductsByCategoryID(Guid id);
        Task<ProductOut> PostProduct(ProductIn product);
    }
}
