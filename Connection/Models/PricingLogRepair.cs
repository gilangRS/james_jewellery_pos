using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PricingLogRepair
    {
        public int Id { get; set; }
        public int Idmaster { get; set; }
        public DateTime Tgl { get; set; }
        public string Approval { get; set; }
        public decimal BiayaLama { get; set; }
        public decimal BiayaBaru { get; set; }
        public decimal? CostingLama { get; set; }
        public decimal? CostingBaru { get; set; }

        public virtual PricingTableRepair PricingTableRepair { get; set; }
    }
}
