using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServer.Models
{
    public class ProductBuy
    {
        public long ProductBuyId { get; set; }
        public long InvoiceBuyId { get; set; }
        public long ProductId { get; set; }
        public int Amount { get; set; }
        public double PricePerItemNetto { get; set; }
        public double PricePerItemBrutto { get; set; }
        public virtual Product Product { get; set; }
        public virtual InvoiceBuy InvoiceBuy { get; set; }
    }
}
