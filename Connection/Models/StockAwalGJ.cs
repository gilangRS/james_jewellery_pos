using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockAwalGJ
    {
        public int Id { get; set; }
        public int Idbrand { get; set; }
        public int LocationType { get; set; }
        public int Idlocation { get; set; }
        public int ProductItem { get; set; }
        public int ProductCategory { get; set; }
        public int ProductLevel { get; set; }
        public int StoneDist { get; set; }
        public string Nomor { get; set; }
        public int Qty { get; set; }
        public decimal HargaM { get; set; }
        public DateTime Periode { get; set; }
    }
}
