using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class Product
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public double PriceNetto { get; set; }
        public string Description { get; set; }
        public Guid CategoryID { get; set; }
        public Guid TaxStageID { get; set; }
        public Guid UnitID { get; set; }
        public int Amount { get; set; }
        public string UserID { get; set; }


        public virtual TaxStage TaxStage { get; set; }
        public virtual Category Category { get; set; }
        public virtual Unit Unit { get; set; }
        //public virtual List<Purchase> Purchases { get; set; }
    }
}
