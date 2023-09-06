using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class ProductDesign_Stone1B
    {
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
        public decimal? HargaInputP { get; set; }
        public DateTime? Efektif { get; set; }
        public decimal? Setting { get; set; }
        public int? StatusTerpasang { get; set; }

        public virtual ProductDesign ProductDesign { get; set; }
    }
}
