using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PromoGJ
    {
        public PromoGJ()
        {
            PromoGJ_Details = new HashSet<PromoGJ_Detail>();
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

        public virtual ICollection<PromoGJ_Detail> PromoGJ_Details { get; set; }
    }
}
