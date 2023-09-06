using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class AdjustmentSouvenirProduct
    {
        public int Id { get; set; }
        public int? Idform { get; set; }
        public int? Idproduct { get; set; }
        public decimal? Qty { get; set; }

        public virtual AdjustmentSouvenir AdjustmentSouvenir { get; set; }
        public virtual Souvenir Souvenir { get; set; }
    }
}
