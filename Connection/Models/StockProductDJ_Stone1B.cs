using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockProductDJ_Stone1B
    {
        public StockProductDJ_Stone1B()
        {
            DocQCDJ_Stone1Bs = new HashSet<DocQCDJ_Stone1B>();
            StockRetireDJ_Stone1Bs = new HashSet<StockRetireDJ_Stone1B>();
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
        public string Gia { get; set; }
        public decimal? HargaSatuan { get; set; }
        public decimal? HargaTotal { get; set; }
        public decimal? HargaInputH { get; set; }
        public decimal? HargaSatuanM { get; set; }
        public decimal? HargaTotalM { get; set; }
        public decimal? HargaInputP { get; set; }
        public DateTime? Efektif { get; set; }
        public decimal? Setting { get; set; }
        public int? StatusTerpasang { get; set; }
        public DateTime? Giaexpired { get; set; }
        public decimal? HargaMjual { get; set; }
        public decimal? DiscMjual { get; set; }
        public decimal? HargaRjual { get; set; }
        public decimal? DiscRjual { get; set; }
        public decimal? HargaMinputH { get; set; }
        public decimal? HargaMinputP { get; set; }

        public virtual StockProductDJ StockProductDJ { get; set; }
        public virtual ICollection<DocQCDJ_Stone1B> DocQCDJ_Stone1Bs { get; set; }
        public virtual ICollection<StockRetireDJ_Stone1B> StockRetireDJ_Stone1Bs { get; set; }
    }
}
