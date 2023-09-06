using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class KodeKaretGJ_CharProduct
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
        public decimal NettoWeight { get; set; }
        public decimal KadarLogam { get; set; }
        public decimal KadarTukaran { get; set; }
        public decimal DimensiD { get; set; }
        public decimal DimensiP { get; set; }
        public decimal DimensiL { get; set; }
        public decimal? DimensiR { get; set; }
        public string KodeKomponen1 { get; set; }
        public decimal? JlhKomponen1 { get; set; }
        public string KodeKomponen2 { get; set; }
        public decimal? JlhKomponen2 { get; set; }
        public string KodeKomponen3 { get; set; }
        public decimal? JlhKomponen3 { get; set; }
        public string KodeKomponen4 { get; set; }
        public decimal? JlhKomponen4 { get; set; }
        public string KodeKomponen5 { get; set; }
        public decimal? JlhKomponen5 { get; set; }
        public string KodeKomponen6 { get; set; }
        public decimal? JlhKomponen6 { get; set; }
        public decimal? Komponen { get; set; }
        public decimal? PoinKomponen { get; set; }
        public decimal? BebanSusut { get; set; }

        public virtual CharFrameColor CharFrameColor { get; set; }
        public virtual CharFrameFinishing CharFrameFinishing { get; set; }
        public virtual CharFrameMaterial CharFrameMaterial { get; set; }
        public virtual KodeKaretGJ KodeKaretGJ { get; set; }
        public virtual CharProcessCon CharProcessCon { get; set; }
        public virtual CharProductCategory CharProductCategory { get; set; }
        public virtual CharProductItem CharProductItem { get; set; }
        public virtual CharProductLevel CharProductLevel { get; set; }
        public virtual CharStoneDist CharStoneDist { get; set; }
    }
}
