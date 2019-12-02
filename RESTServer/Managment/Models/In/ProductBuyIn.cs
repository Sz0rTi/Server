using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Managment.Models.In
{
    public class ProductBuyIn
    {
        public Guid ProductID { get; set; }
        public int Amount { get; set; }
        public double PricePerItemNetto { get; set; }
        public double PricePerItemBrutto { get; set; }
        public Guid TaxStageID { get; set; }
        public Guid UnitID { get; set; }
    }

    public class ProductBuyIn_To_ProductBuy : Profile
    {
        public ProductBuyIn_To_ProductBuy()
        {
            CreateMap<ProductBuyIn, ProductBuy>();
                /*.ForMember(e => e.ID, e => e.Ignore())
                .ForMember(e => e.InvoiceBuyID, e => e.Ignore())
                .ForMember(e => e.Product, e => e.Ignore())
                .ForMember(e => e.InvoiceBuy, e => e.Ignore());*/
        }
    }
}
