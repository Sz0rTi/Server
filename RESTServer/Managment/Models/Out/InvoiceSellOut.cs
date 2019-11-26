using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managment.Models.Out
{
    public class InvoiceSellOut
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string ClientID { get; set; }
        public double PriceNetto { get; set; }
        public double PriceBrutto { get; set; }
        public DateTime PaymentDeadline { get; set; }
        public bool IsPaid { get; set; }
        public List<ProductSellOut> ProductsSell { get; set; }
    }

    public class InvoiceSell_To_InvoiceSellOut : Profile
    {
        public InvoiceSell_To_InvoiceSellOut()
        {
            CreateMap<InvoiceSell, InvoiceSellOut>();
        }
    }

}
