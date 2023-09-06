using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PromoPG
    {
        public PromoPG()
        {
            PromoPG_Details = new HashSet<PromoPG_Detail>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string Keterangan { get; set; }
        public DateTime? TglStart { get; set; }
        public DateTime? TglExpire { get; set; }
        public bool? Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string OperatorNama { get; set; }
        public DateTime? ApprovalTgl { get; set; }
        public string ApprovalNama { get; set; }
        public decimal? DiscountNominal { get; set; }
        public decimal? DiscountPersen { get; set; }
        public int? Tipe { get; set; }
        public decimal? PoinReward { get; set; }
        public decimal? PromoHarga { get; set; }
        public int? StatusAsp { get; set; }
        public bool? StatusActive { get; set; }
        public bool? StatusDiscNormal { get; set; }
        public bool? StatusDiscMembership { get; set; }

        public virtual ICollection<PromoPG_Detail> PromoPG_Details { get; set; }
    }
}
