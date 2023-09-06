using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class RevalLogProductGJ_PricingMU
    {
        public int Id { get; set; }
        public string NamaCategory { get; set; }
        public string NamaLevel { get; set; }
        public string NamaDist { get; set; }
        public decimal ModalUsd { get; set; }
        public decimal ModalUsdold { get; set; }
        public decimal ModalRate { get; set; }
        public decimal ModalRateOld { get; set; }
        public decimal ModalRupiah { get; set; }
        public decimal ModalRupiahOld { get; set; }
        public decimal Mu { get; set; }
        public decimal Muold { get; set; }
        public decimal HargaUsd { get; set; }
        public decimal HargaUsdold { get; set; }
        public decimal HargaRupiah { get; set; }
        public decimal HargaRupiahOld { get; set; }
        public decimal? HargaRupiahRound { get; set; }
        public decimal? HargaRupiahRoundOld { get; set; }
        public DateTime? EfektifRate { get; set; }
        public DateTime? EfektifRateOld { get; set; }

        public virtual RevalLogProductGJ RevalLogProductGJ { get; set; }
    }
}
