using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class AdjustmentSouvenir
    {
        public AdjustmentSouvenir()
        {
            AdjustmentSouvenirProducts = new HashSet<AdjustmentSouvenirProduct>();
        }

        public int Id { get; set; }
        public string Nomor { get; set; }
        public int? TipeLokasi { get; set; }
        public int? Idlokasi { get; set; }
        public int? StatusAdjustment { get; set; }
        public string Keterangan { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public bool? Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public int? Status { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }

        public virtual ICollection<AdjustmentSouvenirProduct> AdjustmentSouvenirProducts { get; set; }
    }
}
