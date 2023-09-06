using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PointRewardGJ
    {
        public PointRewardGJ()
        {
            PointRewardLogGJs = new HashSet<PointRewardLogGJ>();
        }

        public int Id { get; set; }
        public int Idcategory { get; set; }
        public string Nama { get; set; }
        public string Keterangan { get; set; }
        public decimal? Rupiah { get; set; }
        public decimal? RupiahPending { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }

        public virtual CharProductCategory CharProductCategory { get; set; }
        public virtual ICollection<PointRewardLogGJ> PointRewardLogGJs { get; set; }
    }
}
