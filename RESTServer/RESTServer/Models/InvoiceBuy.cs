﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServer.Models
{
    public class InvoiceBuy
    {
        public int ID { get; set; }
        public int SellerID { get; set; }
        public DateTime Date { get; set; }
        public double PriceNetto { get; set; }
        public double PriceBrutto { get; set; }
        public bool IsPaid { get; set; }
        public virtual Seller Seller { get; set; }
        public virtual ICollection<ProductBuy> ProductsBuy { get; set; }
        public virtual User User { get; set; }
    }
}
