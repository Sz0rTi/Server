using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServer.Models
{
    public class ProductInOrder
    {
        //[Key, ForeignKey("Product,Invoice")]
        public long ProductInOrderId { get; set; }
        public long InvoiceId { get; set; }
        public long ProductId { get; set; }
        public int Amount { get; set; }
        public double PricePerItem { get; set; }
        public long TaxStageId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
