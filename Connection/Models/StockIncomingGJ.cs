using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockIncomingGJ
    {
        public StockIncomingGJ()
        {
            StockIncomingGJ_Products = new HashSet<StockIncomingGJ_Product>();
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

        public virtual StockOutgoingGJ StockOutgoingGJ { get; set; }
        public virtual ICollection<StockIncomingGJ_Product> StockIncomingGJ_Products { get; set; }
    }
}
