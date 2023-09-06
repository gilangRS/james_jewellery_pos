using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DocRepairResult_CharProduct
    {
        public int Id { get; set; }
        public int ProductItem { get; set; }
        public int? ProductCategory { get; set; }
        public int? ProductLevel { get; set; }
        public int? StoneDist { get; set; }
        public int? FrameMaterial { get; set; }
        public int? FrameFinishing { get; set; }
        public int? FrameColor { get; set; }
        public int? ProcessCons { get; set; }
        public decimal? GrossWeightOld { get; set; }
        public decimal? GrossWeight { get; set; }
        public decimal? StoneCaratOld { get; set; }
        public decimal? StoneCarat { get; set; }
        public decimal? StoneWeightOld { get; set; }
        public decimal? StoneWeight { get; set; }
        public decimal? StoneQtyOld { get; set; }
        public decimal? StoneQty { get; set; }
        public decimal? NettoWeightOld { get; set; }
        public decimal? NettoWeight { get; set; }
        public decimal? KadarLogamOld { get; set; }
        public decimal? KadarLogam { get; set; }
        public decimal? KadarTukaran { get; set; }
        public decimal? DimensiDold { get; set; }
        public decimal? DimensiD { get; set; }
        public decimal? DimensiPold { get; set; }
        public decimal? DimensiP { get; set; }
        public decimal? DimensiLold { get; set; }
        public decimal? DimensiL { get; set; }
        public decimal? DimensiRold { get; set; }
        public decimal? DimensiR { get; set; }
        public decimal? SelisihBerat { get; set; }
        public decimal? HargaEmas { get; set; }
        public decimal? Rate { get; set; }

        public virtual CharFrameColor CharFrameColor { get; set; }
        public virtual CharFrameFinishing CharFrameFinishing { get; set; }
        public virtual CharFrameMaterial CharFrameMaterial { get; set; }
        public virtual DocRepairResult DocRepairResult { get; set; }
        public virtual CharProcessCon CharProcessCon { get; set; }
        public virtual CharProductCategory CharProductCategory { get; set; }
        public virtual CharProductItem CharProductItem { get; set; }
        public virtual CharProductLevel CharProductLevel { get; set; }
        public virtual CharStoneDist CharStoneDist { get; set; }
    }
}
