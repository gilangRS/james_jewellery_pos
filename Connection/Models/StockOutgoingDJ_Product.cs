using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockOutgoingDJ_Product
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idproduct { get; set; }
        public int SubStorage { get; set; }

        public virtual StockOutgoingDJ StockOutgoingDJ { get; set; }
        public virtual StockActualDJ StockActualDJ { get; set; }
        public virtual StockProductDJ StockProductDJ { get; set; }
    }
}
