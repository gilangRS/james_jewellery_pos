using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockOutgoingSouvenir_Product
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idproduct { get; set; }
        public int? SubStorage { get; set; }
        public decimal? Qty { get; set; }

        public virtual StockOutgoingSouvenir StockOutgoingSouvenir { get; set; }
        public virtual Souvenir Souvenir { get; set; }
    }
}
