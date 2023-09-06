using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockActualCetakan
    {
        public int Id { get; set; }
        public int Idproduct { get; set; }
        public int TipeLokasi { get; set; }
        public string NamaLokasi { get; set; }
        public int? Idlokasi { get; set; }
        public int Substorage { get; set; }
        public string Keterangan { get; set; }
        public DateTime Tgl { get; set; }
        public string Nomor { get; set; }
        public decimal InHand { get; set; }
        public decimal? Damaged { get; set; }
        public decimal? NeverArrived { get; set; }
        public decimal? InTransit { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }

        public virtual Cetakan Cetakan { get; set; }
    }
}
