using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Models
{
    public class PaymentMethod
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string UserID { get; set; }
    }
}
