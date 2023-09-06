using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StonePricing1B
    {
        public int Id { get; set; }
        public decimal? Modal { get; set; }
        public decimal? ModalH { get; set; }
        public decimal? ModalP { get; set; }
        public decimal? Harga { get; set; }
        public decimal? HargaPending { get; set; }
        public decimal? Mutasi { get; set; }
        public decimal? MutasiPersen { get; set; }
        public decimal? Selisih { get; set; }
        public decimal? SelisihPersen { get; set; }
        public decimal? InputH { get; set; }
        public decimal? InputP { get; set; }
        public decimal? PendingH { get; set; }
        public decimal? PendingP { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }
        public decimal? MarkUp { get; set; }
        public decimal? MarkUpPending { get; set; }
    }
}
