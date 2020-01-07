using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class InvoiceSell
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Guid ClientID { get; set; }
        public string Code { get; set; }
        public double PriceNetto { get; set; }
        public double PriceBrutto { get; set; }
        public DateTime PaymentDeadline { get; set; }
        public bool IsPaid { get; set; }
        public string UserID { get; set; }
        public virtual List<ProductSell> ProductsSell { get; set; }
        public virtual Client Client { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
