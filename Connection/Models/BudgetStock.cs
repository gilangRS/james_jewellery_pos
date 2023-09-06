using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class BudgetStock
    {
        public int Id { get; set; }
        public int? ProductLevel { get; set; }
        public int? ProductCategory { get; set; }
        public int? ProductItem { get; set; }
        public int? Segmen { get; set; }
        public decimal? TargetQty { get; set; }
        public decimal? TargetRupiah { get; set; }
        public string OperatorNama { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string ApprovalNama { get; set; }
        public DateTime? ApprovalTgl { get; set; }

        public virtual CharProductCategory CharProductCategory { get; set; }
        public virtual CharProductItem CharProductItem { get; set; }
        public virtual CharProductLevel CharProductLevel { get; set; }
        public virtual CharProductSegmen CharProductSegmens { get; set; }
    }
}
