using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockAuditItemPG
    {
        public int Id { get; set; }
        public int AuditId { get; set; }
        public int Idproduct { get; set; }
        public string Nomor { get; set; }

        public virtual StockAuditPG StockAuditPG { get; set; }
        public virtual StockProductPG StockProductPG { get; set; }
    }
}
