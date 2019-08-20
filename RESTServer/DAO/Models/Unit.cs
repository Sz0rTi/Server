using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAO.Models
{
    public class Unit
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
