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
    public class SellerService : ISellerService
    {
        private readonly IMapper _mapper;
        private readonly MagazineContext _context;
        private IHttpContextAccessor _accessor;
        private string UserId { get; set; }

        public SellerService(IMapper mapper, MagazineContext context, IHttpContextAccessor accessor)
        {
            _mapper = mapper;
            _context = context;
            _accessor = accessor;
            UserId = _context.Users.Where(u => u.UserName == _accessor.HttpContext.User.Identity.Name).First().Id;
        }

        public async Task<bool> CheckSeller(string nip)
        {
            if (_context.Sellers.FirstOrDefault(e => e.NIP == nip) == null)
            {
                return false;
            }
            else return true;
        }

        public async Task<SellerOut> GetSeller(Guid id)
        {
            Seller temp = _context.Sellers.FirstOrDefault(e => e.ID == id);
            if (temp == null) return null;
            return _mapper.Map<SellerOut>(temp);
        }

        public async Task<List<SellerOut>> GetSellers()
        {
            List<SellerOut> temp = _mapper.Map<List<SellerOut>>(await _context.Sellers.Where(e => e.UserID == UserId).ToListAsync());
            return temp;
        }

        public async Task<SellerOut> PostSeller(SellerIn seller)
        {
            Seller temp = _mapper.Map<Seller>(seller);
            temp.UserID = UserId;
            _context.Sellers.Add(temp);
            await _context.SaveChangesAsync();
            return _mapper.Map<SellerOut>(temp);
        }
    }

    public interface ISellerService
    {
        Task<List<SellerOut>> GetSellers();
        Task<SellerOut> GetSeller(Guid id);
        Task<SellerOut> PostSeller(SellerIn seller);
        Task<bool> CheckSeller(string nip);
    }
}
