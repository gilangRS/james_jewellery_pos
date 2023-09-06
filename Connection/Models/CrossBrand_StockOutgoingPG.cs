using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class CrossBrand_StockOutgoingPG
    {
        public CrossBrand_StockOutgoingPG()
        {
            CrossBrand_StockIncomingPG = new HashSet<CrossBrand_StockIncomingPG>();
            CrossBrand_StockOutgoingPG_Products = new HashSet<CrossBrand_StockOutgoingPG_Product>();
        }

        public int Id { get; set; }
        public int IdbrandAsal { get; set; }
        public int IdbrandTujuan { get; set; }
        public string NamaKurir { get; set; }
        public DateTime TglEta { get; set; }
        public int TipeAsal { get; set; }
        public int TipeTujuan { get; set; }
        public string NamaAsal { get; set; }
        public string NamaTujuan { get; set; }
        public int Idasal { get; set; }
        public int Idtujuan { get; set; }
        public string Keterangan { get; set; }
        public DateTime Tgl { get; set; }
        public string Nomor { get; set; }
        public int StatusTransOut { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }

        public virtual CompanyBrand BrandAsal { get; set; }
        public virtual CompanyBrand BrandTujuan { get; set; }
        public virtual ICollection<CrossBrand_StockIncomingPG> CrossBrand_StockIncomingPG { get; set; }
        public virtual ICollection<CrossBrand_StockOutgoingPG_Product> CrossBrand_StockOutgoingPG_Products { get; set; }
    }
}
