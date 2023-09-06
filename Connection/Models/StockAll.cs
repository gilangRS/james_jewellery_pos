using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockAll
    {
        public string Nomor { get; set; }
        public string SupplierNomor { get; set; }
        public int TipeLokasi { get; set; }
        public int Idlokasi { get; set; }
    }
}
