using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockActualDJ
    {
        public StockActualDJ()
        {
            StockIncomingDJ_Products = new HashSet<StockIncomingDJ_Product>();
            StockOutgoingDJ_Products = new HashSet<StockOutgoingDJ_Product>();
            CrossBrand_StockIncomingDJ_Products = new HashSet<CrossBrand_StockIncomingDJ_Product>();
            CrossBrand_StockOutgoingDJ_Products = new HashSet<CrossBrand_StockOutgoingDJ_Product>();
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
        public virtual StockProductDJ StockProductDJ { get; set; }
        public virtual ICollection<StockIncomingDJ_Product> StockIncomingDJ_Products { get; set; }
        public virtual ICollection<StockOutgoingDJ_Product> StockOutgoingDJ_Products { get; set; }
        public virtual ICollection<CrossBrand_StockIncomingDJ_Product> CrossBrand_StockIncomingDJ_Products { get; set; }
        public virtual ICollection<CrossBrand_StockOutgoingDJ_Product> CrossBrand_StockOutgoingDJ_Products { get; set; }

    }
}
