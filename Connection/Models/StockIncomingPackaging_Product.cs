using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockIncomingPackaging_Product
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idproduct { get; set; }
        public int SubStorageTo { get; set; }
        public int? SubStorageResult { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Received { get; set; }
        public decimal? Damaged { get; set; }
        public decimal? NeverArrived { get; set; }
        public int Status { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }

        public virtual StockIncomingPackaging StockIncomingPackaging { get; set; }
        public virtual Packaging Packaging { get; set; }
    }
}
