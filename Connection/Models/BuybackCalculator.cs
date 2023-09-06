using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class BuybackCalculator
    {
        public int Id { get; set; }
        public string TransctionType { get; set; }
        public int? MaxValue { get; set; }
        public string Category { get; set; }
        public int? BuybackPercentage { get; set; }
        public int? MinPeriode { get; set; }
        public int? MaxPeriode { get; set; }
    }
}
