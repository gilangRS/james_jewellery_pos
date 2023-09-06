using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PricingTableRepair
    {
        public PricingTableRepair()
        {
            PricingLogRepairs = new HashSet<PricingLogRepair>();
        }

        public int Id { get; set; }
        public int Idrepair { get; set; }
        public bool SetupFlag { get; set; }
        public int StatusPricing { get; set; }
        public decimal? Costing { get; set; }
        public decimal? CostingPending { get; set; }
        public decimal? Biaya { get; set; }
        public decimal? BiayaPending { get; set; }
        public decimal? Mutasi { get; set; }
        public decimal? MutasiPersen { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }

        public virtual CharProcessRepair CharProcessRepair { get; set; }
        public virtual ICollection<PricingLogRepair> PricingLogRepairs { get; set; }
    }
}
