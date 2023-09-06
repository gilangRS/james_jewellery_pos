using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class CrossBrand_StockOutgoingLD
    {
        public CrossBrand_StockOutgoingLD()
        {
            CrossBrand_StockIncomingLD = new HashSet<CrossBrand_StockIncomingLD>();
            CrossBrand_StockOutgoingLD_Products = new HashSet<CrossBrand_StockOutgoingLD_Product>();
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
        public virtual ICollection<CrossBrand_StockIncomingLD> CrossBrand_StockIncomingLD { get; set; }
        public virtual ICollection<CrossBrand_StockOutgoingLD_Product> CrossBrand_StockOutgoingLD_Products { get; set; }
    }
}
