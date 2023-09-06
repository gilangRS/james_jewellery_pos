using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class SalesFee
    {
        public int Id { get; set; }
        public int Tahun { get; set; }
        public int Bulan { get; set; }
        public decimal? TotalPoint { get; set; }
        public decimal? FullMoney { get; set; }
        public decimal? Ae { get; set; }
        public decimal? Dj { get; set; }
        public decimal? Pg { get; set; }
        public decimal? Lm { get; set; }
        public decimal? Pc1 { get; set; }
        public decimal? Pc2 { get; set; }
        public decimal? Pc3 { get; set; }
        public decimal? Pc4 { get; set; }
        public decimal? Inc1 { get; set; }
        public decimal? Inc2 { get; set; }
        public decimal? Inc3 { get; set; }
        public decimal? Inc4 { get; set; }
        public decimal? Kom1 { get; set; }
        public decimal? Kom2 { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string OperatorNama { get; set; }
        public DateTime? ApprovalTgl { get; set; }
        public string ApprovalNama { get; set; }
    }
}
