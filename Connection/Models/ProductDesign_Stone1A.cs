﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class ProductDesign_Stone1A
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
        public decimal? HargaSatuan { get; set; }
        public decimal? HargaTotal { get; set; }
        public DateTime? Efektif { get; set; }
        public decimal? Setting { get; set; }

        public virtual ProductDesign IdformNavigation { get; set; }
    }
}
