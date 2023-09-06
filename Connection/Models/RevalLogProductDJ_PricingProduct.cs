using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class RevalLogProductDJ_PricingProduct
    {
        public int Id { get; set; }
        public decimal GoldRate { get; set; }
        public decimal GoldRateOld { get; set; }
        public decimal Netto { get; set; }
        public decimal Kadar { get; set; }
        public decimal TotalProduct { get; set; }
        public decimal TotalProductOld { get; set; }
        public decimal TotalStone1A { get; set; }
        public decimal TotalStone1Aold { get; set; }
        public decimal? TotalStone1B { get; set; }
        public decimal? TotalStone1Bold { get; set; }
        public decimal? TotalStone2 { get; set; }
        public decimal? TotalStone2Old { get; set; }
        public decimal? TotalStone3 { get; set; }
        public decimal? TotalStone3Old { get; set; }
        public decimal? TotalStone4 { get; set; }
        public decimal? TotalStone4Old { get; set; }
        public decimal? TotalStone5 { get; set; }
        public decimal? TotalStone5Old { get; set; }
        public decimal Total { get; set; }
        public decimal TotalOld { get; set; }
        public DateTime? EfektifGold { get; set; }
        public DateTime? EfektifGoldOld { get; set; }

        public virtual RevalLogProductDJ RevalLogProductDJ { get; set; }
    }
}
