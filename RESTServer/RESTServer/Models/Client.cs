﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServer.Models
{
    public class Client
    {
        //[Key, ForeignKey("Invoice")]
        public long ClientId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Mail { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
