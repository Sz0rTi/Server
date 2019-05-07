using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServer.Models
{
    public class Invoice
    {
        //[Key, ForeignKey("Client,Product")]
        public int InvoiceId { get; set; }
        public DateTime Date { get; set; }
        public string ClientId { get; set; }
        public double Price { get; set; }
        public DateTime PaymentDeadline { get; set; }
        public bool IsPaid { get; set; }
        public List<ProductInOrder> ProductsList { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual Client Client { get; set; }
    }
}
