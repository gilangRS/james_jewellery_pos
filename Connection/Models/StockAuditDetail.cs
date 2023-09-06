using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockAuditDetail
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Iddj { get; set; }
        public int Idpg { get; set; }
        public int Idgj { get; set; }
        public int Idld { get; set; }

        public virtual StockAuditDJ StockAuditDJ { get; set; }
        public virtual StockAudit StockAudit { get; set; }
        public virtual StockAuditGJ StockAuditGJ { get; set; }
        public virtual StockAuditLD StockAuditLD { get; set; }
        public virtual StockAuditPG StockAuditPG { get; set; }
    }
}
