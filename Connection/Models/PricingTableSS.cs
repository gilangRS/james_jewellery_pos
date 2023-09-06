using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PricingTableSS
    {
        public PricingTableSS()
        {
            PricingLogSSes = new HashSet<PricingLogSS>();
        }

        public int Id { get; set; }
        public int Idcategory { get; set; }
        public int Idlevel { get; set; }
        public int Iddist { get; set; }
        public int Idsegmen { get; set; }
        public int SegmenSistem { get; set; }
        public bool SetupFlag { get; set; }
        public int StatusPricing { get; set; }
        public decimal? Minimum { get; set; }
        public decimal? MinimumPending { get; set; }
        public decimal? Mutasi { get; set; }
        public decimal? MutasiPersen { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }

        public virtual CharProductCategory CharProductCategory { get; set; }
        public virtual CharStoneDist CharStoneDist { get; set; }
        public virtual CharProductLevel CharProductLevel { get; set; }
        public virtual CharProductSegmen CharProductSegmen { get; set; }
        public virtual ICollection<PricingLogSS> PricingLogSSes { get; set; }
    }
}
