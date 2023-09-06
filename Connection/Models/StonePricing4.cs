using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StonePricing4
    {
        public int Id { get; set; }
        public decimal? Modal { get; set; }
        public decimal? Harga { get; set; }
        public decimal? HargaPending { get; set; }
        public decimal? Mutasi { get; set; }
        public decimal? MutasiPersen { get; set; }
        public decimal? Selisih { get; set; }
        public decimal? SelisihPersen { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }
    }
}
