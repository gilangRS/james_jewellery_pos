using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockActualGJ
    {
        public StockActualGJ()
        {
            StockIncomingGJ_Products = new HashSet<StockIncomingGJ_Product>();
            StockOutgoingGJ_Products = new HashSet<StockOutgoingGJ_Product>();
        }

        public int Idproduct { get; set; }
        public int Idbrand { get; set; }
        public int TipeLokasi { get; set; }
        public string NamaLokasi { get; set; }
        public int Idlokasi { get; set; }
        public int Substorage { get; set; }
        public string Keterangan { get; set; }
        public DateTime Tgl { get; set; }
        public string Nomor { get; set; }
        public decimal InHand { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }
        public bool Legacy { get; set; }
        public int? LegacyTipe { get; set; }
        public string LegacyPost { get; set; }
        public DateTime? LegacyPostTgl { get; set; }

        public virtual CompanyBrand CompanyBrand { get; set; }
        public virtual StockProductGJ StockProductGJ { get; set; }
        public virtual ICollection<StockIncomingGJ_Product> StockIncomingGJ_Products { get; set; }
        public virtual ICollection<StockOutgoingGJ_Product> StockOutgoingGJ_Products { get; set; }
    }
}
