using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockIncomingLD
    {
        public StockIncomingLD()
        {
            StockIncomingLD_Products = new HashSet<StockIncomingLD_Product>();
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

        public virtual StockOutgoingLD StockOutgoingLD { get; set; }
        public virtual ICollection<StockIncomingLD_Product> StockIncomingLD_Products { get; set; }
    }
}
