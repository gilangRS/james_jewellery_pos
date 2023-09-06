using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class CrossBrand_StockOutgoingPG_Product
    {
        public int Idform { get; set; }
        public int Idproduct { get; set; }
        public string Nomor { get; set; }
        public int Substorage { get; set; }

        public virtual CrossBrand_StockOutgoingPG CrossBrand_StockOutgoingPG { get; set; }
        public virtual StockActualPG StockActualPG { get; set; }
        public virtual StockProductPG StockProductPG { get; set; }
    }
}
