using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PricingTableFM
    {
        public PricingTableFM()
        {
            PricingLogFMs = new HashSet<PricingLogFM>();
        }

        public int Id { get; set; }
        public int Idbrand { get; set; }
        public int Iditem { get; set; }
        public int Idcons { get; set; }
        public bool SetupFlag { get; set; }
        public int StatusPricing { get; set; }
        public decimal? Biaya { get; set; }
        public decimal? BiayaPending { get; set; }
        public decimal? Mutasi { get; set; }
        public decimal? MutasiPersen { get; set; }
        public decimal? InputNo { get; set; }
        public decimal? InputRo { get; set; }
        public decimal? PendingNo { get; set; }
        public decimal? PendingRo { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }
        public decimal? Pembagi { get; set; }
        public decimal? PendingPembagi { get; set; }
        public decimal? PembagiR { get; set; }
        public decimal? PendingPembagiR { get; set; }

        public virtual CompanyBrand CompanyBrand { get; set; }
        public virtual CharProcessCon CharProcessCon { get; set; }
        public virtual CharProductItem CharProductItem { get; set; }
        public virtual ICollection<PricingLogFM> PricingLogFMs { get; set; }
    }
}
