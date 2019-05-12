using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServer.Models
{
    public class TaxStage
    {
        //[Key, ForeignKey("TaxStageID")]
        public int ID { get; set; }
        public double Stage { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
