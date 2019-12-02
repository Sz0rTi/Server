using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managment.Models.Out
{
    public class ProductBuyOut
    {
        public Guid ID { get; set; }
        public int MyProperty { get; set; }
        public Guid InvoiceBuyID { get; set; }
        public Guid ProductID { get; set; }
        public int Amount { get; set; }
        public double PricePerItemNetto { get; set; }
        public double PricePerItemBrutto { get; set; }
    }

    public class ProductBuy_To_ProductBuyOut : Profile
    {
        public ProductBuy_To_ProductBuyOut()
        {
            CreateMap<ProductBuy, ProductBuyOut>();
        }
    }
}
