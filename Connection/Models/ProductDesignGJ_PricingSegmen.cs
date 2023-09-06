using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class ProductDesignGJ_PricingSegmen
    {
        public int Id { get; set; }
        public int ProductSegmen { get; set; }
        public string NamaCategory { get; set; }
        public string NamaLevel { get; set; }
        public string NamaDist { get; set; }
        public int SegmenSistem { get; set; }
        public decimal SegmenMinimum { get; set; }
        public decimal TotalCarat { get; set; }
        public decimal HargaUsd { get; set; }
        public DateTime EfektifSegmen { get; set; }

        public virtual ProductDesignGJ ProductDesignGJ { get; set; }
        public virtual CharProductSegmen CharProductSegmen { get; set; }
    }
}
