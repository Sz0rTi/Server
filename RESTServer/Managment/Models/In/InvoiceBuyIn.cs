using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managment.Models.In
{
    public class InvoiceBuyIn
    {
        public Guid SellerID { get; set; }
        public DateTime PaymentDeadline { get; set; }
        public Guid PaymentMethodID { get; set; }
        public double PriceNetto { get; set; }
        public double PriceBrutto { get; set; }
        public bool IsPaid { get; set; }
        public string Code { get; set; }
        public List<ProductBuyIn> ProductsBuy { get; set; }
    }

    public class InvoiceBuyIn_To_InvoiceBuy : Profile
    {
        public InvoiceBuyIn_To_InvoiceBuy()
        {
            CreateMap<InvoiceBuyIn, InvoiceBuy>();
        }
    }
}
