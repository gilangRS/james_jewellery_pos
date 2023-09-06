using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class ResellReceipt
    {
        public int Id { get; set; }
        public int Idresell { get; set; }
        public int IdpaymentType { get; set; }
        public int? Idcard { get; set; }
        public int? Idprogram { get; set; }
        public int? Idedc { get; set; }
        public int? IdbankIssuer { get; set; }
        public int? IdjenisKartuKredit { get; set; }
        public string Ccnumber { get; set; }
        public string Ccname { get; set; }
        public decimal? Nominal { get; set; }
        public string OperatorNama { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string CashBox { get; set; }
        public string Keterangan { get; set; }
    }
}
