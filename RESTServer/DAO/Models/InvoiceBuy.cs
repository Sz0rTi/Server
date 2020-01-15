using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class InvoiceBuy
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid SellerID { get; set; }
        public DateTime Date { get; set; }
        public DateTime PaymentDeadline { get; set; }
        public double PriceNetto { get; set; }
        public double PriceBrutto { get; set; }
        public bool IsPaid { get; set; }
        public string UserID { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual List<ProductBuy> ProductsBuy { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
