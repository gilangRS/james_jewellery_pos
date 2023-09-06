using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockRetireGJ
    {
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
        public int? Reason { get; set; }

        public virtual StockProductGJ StockProductGJ { get; set; }
    }
}
