using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServer.Models
{
    public class Unit
    {
        public long UnitId { get; set; }
        public string Name { get; set; }
        public virtual Product Product { get; set; }
    }
}
