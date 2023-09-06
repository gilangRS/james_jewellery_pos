using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockProductDJ_Finishing
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idfinishing { get; set; }
        public decimal? Biaya { get; set; }
        public DateTime? Efektif { get; set; }
        public decimal? BiayaModal { get; set; }

        public virtual CharProcessFinishing CharProcessFinishing { get; set; }
        public virtual StockProductDJ StockProductDJ { get; set; }
    }
}
