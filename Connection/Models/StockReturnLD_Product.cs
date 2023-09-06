using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockReturnLD_Product
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idproduct { get; set; }
        public string Nomor { get; set; }

        public virtual StockReturnLD StockReturnLD { get; set; }
        public virtual StockProductLD_Stone1B StockProductLD_Stone1B { get; set; }
    }
}
