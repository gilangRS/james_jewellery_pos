using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class KodeKaretCleansing
    {
        public int Id { get; set; }
        public int ProductItem { get; set; }
        public int Sumber { get; set; }
        public int DocStatus { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }
        public string Reject { get; set; }
        public DateTime? RejectTgl { get; set; }
        public string RejectReason { get; set; }

        public virtual CharProductItem CharProductItem { get; set; }
    }
}
