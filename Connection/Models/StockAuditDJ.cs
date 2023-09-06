using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockAuditDJ
    {
        public StockAuditDJ()
        {
            StockAuditDetails = new HashSet<StockAuditDetail>();
            StockAuditDJDetails = new HashSet<StockAuditDJDetail>();
            StockAuditItemDJs = new HashSet<StockAuditItemDJ>();
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
        public virtual ICollection<StockAuditDJDetail> StockAuditDJDetails { get; set; }
        public virtual ICollection<StockAuditItemDJ> StockAuditItemDJs { get; set; }
    }
}
