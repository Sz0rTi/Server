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
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string NIP { get; set; }
        public string UserID { get; set; }
        public virtual ICollection<InvoiceSell> InvoicesSell { get; set; }
    }
}
