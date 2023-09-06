using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockProductDJ_Stone2
    {
        public StockProductDJ_Stone2()
        {
            DocQCDJ_Stone2s = new HashSet<DocQCDJ_Stone2>();
            StockRetireDJ_Stone2s = new HashSet<StockRetireDJ_Stone2>();
        }

        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idstone { get; set; }
        public int TotalButir { get; set; }
        public decimal TotalCarat { get; set; }
        public decimal CaratButir { get; set; }
        public decimal DimensiP { get; set; }
        public decimal? DimensiL { get; set; }
        public decimal? DimensiT { get; set; }
        public decimal? HargaSatuan { get; set; }
        public decimal? HargaTotal { get; set; }
        public decimal? HargaSatuanM { get; set; }
        public decimal? HargaTotalM { get; set; }
        public DateTime? Efektif { get; set; }
        public decimal? Setting { get; set; }
        public string Gia { get; set; }

        public virtual StockProductDJ StockProductDJ { get; set; }
        public virtual ICollection<DocQCDJ_Stone2> DocQCDJ_Stone2s { get; set; }
        public virtual ICollection<StockRetireDJ_Stone2> StockRetireDJ_Stone2s { get; set; }
    }
}
