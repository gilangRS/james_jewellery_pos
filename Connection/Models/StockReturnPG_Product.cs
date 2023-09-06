using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockReturnPG_Product
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idproduct { get; set; }
        public string Nomor { get; set; }

        public virtual StockReturnPG StockReturnPG { get; set; }
        public virtual StockProductPG StockProductPG { get; set; }
    }
}
