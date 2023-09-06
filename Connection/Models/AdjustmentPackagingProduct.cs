using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class AdjustmentPackagingProduct
    {
        public int Id { get; set; }
        public int? Idform { get; set; }
        public int? Idproduct { get; set; }
        public decimal? Qty { get; set; }

        public virtual AdjustmentPackaging AdjustmentPackaging { get; set; }
        public virtual Packaging Packaging { get; set; }
    }
}
