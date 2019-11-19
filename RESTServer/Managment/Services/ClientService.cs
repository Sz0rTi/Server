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
    internal class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly MagazineContext _context;

        public ClientService(IMapper mapper, MagazineContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> CheckClient(string nip)
        {
            if (_context.Clients.FirstOrDefault(e => e.NIP == nip) == null)
            {
                return false;
            }
            else return true;
        }

        public async Task<ClientOut> GetClient(Guid id)
        {
            Client client = _context.Clients.FirstOrDefault(e => e.ID == id);
            if (temp == null) return null;
            return _mapper.Map<ClientOut>(client);
        }

        public async Task<List<ClientOut>> GetClients()
        {
            List<ClientOut> temp = _mapper.Map<List<ClientOut>>(await _context.Clients.ToListAsync());
            return temp;
        }

        public async Task<ClientOut> PostClient(ClientIn client)
        {
            Client temp = _mapper.Map<Client>(client);
            _context.Clients.Add(temp);
            await _context.SaveChangesAsync();
            return _mapper.Map<ClientOut>(temp);
        }
    }

    public interface IClientService
    {
        Task<List<ClientOut>> GetClients();
        Task<ClientOut> GetClient(Guid id);
        Task<ClientOut> PostClient(ClientIn client);
        Task<bool> CheckClient(string nip);
    }
}
