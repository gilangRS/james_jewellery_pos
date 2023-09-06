using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockReceiveGJ_CharProduct
    {
        public int Id { get; set; }
        public int ProductItem { get; set; }
        public int ProductCategory { get; set; }
        public int ProductLevel { get; set; }
        public int StoneDist { get; set; }
        public int FrameMaterial { get; set; }
        public int FrameFinishing { get; set; }
        public int FrameColor { get; set; }
        public int ProcessCons { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal StoneCarat { get; set; }
        public decimal StoneWeight { get; set; }
        public decimal? StoneQty { get; set; }
        public decimal NettoWeight { get; set; }
        public decimal KadarLogam { get; set; }
        public decimal KadarTukaran { get; set; }
        public decimal DimensiD { get; set; }
        public decimal DimensiP { get; set; }
        public decimal DimensiL { get; set; }
        public decimal? DimensiR { get; set; }

        public virtual CharFrameColor FrameColorNavigation { get; set; }
        public virtual CharFrameFinishing FrameFinishingNavigation { get; set; }
        public virtual CharFrameMaterial FrameMaterialNavigation { get; set; }
        public virtual StockReceiveGJ IdNavigation { get; set; }
        public virtual CharProcessCon ProcessConsNavigation { get; set; }
        public virtual CharProductCategory ProductCategoryNavigation { get; set; }
        public virtual CharProductItem ProductItemNavigation { get; set; }
        public virtual CharProductLevel ProductLevelNavigation { get; set; }
        public virtual CharStoneDist StoneDistNavigation { get; set; }
    }
}
