﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServer.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<InvoiceBuy> InvoicesBuy { get; set; }
        public virtual ICollection<InvoiceSell> InvoicesSell { get; set; }
    }
}
