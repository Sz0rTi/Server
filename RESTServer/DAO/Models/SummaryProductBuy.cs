using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Models
{
    public class SummaryProductBuy
    {
        public Guid ID { get; set; }
        public Guid SummaryID { get; set; }
        public string ProductName { get; set; }
        public int Amount { get; set; }
        public double AvgBuyPrice { get; set; }
        public double SumBought { get; set; }
        public string UserID { get; set; }
        public virtual Summary Summary { get; set; }
    }
}
