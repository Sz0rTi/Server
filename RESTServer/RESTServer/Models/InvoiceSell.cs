﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServer.Models
{
    public class InvoiceSell
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string ClientID { get; set; }
        public double PriceNetto { get; set; }
        public double PriceBrutto { get; set; }
        public DateTime PaymentDeadline { get; set; }
        public bool IsPaid { get; set; }
        public virtual ICollection<ProductSell> ProductsSell { get; set; }
        public virtual Client Client { get; set; }
        public virtual User User { get; set; }
    }
}
