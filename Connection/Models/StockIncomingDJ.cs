using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockIncomingDJ
    {
        public StockIncomingDJ()
        {
            StockIncomingDJ_Products = new HashSet<StockIncomingDJ_Product>();
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

        public virtual StockOutgoingDJ StockOutgoingDJ { get; set; }
        public virtual ICollection<StockIncomingDJ_Product> StockIncomingDJ_Products { get; set; }
    }
}
