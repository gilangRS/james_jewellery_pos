using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PricingTableMU
    {
        public PricingTableMU()
        {
            PricingLogMUs = new HashSet<PricingLogMU>();
        }

        public int Id { get; set; }
        public int Idcategory { get; set; }
        public int Idlevel { get; set; }
        public int Iddist { get; set; }
        public bool SetupFlag { get; set; }
        public int StatusPricing { get; set; }
        public decimal? Persen { get; set; }
        public decimal? PersenPending { get; set; }
        public decimal? Mutasi { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }

        public virtual CharProductCategory CharProductCategory { get; set; }
        public virtual CharStoneDist CharStoneDist { get; set; }
        public virtual CharProductLevel CharProductLevel { get; set; }
        public virtual ICollection<PricingLogMU> PricingLogMUs { get; set; }
    }
}
