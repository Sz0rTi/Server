using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class Client
    {
        //[Key, ForeignKey("Invoice")]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Mail { get; set; }
        public string NIP { get; set; }
        public virtual ICollection<InvoiceSell> InvoicesSell { get; set; }
    }
}
