using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PromoGJ_Detail
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int? Idcategory { get; set; }
        public int? Idlevel { get; set; }
        public int? Iditem { get; set; }
        public int? Idproduct { get; set; }
        public int? TipeLokasi { get; set; }
        public int? Idlokasi { get; set; }

        public virtual CharProductCategory CharProductCategory { get; set; }
        public virtual PromoGJ PromoGJ { get; set; }
        public virtual CharProductItem CharProductItem { get; set; }
        public virtual CharProductLevel CharProductLevel { get; set; }
        public virtual StockProductGJ StockProductGJ { get; set; }
    }
}
