using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PricingTableFB
    {
        public int Id { get; set; }
        public int TipeLokasi { get; set; }
        public int? Idlokasi { get; set; }
        public int Qty { get; set; }
        public decimal HargaCogs { get; set; }
        public decimal HargaJual { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }
    }
}
