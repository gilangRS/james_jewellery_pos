using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class RevalProductGJ_CostingProduct
    {
        public int Id { get; set; }
        public decimal GoldRate { get; set; }
        public decimal Netto { get; set; }
        public decimal Kadar { get; set; }
        public decimal TotalProduct { get; set; }
        public decimal TotalStone1A { get; set; }
        public decimal? TotalStone1B { get; set; }
        public decimal? TotalStone2 { get; set; }
        public decimal? TotalStone3 { get; set; }
        public decimal? TotalStone4 { get; set; }
        public decimal? TotalStone5 { get; set; }
        public decimal Total { get; set; }
        public DateTime EfektifGold { get; set; }

        public virtual RevalProductGJ RevalProductGJ { get; set; }
    }
}
