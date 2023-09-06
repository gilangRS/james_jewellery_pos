using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockProductDJ_Stone1A
    {
        public StockProductDJ_Stone1A()
        {
            DocQCDJ_Stone1As = new HashSet<DocQCDJ_Stone1A>();
            StockRetireDJ_Stone1As = new HashSet<StockRetireDJ_Stone1A>();
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
        public string CertificateNumber { get; set; }

        public virtual StockProductDJ StockProductDJ { get; set; }
        public virtual ICollection<DocQCDJ_Stone1A> DocQCDJ_Stone1As { get; set; }
        public virtual ICollection<StockRetireDJ_Stone1A> StockRetireDJ_Stone1As { get; set; }
    }
}
