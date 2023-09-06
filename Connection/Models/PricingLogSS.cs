using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PricingLogSS
    {
        public int Id { get; set; }
        public int Idmaster { get; set; }
        public DateTime Tgl { get; set; }
        public string Approval { get; set; }
        public decimal MinimumLama { get; set; }
        public decimal MinimumBaru { get; set; }

        public virtual PricingTableSS PricingTableSS { get; set; }
    }
}
