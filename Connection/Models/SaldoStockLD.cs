using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class SaldoStockLD
    {
        public int Id { get; set; }
        public int Idproduct { get; set; }
        public int TipeLokasi { get; set; }
        public int Idlokasi { get; set; }
        public decimal InHand { get; set; }
        public int SubStorage { get; set; }
        public int Bulan { get; set; }
        public int Tahun { get; set; }
        public string Keterangan { get; set; }
        public decimal? HargaJual { get; set; }
        public decimal? HargaM { get; set; }
        public decimal? Carat { get; set; }

        public virtual StockProductLD_Stone1B StockProductLD_Stone1B { get; set; }
    }
}
