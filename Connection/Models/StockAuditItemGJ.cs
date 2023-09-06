using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockAuditItemGJ
    {
        public int Id { get; set; }
        public int AuditId { get; set; }
        public int Idproduct { get; set; }
        public string Nomor { get; set; }

        public virtual StockAuditGJ StockAuditGJ { get; set; }
        public virtual StockProductGJ StockProductGJ { get; set; }
    }
}
