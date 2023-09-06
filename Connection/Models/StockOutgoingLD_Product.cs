using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockOutgoingLD_Product
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idproduct { get; set; }
        public int SubStorage { get; set; }

        public virtual StockOutgoingLD StockOutgoingLD { get; set; }
        public virtual StockActualLD_Stone1B StockActualLD_Stone1B { get; set; }
        public virtual StockProductLD_Stone1B StockProductLD_Stone1B { get; set; }
    }
}
