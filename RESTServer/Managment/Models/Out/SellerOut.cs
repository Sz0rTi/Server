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
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
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
