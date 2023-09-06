using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class SalesOrderPG
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idproduct { get; set; }
        public string Invoice { get; set; }
        public decimal? ModalRupiah { get; set; }
        public decimal? ModalTgp { get; set; }
        public decimal? HargaRupiah { get; set; }
        public decimal? Discount { get; set; }
        public decimal? DiscountNominal { get; set; }
        public decimal? DiscountProgram { get; set; }
        public decimal? DiscountProgramNominal { get; set; }
        public decimal? DiscountGift { get; set; }
        public decimal? DiscountRound { get; set; }
        public decimal? DiscountPromo { get; set; }
        public decimal? TotalRupiah { get; set; }
        public decimal? TotalBayar { get; set; }
        public int? StatusResell { get; set; }
        public int? MeperiodeMin { get; set; }
        public int? MeperiodeMax { get; set; }
        public decimal? Merumus { get; set; }
        public int? Ti1PeriodeMin { get; set; }
        public decimal? Ti1Rumus { get; set; }
        public int? Ti2PeriodeMin { get; set; }
        public decimal? Ti2Rumus { get; set; }
        public int? RPeriodeMin { get; set; }
        public decimal? RRumus { get; set; }
        public decimal? TotalDp { get; set; }
        public decimal DiscountBank { get; set; }
        public decimal DiscountOther { get; set; }
        public decimal? BeratTimbang { get; set; }
        public decimal? Tgpjual { get; set; }
        public int? PoinReceived { get; set; }
        public decimal? PoinPembagi { get; set; }

        public virtual SalesOrder SalesOrder { get; set; }
        public virtual StockProductPG StockProductPG { get; set; }
    }
}
