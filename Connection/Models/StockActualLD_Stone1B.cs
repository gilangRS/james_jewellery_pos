using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockActualLD_Stone1B
    {
        public StockActualLD_Stone1B()
        {
            StockIncomingLD_Products = new HashSet<StockIncomingLD_Product>();
            StockOutgoingLD_Products = new HashSet<StockOutgoingLD_Product>();
            CrossBrand_StockIncomingLD_Products = new HashSet<CrossBrand_StockIncomingLD_Product>();
            CrossBrand_StockOutgoingLD_Products = new HashSet<CrossBrand_StockOutgoingLD_Product>();
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
        public virtual StockProductLD_Stone1B StockProductLD_Stone1B { get; set; }
        public virtual ICollection<StockIncomingLD_Product> StockIncomingLD_Products { get; set; }
        public virtual ICollection<StockOutgoingLD_Product> StockOutgoingLD_Products { get; set; }
        public virtual ICollection<CrossBrand_StockIncomingLD_Product> CrossBrand_StockIncomingLD_Products { get; set; }
        public virtual ICollection<CrossBrand_StockOutgoingLD_Product> CrossBrand_StockOutgoingLD_Products { get; set; }
    }
}
