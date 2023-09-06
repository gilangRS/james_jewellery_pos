﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DocRepair_Stone1A
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idstone { get; set; }
        public string Keterangan { get; set; }
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
        public decimal? HargaTotalRupiah { get; set; }

        public virtual DocRepair DocRepair { get; set; }
    }
}
