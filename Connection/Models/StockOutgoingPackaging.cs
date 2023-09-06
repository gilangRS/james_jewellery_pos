using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockOutgoingPackaging
    {
        public StockOutgoingPackaging()
        {
            StockIncomingPackagings = new HashSet<StockIncomingPackaging>();
            StockOutgoingPackaging_Products = new HashSet<StockOutgoingPackaging_Product>();
        }

        public int Id { get; set; }
        public int? Idbrand { get; set; }
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

        public virtual CompanyBrand CompanyBrand { get; set; }
        public virtual ICollection<StockIncomingPackaging> StockIncomingPackagings { get; set; }
        public virtual ICollection<StockOutgoingPackaging_Product> StockOutgoingPackaging_Products { get; set; }
    }
}
