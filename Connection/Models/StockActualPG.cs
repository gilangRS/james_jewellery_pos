using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockActualPG
    {
        public StockActualPG()
        {
            StockIncomingPG_Products = new HashSet<StockIncomingPG_Product>();
            StockOutgoingPG_Products = new HashSet<StockOutgoingPG_Product>();
            CrossBrand_StockOutgoingPG_Products = new HashSet<CrossBrand_StockOutgoingPG_Product>();
            CrossBrand_StockIncomingPG_Products = new HashSet<CrossBrand_StockIncomingPG_Product>();
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
        public virtual StockProductPG StockProductPG { get; set; }
        public virtual ICollection<StockIncomingPG_Product> StockIncomingPG_Products { get; set; }
        public virtual ICollection<StockOutgoingPG_Product> StockOutgoingPG_Products { get; set; }
        public virtual ICollection<CrossBrand_StockIncomingPG_Product> CrossBrand_StockIncomingPG_Products { get; set; }
        public virtual ICollection<CrossBrand_StockOutgoingPG_Product> CrossBrand_StockOutgoingPG_Products { get; set; }
    }
}
