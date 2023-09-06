using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockOutgoingGJ_Product
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idproduct { get; set; }
        public int SubStorage { get; set; }

        public virtual StockOutgoingGJ StockOutgoingGJ { get; set; }
        public virtual StockActualGJ StockActualGJ { get; set; }
        public virtual StockProductGJ StockProductGJ { get; set; }
    }
}
