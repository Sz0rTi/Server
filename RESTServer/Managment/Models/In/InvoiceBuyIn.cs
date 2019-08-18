using System;
using System.Collections.Generic;
using System.Text;

namespace Managment.Models.In
{
    public class InvoiceBuyIn
    {
        public Guid SellerID { get; set; }
        public DateTime Date { get; set; }
        public double PriceNetto { get; set; }
        public double PriceBrutto { get; set; }
        public bool IsPaid { get; set; }
        public List<ProductBuyIn> Products { get; set; }
    }
}
