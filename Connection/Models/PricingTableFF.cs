using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PricingTableFF
    {
        public PricingTableFF()
        {
            PricingLogFFs = new HashSet<PricingLogFF>();
        }

        public int Id { get; set; }
        public int Iditem { get; set; }
        public int Idfinishing { get; set; }
        public bool SetupFlag { get; set; }
        public int StatusPricing { get; set; }
        public decimal? Biaya { get; set; }
        public decimal? BiayaPending { get; set; }
        public decimal? Mutasi { get; set; }
        public decimal? MutasiPersen { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }

        public virtual CharProcessFinishing CharProcessFinishing { get; set; }
        public virtual CharProductItem CharProductItem { get; set; }
        public virtual ICollection<PricingLogFF> PricingLogFFs { get; set; }
    }
}
