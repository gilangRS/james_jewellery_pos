using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockIncomingGJ_Product
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idproduct { get; set; }
        public int SubStorageTo { get; set; }
        public int? SubStorageResult { get; set; }
        public int Status { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }

        public virtual StockIncomingGJ StockIncomingGJ { get; set; }
        public virtual StockActualGJ StockActualGJ { get; set; }
        public virtual StockProductGJ StockProductGJ { get; set; }
    }
}
