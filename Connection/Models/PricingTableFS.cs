using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PricingTableFS
    {
        public PricingTableFS()
        {
            PricingLogFSes = new HashSet<PricingLogFS>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string Keterangan { get; set; }
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

        public virtual ICollection<PricingLogFS> PricingLogFSes { get; set; }
    }
}
