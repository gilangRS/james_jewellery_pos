using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockIncomingPackaging
    {
        public StockIncomingPackaging()
        {
            StockIncomingPackaging_Products = new HashSet<StockIncomingPackaging_Product>();
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

        public virtual StockOutgoingPackaging StockOutgoingPackaging { get; set; }
        public virtual ICollection<StockIncomingPackaging_Product> StockIncomingPackaging_Products { get; set; }
    }
}
