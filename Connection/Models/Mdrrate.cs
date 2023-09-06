using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class MDRRate
    {
        public int Id { get; set; }
        public int Idbank { get; set; }
        public int Idprogram { get; set; }
        public decimal Mdrrate1 { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }
        public int IdjenisKartuKredit { get; set; }
    }
}
