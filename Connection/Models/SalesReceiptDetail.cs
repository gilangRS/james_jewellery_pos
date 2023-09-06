using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class SalesReceiptDetail
    {
        public int Id { get; set; }
        public int IdsalesReceipt { get; set; }
        public int IdpaymentType { get; set; }
        public int? Idcard { get; set; }
        public int? Idprogram { get; set; }
        public decimal? Mdr { get; set; }
        public int? Idedc { get; set; }
        public int? IdbankIssuer { get; set; }
        public string Ccnumber { get; set; }
        public string Ccname { get; set; }
        public decimal? Nominal { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string OperatorNama { get; set; }
        public int? IdjenisKartuKredit { get; set; }
        public int? VoidReference { get; set; }
        public int? EcrVerification { get; set; }
        public DateTime? EcrVerificationTgl { get; set; }
        public string EcrResponseValue { get; set; }
        public bool? GcVerification { get; set; }
        public DateTime? GcVerificationTgl { get; set; }
        public bool? GcVoidVerification { get; set; }
        public DateTime? GcVoidVerificationTgl { get; set; }

        public virtual BankIssuer BankIssuer { get; set; }
        public virtual CardType CardType { get; set; }
        public virtual EDCList EDCList { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual ProgramCicilan ProgramCicilan { get; set; }
        public virtual SalesReceipt SalesReceipt { get; set; }
        public virtual SalesReceiptDetailExtension SalesReceiptDetailExtension { get; set; }
    }
}
