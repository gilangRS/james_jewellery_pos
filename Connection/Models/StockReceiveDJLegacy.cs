using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockReceiveDJLegacy
    {
        public int Id { get; set; }
        public string Plu { get; set; }
        public decimal M { get; set; }

        public virtual StockProductDJ StockReceiveDJ { get; set; }
    }
}
