using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServer.Resources
{
    public class ProductResource
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double PriceNetto { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public int TaxStageID { get; set; }
        public int UnitID { get; set; }
        public int Amount { get; set; }
    }
}
