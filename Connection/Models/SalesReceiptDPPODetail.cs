using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class SalesReceiptDPPODetail
    {
        public int Id { get; set; }
        public int IdsalesReceipt { get; set; }
        public int IdpaymentType { get; set; }
        public int? Idedc { get; set; }
        public int? IdbankIssuer { get; set; }
        public string Ccnumber { get; set; }
        public string Ccname { get; set; }
        public int? Idcard { get; set; }
        public int? Idprogram { get; set; }
        public decimal? Mdr { get; set; }
        public decimal? Nominal { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string OperatorNama { get; set; }
        public int? IdjenisKartuKredit { get; set; }

        public virtual BankIssuer BankIssuer { get; set; }
        public virtual CardType CardType { get; set; }
        public virtual EDCList EDCList { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual ProgramCicilan ProgramCicilan { get; set; }
        public virtual SalesReceiptDPPO SalesReceiptDPPO { get; set; }
        public virtual SalesReceiptDPPODetailExtension SalesReceiptDPPODetailExtension { get; set; }
    }
}
