using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockReturnDJ_Product
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idproduct { get; set; }
        public string Nomor { get; set; }

        public virtual StockReturnDJ StockReturnDJ { get; set; }
    }
}
