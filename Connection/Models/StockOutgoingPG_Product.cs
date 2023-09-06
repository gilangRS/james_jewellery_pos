using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockOutgoingPG_Product
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idproduct { get; set; }
        public int SubStorage { get; set; }

        public virtual StockOutgoingPG StockOutgoingPG { get; set; }
        public virtual StockActualPG StockActualPG { get; set; }
        public virtual StockProductPG StockProductPG { get; set; }
    }
}
