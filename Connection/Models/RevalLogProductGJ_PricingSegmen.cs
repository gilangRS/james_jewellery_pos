using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class RevalLogProductGJ_PricingSegmen
    {
        public int Id { get; set; }
        public int ProductSegmen { get; set; }
        public string NamaCategory { get; set; }
        public string NamaLevel { get; set; }
        public string NamaDist { get; set; }
        public int SegmenSistem { get; set; }
        public int SegmenSistemOld { get; set; }
        public decimal SegmenMinimum { get; set; }
        public decimal SegmenMinimumOld { get; set; }
        public decimal TotalCarat { get; set; }
        public decimal HargaUsd { get; set; }
        public decimal HargaUsdold { get; set; }
        public DateTime? EfektifSegmen { get; set; }
        public DateTime? EfektifSegmenOld { get; set; }

        public virtual RevalLogProductGJ RevalLogProductGJ { get; set; }
        public virtual CharProductSegmen CharProductSegmen { get; set; }
    }
}
