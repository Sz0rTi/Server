using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class TaxStage
    {
        //[Key, ForeignKey("TaxStageID")]
        public Guid ID { get; set; }
        public double Stage { get; set; }
        public virtual List<Product> Product { get; set; }
    }
}
