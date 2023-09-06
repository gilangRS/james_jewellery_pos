using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PricingTableResellMU
    {
        public PricingTableResellMU()
        {
            PricingLogResellMUs = new HashSet<PricingLogResellMU>();
        }

        public int Id { get; set; }
        public bool SetupFlag { get; set; }
        public int StatusPricing { get; set; }
        public decimal? Persen { get; set; }
        public decimal? PersenPending { get; set; }
        public decimal? Mutasi { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }

        public virtual ICollection<PricingLogResellMU> PricingLogResellMUs { get; set; }
    }
}
