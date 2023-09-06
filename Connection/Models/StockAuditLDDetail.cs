using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockAuditLDDetail
    {
        public int Id { get; set; }
        public int AuditId { get; set; }
        public int Idproduct { get; set; }
        public string Nomor { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }
        public bool BandrolCheck { get; set; }
        public bool ImgCheck { get; set; }
        public bool? ImgNone { get; set; }
        public string NoMeja { get; set; }
        public string Keterangan { get; set; }

        public virtual StockAuditLD StockAuditLD { get; set; }
        public virtual StockProductLD_Stone1B StockProductLD_Stone1B { get; set; }
    }
}
