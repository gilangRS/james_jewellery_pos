using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PricingLogResellMU
    {
        public int Id { get; set; }
        public int Idmaster { get; set; }
        public DateTime? Tgl { get; set; }
        public decimal? PersenLama { get; set; }
        public decimal? PersenBaru { get; set; }
        public string Approval { get; set; }

        public virtual PricingTableResellMU PricingTableResellMU { get; set; }
    }
}
