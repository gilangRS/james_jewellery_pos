using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PromoPG_Detail
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int? Idmodel { get; set; }
        public int? Idlevel { get; set; }
        public int? Iditem { get; set; }
        public int? Idproduct { get; set; }
        public int? TipeLokasi { get; set; }
        public int? Idlokasi { get; set; }

        public virtual PromoPG PromoPG { get; set; }
        public virtual CharProductItem CharProductItem { get; set; }
        public virtual CharGoldLevel CharGoldLevel { get; set; }
        public virtual CharGoldModel CharGoldModel { get; set; }
        public virtual StockProductPG StockProductPG { get; set; }
    }
}
