using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class CrossBrand_StockOutgoingDJ_Product
    {
        public int Idform { get; set; }
        public int Idproduct { get; set; }
        public string Nomor { get; set; }
        public int Substorage { get; set; }

        public virtual CrossBrand_StockOutgoingDJ CrossBrand_StockOutgoingDJ { get; set; }
        public virtual StockActualDJ StockActualDJ { get; set; }
        public virtual StockProductDJ StockProductDJ { get; set; }
    }
}
