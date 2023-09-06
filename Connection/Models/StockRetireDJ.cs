using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockRetireDJ
    {
        public StockRetireDJ()
        {
            StockRetireDJ_Stone1As = new HashSet<StockRetireDJ_Stone1A>();
            StockRetireDJ_Stone1Bs = new HashSet<StockRetireDJ_Stone1B>();
            StockRetireDJ_Stone2s = new HashSet<StockRetireDJ_Stone2>();
            StockRetireDJ_Stone3s = new HashSet<StockRetireDJ_Stone3>();
            StockRetireDJ_Stone4s = new HashSet<StockRetireDJ_Stone4>();
            StockRetireDJ_Stone5s = new HashSet<StockRetireDJ_Stone5>();
        }

        public int Id { get; set; }
        public int Idproduct { get; set; }
        public string Nama { get; set; }
        public string Nomor { get; set; }
        public DateTime? Tgl { get; set; }
        public string Keterangan { get; set; }
        public string Alasan { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }
        public bool? Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public int? Status { get; set; }
        public decimal? NettoWeight { get; set; }
        public decimal? SusutBongkar { get; set; }
        public decimal? NettoSetelahBongkar { get; set; }
        public decimal? SusutLebur { get; set; }
        public decimal? BeratAkhir { get; set; }
        public decimal KadarTukaran { get; set; }
        public int? Reason { get; set; }

        public virtual StockProductDJ StockProductDJ { get; set; }
        public virtual ICollection<StockRetireDJ_Stone1A> StockRetireDJ_Stone1As { get; set; }
        public virtual ICollection<StockRetireDJ_Stone1B> StockRetireDJ_Stone1Bs { get; set; }
        public virtual ICollection<StockRetireDJ_Stone2> StockRetireDJ_Stone2s { get; set; }
        public virtual ICollection<StockRetireDJ_Stone3> StockRetireDJ_Stone3s { get; set; }
        public virtual ICollection<StockRetireDJ_Stone4> StockRetireDJ_Stone4s { get; set; }
        public virtual ICollection<StockRetireDJ_Stone5> StockRetireDJ_Stone5s { get; set; }
    }
}
