using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managment.Models.Out
{
    public class ProductSellOut
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid InvoiceSellID { get; set; }
        public Guid ProductID { get; set; }
        public int Amount { get; set; }
        public double PricePerItemNetto { get; set; }
        public double PricePerItemBrutto { get; set; }
        public double BasePriceNetto { get; set; }
        public Guid TaxStageID { get; set; }
        public Guid UnitID { get; set; }
    }

    public class ProductSell_To_ProductSellOut : Profile
    {
        public ProductSell_To_ProductSellOut()
        {
            CreateMap<ProductSell, ProductSellOut>();
        }
    }
}
