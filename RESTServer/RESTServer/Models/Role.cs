﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTServer.Models
{
    public class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
