using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockRetireDJ_Stone5
    {
        public int Id { get; set; }
        public int Idstone { get; set; }
        public int Idform { get; set; }
        public int TotalButir { get; set; }
        public int TotalTerima { get; set; }
        public int TotalRusak { get; set; }
        public int TotalSelisih { get; set; }
        public decimal CaratTerima { get; set; }
        public decimal CaratSelisih { get; set; }
        public decimal CaratButir { get; set; }
        public decimal CaratRusak { get; set; }
        public string Keterangan { get; set; }

        public virtual StockRetireDJ StockRetireDJ { get; set; }
        public virtual StockProductDJ_Stone5 StockProductDJ_Stone5 { get; set; }
    }
}
