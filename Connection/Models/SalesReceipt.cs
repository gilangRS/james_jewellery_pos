using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class SalesReceipt
    {
        public SalesReceipt()
        {
            SalesReceiptDetails = new HashSet<SalesReceiptDetail>();
        }

        public int Id { get; set; }
        public int? IdsalesOrder { get; set; }
        public string NoSalesOrder { get; set; }
        public string NomorDp { get; set; }
        public string NomorInvoice { get; set; }
        public decimal? TotalBayar { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string OperatorNama { get; set; }
        public int? Idrepair { get; set; }
        public DateTime? Tgl { get; set; }

        public virtual DocRepairResult DocRepairResult { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
        public virtual ICollection<SalesReceiptDetail> SalesReceiptDetails { get; set; }
    }
}
