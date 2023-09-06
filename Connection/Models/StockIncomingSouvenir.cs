using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockIncomingSouvenir
    {
        public StockIncomingSouvenir()
        {
            StockIncomingSouvenir_Products = new HashSet<StockIncomingSouvenir_Product>();
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

        public virtual StockOutgoingSouvenir StockOutgoingSouvenir { get; set; }
        public virtual ICollection<StockIncomingSouvenir_Product> StockIncomingSouvenir_Products { get; set; }
    }
}
