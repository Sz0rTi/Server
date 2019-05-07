using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServer.Models
{
    public class Category
    {
        //[Key, ForeignKey("CategoryID")]
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
