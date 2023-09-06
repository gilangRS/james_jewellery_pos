using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockProductDJ_Costing
    {
        public int Id { get; set; }
        public decimal? UnitPrice { get; set; }
        public decimal Frame { get; set; }
        public decimal? MountingNo { get; set; }
        public decimal MountingRo { get; set; }
        public decimal? Pembagi { get; set; }
        public decimal Setting { get; set; }
        public decimal Finishing { get; set; }
        public decimal? OngkosLainCogs { get; set; }
        public decimal? OngkosLain { get; set; }
        public decimal? TotalRate { get; set; }
        public decimal? TotalRupiah { get; set; }
        public decimal TotalBiaya { get; set; }

        public virtual StockProductDJ StockProductDJ { get; set; }
    }
}
