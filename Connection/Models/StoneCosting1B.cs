using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StoneCosting1B
    {
        public int Id { get; set; }
        public decimal? Harga { get; set; }
        public decimal? HargaPending { get; set; }
        public decimal? Mutasi { get; set; }
        public decimal? MutasiPersen { get; set; }
        public decimal? InputH { get; set; }
        public decimal? InputP { get; set; }
        public decimal? PendingH { get; set; }
        public decimal? PendingP { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }
    }
}
