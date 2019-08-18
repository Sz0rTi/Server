using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class InvoiceSell
    {
        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        public Guid ClientID { get; set; }
        public double PriceNetto { get; set; }
        public double PriceBrutto { get; set; }
        public DateTime PaymentDeadline { get; set; }
        public bool IsPaid { get; set; }
        public virtual ICollection<ProductSell> ProductsSell { get; set; }
        public virtual Client Client { get; set; }
        public virtual User User { get; set; }
    }
}
