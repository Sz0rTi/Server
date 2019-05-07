using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServer.Models
{
    public class Role
    {
        public long RoleId { get; set; }
        public string Name { get; set; }
        public virtual User User { get; set; }
    }
}
