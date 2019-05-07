using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServer.Models
{
    public class Product
    {
        //[Key, ForeignKey("Category")]
        public long ProductId { get; set; }
        public string Name { get; set; }
        public double PriceNetto { get; set; }
        public string Description { get; set; }
        public long CategoryId { get; set; }
        public long TaxStageId { get; set; }
        public long UnitId { get; set; }
        public virtual TaxStage TaxStage { get; set; }
        public virtual Category Category { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
