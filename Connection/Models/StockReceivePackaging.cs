using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockReceivePackaging
    {
        public StockReceivePackaging()
        {
            StockReceivePackaging_Products = new HashSet<StockReceivePackaging_Product>();
        }

        public int Id { get; set; }
        public int? Idwarehouse { get; set; }
        public string NoPo { get; set; }
        public string NoDo { get; set; }
        public DateTime? Tgl { get; set; }
        public DateTime TglInput { get; set; }
        public bool Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }
        public string Keterangan { get; set; }
        public bool? StatusReceive { get; set; }

        public virtual LocWarehouse LocWarehouse { get; set; }
        public virtual ICollection<StockReceivePackaging_Product> StockReceivePackaging_Products { get; set; }
    }
}
