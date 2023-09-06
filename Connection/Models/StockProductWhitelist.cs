using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockProductWhitelist
    {
        public int Id { get; set; }
        public string TipeProduct { get; set; }
        public string NomorPlu { get; set; }
        public int? Idproduct { get; set; }
        public string Keterangan { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }
    }
}
