using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class SalesOrder
    {
        public SalesOrder()
        {
            ResellDJs = new HashSet<ResellDJ>();
            ResellGJs = new HashSet<ResellGJ>();
            ResellLDs = new HashSet<ResellLD>();
            ResellPGs = new HashSet<ResellPG>();
            SalesOrderDJs = new HashSet<SalesOrderDJ>();
            SalesOrderGJs = new HashSet<SalesOrderGJ>();
            SalesOrderLDs = new HashSet<SalesOrderLD>();
            SalesOrderPackagings = new HashSet<SalesOrderPackaging>();
            SalesOrderCetakans = new HashSet<SalesOrderCetakan>();
            SalesOrderPGs = new HashSet<SalesOrderPG>();
            SalesOrderSouvenirs = new HashSet<SalesOrderSouvenir>();
            SalesReceiptDPPOs = new HashSet<SalesReceiptDPPO>();
            SalesReceipts = new HashSet<SalesReceipt>();
            SalesVouchers = new HashSet<SalesVoucher>();
            TradeIns = new HashSet<TradeIn>();
        }

        public int Id { get; set; }
        public int? TipeLokasi { get; set; }
        public int? Idlokasi { get; set; }
        public int? Idcustomer { get; set; }
        public string CustomerNama { get; set; }
        public int? Idsales { get; set; }
        public string SalesNama { get; set; }
        public int? Idsales2 { get; set; }
        public string SalesNama2 { get; set; }
        public string Nomor { get; set; }
        public decimal? ModalRupiah { get; set; }
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
        public decimal? TotalResell { get; set; }
        public bool? StatusVoid { get; set; }
        public bool? StatusPembayaran { get; set; }
        public DateTime? Tgl { get; set; }
        public bool Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public string Keterangan { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public bool? TradeIn { get; set; }
        public DateTime? TglLunas { get; set; }
        public string KeteranganVoid { get; set; }
        public DateTime? TglVoid { get; set; }
        public int? IdcustomerReference { get; set; }
        public string CustomerReferenceNama { get; set; }
        public string EReceiptHp { get; set; }
        public string EReceiptEmail { get; set; }
        public string KodeCustomerLama { get; set; }
        public int? PoinReceived { get; set; }
        public int? IdtransactionStamps { get; set; }
        public bool? Npwp { get; set; }
        public string LinkPackagingSalesOrder { get; set; }
        public string KodeBrandCross { get; set; }
        public int? TipeLokasiCross { get; set; }
        public int? IdlokasiCross { get; set; }
        public int? IdsalesCross { get; set; }
        public string NamaSalesCross { get; set; }
        public string NiksalesCross { get; set; }
        public string LinkPackagingDownPayment { get; set; }
        public string LinkPackagingRepair { get; set; }
        public DateTime? LastPrintedDate { get; set; }
        public string LastPrintedBy { get; set; }
        public string Membership { get; set; }
        public int? Idpromo { get; set; }
        public string UrlFile { get; set; }

        public virtual DataCustomer DataCustomer { get; set; }
        public virtual DataCustomer DataCustomer_Reference { get; set; }
        public virtual DataSales DataSales { get; set; }
        public virtual ICollection<ResellDJ> ResellDJs { get; set; }
        public virtual ICollection<ResellGJ> ResellGJs { get; set; }
        public virtual ICollection<ResellLD> ResellLDs { get; set; }
        public virtual ICollection<ResellPG> ResellPGs { get; set; }
        public virtual ICollection<SalesOrderDJ> SalesOrderDJs { get; set; }
        public virtual ICollection<SalesOrderGJ> SalesOrderGJs { get; set; }
        public virtual ICollection<SalesOrderLD> SalesOrderLDs { get; set; }
        public virtual ICollection<SalesOrderPackaging> SalesOrderPackagings { get; set; }
        public virtual ICollection<SalesOrderCetakan> SalesOrderCetakans { get; set; }
        public virtual ICollection<SalesOrderPG> SalesOrderPGs { get; set; }
        public virtual ICollection<SalesOrderSouvenir> SalesOrderSouvenirs { get; set; }
        public virtual ICollection<SalesReceiptDPPO> SalesReceiptDPPOs { get; set; }
        public virtual ICollection<SalesReceipt> SalesReceipts { get; set; }
        public virtual ICollection<SalesVoucher> SalesVouchers { get; set; }
        public virtual ICollection<TradeIn> TradeIns { get; set; }
    }
}
