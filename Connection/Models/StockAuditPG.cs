using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockAuditPG
    {
        public StockAuditPG()
        {
            StockAuditDetails = new HashSet<StockAuditDetail>();
            StockAuditItemPGs = new HashSet<StockAuditItemPG>();
            StockAuditPGDetails = new HashSet<StockAuditPGDetail>();
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
        public virtual ICollection<StockAuditItemPG> StockAuditItemPGs { get; set; }
        public virtual ICollection<StockAuditPGDetail> StockAuditPGDetails { get; set; }
    }
}
