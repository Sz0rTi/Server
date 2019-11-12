﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Models
{
    public class Purchase
    {
        public Guid ID { get; set; }
        public Guid ProductID { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }

        public virtual Product Product { get; set; }
    }
}
