using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServer.Resources
{
    public class InvoiceSellResource
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string ClientID { get; set; }
        public double PriceNetto { get; set; }
        public double PriceBrutto { get; set; }
        public DateTime PaymentDeadline { get; set; }
        public bool IsPaid { get; set; }
    }
}
