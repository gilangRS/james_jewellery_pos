using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class SalesReceiptDPPODetailExtension
    {
        public int Id { get; set; }
        public string PaymentName { get; set; }
        public string TransactionNumber { get; set; }
        public int VerificationFlag { get; set; }
        public DateTime VerificationDateTime { get; set; }
        public string VerificationOperator { get; set; }
        public int? VoidFlag { get; set; }
        public DateTime? VoidDateTime { get; set; }
        public string VoidOperator { get; set; }

        public virtual SalesReceiptDPPODetail SalesReceiptDPPODetail { get; set; }
    }
}
