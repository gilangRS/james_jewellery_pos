using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class CrossBrand_StockIncomingPG
    {
        public CrossBrand_StockIncomingPG()
        {
            CrossBrand_StockIncomingPG_Products = new HashSet<CrossBrand_StockIncomingPG_Product>();
        }
        public int Id { get; set; }
        public int Idoutgoing { get; set; }
        public string Nomor { get; set; }
        public DateTime? Tgl { get; set; }
        public string Keterangan { get; set; }
        public int StatusTransIn { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }

        public virtual CrossBrand_StockOutgoingPG CrossBrand_StockOutgoingPG { get; set; }

        public virtual ICollection<CrossBrand_StockIncomingPG_Product> CrossBrand_StockIncomingPG_Products { get; set; }
    }
}
