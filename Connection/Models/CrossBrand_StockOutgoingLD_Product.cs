using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class CrossBrand_StockOutgoingLD_Product
    {
        public int Idform { get; set; }
        public int Idproduct { get; set; }
        public string Nomor { get; set; }
        public int Substorage { get; set; }

        public virtual CrossBrand_StockOutgoingLD CrossBrand_StockOutgoingLD { get; set; }
        public virtual StockActualLD_Stone1B StockActualLD_Stone1B { get; set; }
        public virtual StockProductLD_Stone1B StockProductLD_Stone1B { get; set; }
    }
}
