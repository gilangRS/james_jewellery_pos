﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class RevalLogProductDJ_Stone4
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
        public decimal? HargaSatuanOld { get; set; }
        public decimal? HargaTotal { get; set; }
        public decimal? HargaTotalOld { get; set; }
        public decimal? HargaSatuanM { get; set; }
        public decimal? HargaSatuanMold { get; set; }
        public decimal? HargaTotalM { get; set; }
        public decimal? HargaTotalMold { get; set; }
        public DateTime? Efektif { get; set; }
        public DateTime? EfektifOld { get; set; }
        public decimal? Setting { get; set; }
        public decimal? SettingOld { get; set; }

        public virtual RevalLogProductDJ RevalLogProductDJ { get; set; }
    }
}
