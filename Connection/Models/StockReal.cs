using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockReal
    {
        public string Nomor { get; set; }
        public string Tipe { get; set; }
        public int TipeLokasi { get; set; }
        public int Idlokasi { get; set; }
        public decimal InHand { get; set; }
    }
}
