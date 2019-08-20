using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managment.Models.Out
{
    public class SellerOut
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string NIP { get; set; }
    }

    public class Seller_To_SellerOut : Profile
    {
        public Seller_To_SellerOut()
        {
            CreateMap<Seller, SellerOut>();
        }
    }
}
