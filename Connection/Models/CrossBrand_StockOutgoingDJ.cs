using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class CrossBrand_StockOutgoingDJ
    {
        public CrossBrand_StockOutgoingDJ()
        {
            CrossBrand_StockIncomingDJ = new HashSet<CrossBrand_StockIncomingDJ>();
            CrossBrand_StockOutgoingDJ_Products = new HashSet<CrossBrand_StockOutgoingDJ_Product>();
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
        public virtual ICollection<CrossBrand_StockIncomingDJ> CrossBrand_StockIncomingDJ { get; set; }
        public virtual ICollection<CrossBrand_StockOutgoingDJ_Product> CrossBrand_StockOutgoingDJ_Products { get; set; }
    }
}
