using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managment.Models.In
{
    public class SellerIn
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string NIP { get; set; }
        List<InvoiceBuy> Invoices = new List<InvoiceBuy>();
    }

    public class SellerIn_To_Seller : Profile
    {
        public SellerIn_To_Seller()
        {
            CreateMap<SellerIn, Seller>()
                .ForMember(e => e.ID, e => e.Ignore())
                .ForMember(e => e.InvoicesBuy, e => e.Ignore());
        }
    }
}
