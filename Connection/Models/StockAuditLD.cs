using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockAuditLD
    {
        public StockAuditLD()
        {
            StockAuditDetails = new HashSet<StockAuditDetail>();
            StockAuditItemLDs = new HashSet<StockAuditItemLD>();
            StockAuditLDDetails = new HashSet<StockAuditLDDetail>();
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
        public virtual ICollection<StockAuditItemLD> StockAuditItemLDs { get; set; }
        public virtual ICollection<StockAuditLDDetail> StockAuditLDDetails { get; set; }
    }
}
