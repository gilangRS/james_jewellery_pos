using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockReceiveMounting_PricingProduct
    {
        public int Id { get; set; }
        public decimal GoldRate { get; set; }
        public decimal Netto { get; set; }
        public decimal Kadar { get; set; }
        public decimal TotalProduct { get; set; }
        public decimal Total { get; set; }
        public DateTime EfektifGold { get; set; }

        public virtual StockReceiveMounting StockReceiveMounting { get; set; }
    }
}
