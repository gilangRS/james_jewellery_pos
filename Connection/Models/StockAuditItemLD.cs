using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockAuditItemLD
    {
        public int Id { get; set; }
        public int AuditId { get; set; }
        public int Idproduct { get; set; }
        public string Nomor { get; set; }

        public virtual StockAuditLD StockAuditLD { get; set; }
        public virtual StockProductLD_Stone1B StockProductLD_Stone1B { get; set; }
    }
}
