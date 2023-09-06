using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class SalesReceiptDetailLakuEmas
    {
        public int Id { get; set; }
        public string NoLakuEmas { get; set; }
        public decimal? RateLm { get; set; }
        public decimal? WeightLm { get; set; }
        public decimal? Value { get; set; }
    }
}
