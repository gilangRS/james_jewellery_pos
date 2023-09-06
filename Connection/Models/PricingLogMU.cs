using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PricingLogMU
    {
        public int Id { get; set; }
        public int Idmaster { get; set; }
        public DateTime Tgl { get; set; }
        public string Approval { get; set; }
        public decimal PersenLama { get; set; }
        public decimal PersenBaru { get; set; }

        public virtual PricingTableMU PricingTableMU { get; set; }
    }
}
