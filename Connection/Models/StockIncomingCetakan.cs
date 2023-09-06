using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockIncomingCetakan
    {
        public StockIncomingCetakan()
        {
            StockIncomingCetakan_Products = new HashSet<StockIncomingCetakan_Product>();
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

        public virtual StockOutgoingCetakan StockOutgoingCetakan { get; set; }
        public virtual ICollection<StockIncomingCetakan_Product> StockIncomingCetakan_Products { get; set; }
    }
}
