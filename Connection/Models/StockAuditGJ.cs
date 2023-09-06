using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockAuditGJ
    {
        public StockAuditGJ()
        {
            StockAuditDetails = new HashSet<StockAuditDetail>();
            StockAuditGJDetails = new HashSet<StockAuditGJDetail>();
            StockAuditItemGJs = new HashSet<StockAuditItemGJ>();
        }

        public int Id { get; set; }
        public int Idlokasi { get; set; }
        public int TipeLokasi { get; set; }
        public string Nomor { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }
        public string Keterangan { get; set; }
        public decimal? TotalItemAudit { get; set; }
        public decimal? TotalItemActual { get; set; }
        public bool? StatusFinish { get; set; }
        public DateTime? FinishJam { get; set; }

        public virtual ICollection<StockAuditDetail> StockAuditDetails { get; set; }
        public virtual ICollection<StockAuditGJDetail> StockAuditGJDetails { get; set; }
        public virtual ICollection<StockAuditItemGJ> StockAuditItemGJs { get; set; }
    }
}
