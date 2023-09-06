using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PricingLogFB
    {
        public int Id { get; set; }
        public int Idmaster { get; set; }
        public int QtyLama { get; set; }
        public int QtyBaru { get; set; }
        public decimal HargaCogslama { get; set; }
        public decimal HargaCogsbaru { get; set; }
        public decimal HargaJualLama { get; set; }
        public decimal HargaJualBaru { get; set; }
        public string Approval { get; set; }
        public DateTime ApprovalTgl { get; set; }
    }
}
