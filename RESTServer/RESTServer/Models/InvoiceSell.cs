using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServer.Models
{
    public class InvoiceSell
    {
        //[Key, ForeignKey("Client,Product")]
        public int InvoiceSellId { get; set; }
        public DateTime Date { get; set; }
        public string ClientId { get; set; }
        public double PriceNetto { get; set; }
        public double PriceBrutto { get; set; }
        public DateTime PaymentDeadline { get; set; }
        public bool IsPaid { get; set; }
        //public List<ProductSell> ProductsSellList { get; set; }
        public virtual ICollection<ProductSell> Products { get; set; }
        public virtual Client Client { get; set; }
        public virtual User User { get; set; }
    }
}
