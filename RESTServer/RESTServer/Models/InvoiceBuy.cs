using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServer.Models
{
    public class InvoiceBuy
    {
        public long InvoiceBuyId { get; set; }
        public long SellerId { get; set; }
        public DateTime Date { get; set; }
        //public List<ProductBuy> ProductBuyList { get; set; }
        public double PriceNetto { get; set; }
        public double PriceBrutto { get; set; }
        public bool IsPaid { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual ICollection<ProductBuy> Products { get; set; }
        public virtual User User { get; set; }
    }
}
