using AutoMapper;
using DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managment.Models.Out
{
    public class InvoiceBuyOut
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public Guid SellerID { get; set; }
        public DateTime Date { get; set; }
        public double PriceNetto { get; set; }
        public double PriceBrutto { get; set; }
        public bool IsPaid { get; set; }
    }

    public class InvoiceBuy_To_InvoiceBuyOut : Profile
    {
        public InvoiceBuy_To_InvoiceBuyOut()
        {
            CreateMap<InvoiceBuy, InvoiceBuyOut>();
        }
    }
}
