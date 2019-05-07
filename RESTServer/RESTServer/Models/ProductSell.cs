using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServer.Models
{
    public class ProductSell
    {
        //[Key, ForeignKey("Product,Invoice")]
        public long ProductSellId { get; set; }
        public long InvoiceSellId { get; set; }
        public long ProductId { get; set; }
        public int Amount { get; set; }
        public double PricePerItemNetto{ get; set; }
        public double PricePerItemBrutto { get; set; }
        public long TaxStageId { get; set; }
        public virtual Product Product { get; set; }
        public virtual InvoiceSell InvoiceSell { get; set; }
    }
}
