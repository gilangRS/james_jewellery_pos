using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockAuditItemDJ
    {
        public int Id { get; set; }
        public int AuditId { get; set; }
        public int Idproduct { get; set; }
        public string Nomor { get; set; }

        public virtual StockAuditDJ StockAuditDJ { get; set; }
        public virtual StockProductDJ StockProductDJ { get; set; }
    }
}
