using System;

namespace DAO.Models
{
    public class ProductSell
    {
        public Guid ID { get; set; }
        public Guid InvoiceSellID { get; set; }
        public Guid ProductID { get; set; }
        public int Amount { get; set; }
        public double PricePerItemNetto { get; set; }
        public double PricePerItemBrutto { get; set; }
        public double BasePriceNetto { get; set; }
        public Guid TaxStageID { get; set; }
        public Guid UnitID { get; set; }
        public string UserID { get; set; }
        public virtual Product Product { get; set; }
        public virtual InvoiceSell InvoiceSell { get; set; }
    }
}
