using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockLedgerLd
    {
        public int Id { get; set; }
        public int Idproduct { get; set; }
        public int TipeLokasi { get; set; }
        public int Idlokasi { get; set; }
        public string NamaLokasi { get; set; }
        public decimal Value { get; set; }
        public int Remark { get; set; }
        public string Keterangan { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }
    }
}
