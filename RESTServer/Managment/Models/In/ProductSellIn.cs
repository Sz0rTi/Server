using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managment.Models.In
{
    public class ProductSellIn
    {
        public Guid ProductID { get; set; }
        public int Amount { get; set; }
        public double PricePerItemNetto { get; set; }
        public double PricePerItemBrutto { get; set; }
        public Guid TaxStageID { get; set; }
    }

    public class ProductSellIn_To_ProductSell : Profile
    {
        public ProductSellIn_To_ProductSell()
        {
            CreateMap<ProductSellIn, ProductSell>()
                .ForMember(e => e.ID, e => e.Ignore())
                .ForMember(e => e.InvoiceSellID, e => e.Ignore())
                .ForMember(e => e.Product, e => e.Ignore())
                .ForMember(e => e.InvoiceSell, e => e.Ignore());
        }
    }
}
