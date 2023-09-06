using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PricingTableRO
    {
        public int Id { get; set; }
        public int ProductItem { get; set; }
        public int StoneDist { get; set; }
        public string KelasHarga { get; set; }
        public decimal MinValue { get; set; }
        public decimal OngkosRo { get; set; }
        public bool Disable { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }
    }
}
