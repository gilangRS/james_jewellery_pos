using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StonePricingLog1B
    {
        public int Id { get; set; }
        public int Idmaster { get; set; }
        public DateTime Tgl { get; set; }
        public string Approval { get; set; }
        public decimal HargaLama { get; set; }
        public decimal HargaBaru { get; set; }
        public decimal? MarkUpLama { get; set; }
        public decimal? MarkUpBaru { get; set; }
    }
}
