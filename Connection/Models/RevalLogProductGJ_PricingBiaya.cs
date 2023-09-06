using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class RevalLogProductGJ_PricingBiaya
    {
        public int Id { get; set; }
        public string NamaBrand { get; set; }
        public string NamaItem { get; set; }
        public string NamaCons { get; set; }
        public decimal Mounting { get; set; }
        public decimal MountingOld { get; set; }
        public decimal MountingNo { get; set; }
        public decimal MountingNoold { get; set; }
        public decimal MountingRo { get; set; }
        public decimal MountingRoold { get; set; }
        public decimal Setting { get; set; }
        public decimal SettingOld { get; set; }
        public decimal Finishing { get; set; }
        public decimal FinishingOld { get; set; }
        public decimal TotalRupiah { get; set; }
        public decimal TotalRupiahOld { get; set; }
        public decimal TotalRate { get; set; }
        public decimal TotalRateOld { get; set; }
        public decimal Total { get; set; }
        public decimal TotalOld { get; set; }
        public DateTime? EfektifRate { get; set; }
        public DateTime? EfektifRateOld { get; set; }
        public DateTime? EfektifMounting { get; set; }
        public DateTime? EfektifMountingOld { get; set; }
        public DateTime? EfektifSetting { get; set; }
        public DateTime? EfektifSettingOld { get; set; }

        public virtual RevalLogProductGJ RevalLogProductGJ { get; set; }
    }
}
