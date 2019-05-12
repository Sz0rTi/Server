using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServer.Resources
{
    public class ProductBuyResource
    {
        public int ID { get; set; }
        public int InvoiceBuyID { get; set; }
        public int ProductID { get; set; }
        public int Amount { get; set; }
        public double PricePerItemNetto { get; set; }
        public double PricePerItemBrutto { get; set; }
    }
}
