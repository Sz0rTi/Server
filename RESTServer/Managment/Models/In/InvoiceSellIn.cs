using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managment.Models.In
{
    public class InvoiceSellIn
    {
        public Guid ClientID { get; set; }
        public double PriceNetto { get; set; }
        public double PriceBrutto { get; set; }
        public Guid PaymentMethodID { get; set; }
        public DateTime PaymentDeadline { get; set; }
        public bool IsPaid { get; set; }
        public List<ProductSellIn> ProductsSell { get; set; }
    }

    public class InvoiceSellIn_To_InvoiceSell : Profile
    {
        public InvoiceSellIn_To_InvoiceSell()
        {
            CreateMap<InvoiceSellIn, InvoiceSell>();
                /*.ForMember(e => e.ID, e => e.Ignore())
                .ForMember(e => e.Date, e => e.Ignore())
                //.ForMember(e => e.ProductsSell, e => e.Ignore())
                .ForMember(e => e.Client, e => e.Ignore())
                .ForMember(e => e.User, e => e.Ignore());*/
        }
    }
}
