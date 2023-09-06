using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class RevalLogProductDJ_Costing
    {
        public int Id { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal? UnitPriceOld { get; set; }
        public decimal Frame { get; set; }
        public decimal FrameOld { get; set; }
        public decimal? MountingNo { get; set; }
        public decimal? MountingNoold { get; set; }
        public decimal MountingRo { get; set; }
        public decimal MountingRoold { get; set; }
        public decimal? Pembagi { get; set; }
        public decimal Setting { get; set; }
        public decimal SettingOld { get; set; }
        public decimal Finishing { get; set; }
        public decimal FinishingOld { get; set; }
        public decimal? OngkosLainCogs { get; set; }
        public decimal? OngkosLainCogsold { get; set; }
        public decimal? OngkosLain { get; set; }
        public decimal? OngkosLainOld { get; set; }
        public decimal? TotalRate { get; set; }
        public decimal? TotalRateOld { get; set; }
        public decimal? TotalRupiah { get; set; }
        public decimal? TotalRupiahOld { get; set; }
        public decimal TotalBiaya { get; set; }
        public decimal TotalBiayaOld { get; set; }

        public virtual RevalLogProductDJ RevalLogProductDJ { get; set; }
    }
}
