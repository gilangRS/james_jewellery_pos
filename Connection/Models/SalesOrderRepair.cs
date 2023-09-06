using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class SalesOrderRepair
    {
        public int Id { get; set; }
        public int? Idproduct { get; set; }
        public int? TipeLokasi { get; set; }
        public int? Idlokasi { get; set; }
        public int? Idcustomer { get; set; }
        public string CustomerNama { get; set; }
        public int? Idsales { get; set; }
        public string SalesNama { get; set; }
        public string Nomor { get; set; }
        public decimal? HargaRupiah { get; set; }
        public decimal? Paid { get; set; }
        public decimal? Unpaid { get; set; }
        public decimal? TotalBayarBeforeDisc { get; set; }
        public decimal? TotalRupiahBeforeDisc { get; set; }
        public decimal? Discount { get; set; }
        public decimal? DiscountNominal { get; set; }
        public decimal? DiscountProgram { get; set; }
        public decimal? DiscountProgramNominal { get; set; }
        public decimal? DiscountGift { get; set; }
        public decimal? DiscountRound { get; set; }
        public decimal? TotalBayar { get; set; }
        public decimal? TotalRupiah { get; set; }
        public bool? StatusPembayaran { get; set; }
        public DateTime? Tgl { get; set; }
        public bool Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public string Keterangan { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public int? Idrepair { get; set; }
        public int? IdproductTitipan { get; set; }

        public virtual DataCustomer DataCustomer { get; set; }
        public virtual StockProductDJ StockProductDJ { get; set; }
        public virtual DocRepairResult DocRepairResult { get; set; }
        public virtual DataSales DataSales { get; set; }
    }
}
