using System;

namespace DAO.Models
{
    public class ProductSell
    {
        //[Key, ForeignKey("Product,Invoice")]
        public Guid ID { get; set; }
        public Guid InvoiceSellID { get; set; }
        public Guid ProductID { get; set; }
        public int Amount { get; set; }
        public double PricePerItemNetto { get; set; }
        public double PricePerItemBrutto { get; set; }
        public Guid TaxStageID { get; set; }
        public Guid UnitID { get; set; }
        public virtual Product Product { get; set; }
        public virtual InvoiceSell InvoiceSell { get; set; }
    }
}
