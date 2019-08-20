using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class ProductBuy
    {

        public Guid ID { get; set; }
        public Guid InvoiceBuyID { get; set; }
        public Guid ProductID { get; set; }
        public int Amount { get; set; }
        public double PricePerItemNetto { get; set; }
        public double PricePerItemBrutto { get; set; }
        public Guid TaxStageID { get; set; }
        public virtual Product Product { get; set; }
        public virtual InvoiceBuy InvoiceBuy { get; set; }
    }
}
