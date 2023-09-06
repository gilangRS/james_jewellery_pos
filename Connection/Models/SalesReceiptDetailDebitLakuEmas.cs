using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class SalesReceiptDetailDebitLakuEmas
    {
        public int Id { get; set; }
        public int? IdsalesReceiptDetail { get; set; }
        public string Plu { get; set; }
        public decimal? RateLm { get; set; }
        public decimal? RateLeibuy { get; set; }
        public decimal? RateLeisell { get; set; }
        public decimal? RateLeimid { get; set; }
    }
}
