using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class EDCList
    {
        public EDCList()
        {
            SalesReceiptDetails = new HashSet<SalesReceiptDetail>();
            SalesReceiptDPPODetails = new HashSet<SalesReceiptDPPODetail>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string Keterangan { get; set; }

        public virtual ICollection<SalesReceiptDetail> SalesReceiptDetails { get; set; }
        public virtual ICollection<SalesReceiptDPPODetail> SalesReceiptDPPODetails { get; set; }
    }
}
