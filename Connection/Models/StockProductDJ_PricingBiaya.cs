using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockProductDJ_PricingBiaya
    {
        public int Id { get; set; }
        public string NamaBrand { get; set; }
        public string NamaItem { get; set; }
        public string NamaCons { get; set; }
        public decimal Mounting { get; set; }
        public decimal MountingNo { get; set; }
        public decimal MountingRo { get; set; }
        public decimal Setting { get; set; }
        public decimal Finishing { get; set; }
        public decimal TotalRupiah { get; set; }
        public decimal TotalRate { get; set; }
        public decimal Total { get; set; }
        public DateTime EfektifRate { get; set; }
        public DateTime EfektifMounting { get; set; }
        public DateTime EfektifSetting { get; set; }

        public virtual StockProductDJ StockProductDJ { get; set; }
    }
}
