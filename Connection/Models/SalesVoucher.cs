using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class SalesVoucher
    {
        public int Id { get; set; }
        public int IdsalesOrder { get; set; }
        public string IdtypeVoucher { get; set; }
        public string TypeVoucher { get; set; }
        public string NomorVoucher { get; set; }
        public string Keterangan { get; set; }
        public decimal? Nominal { get; set; }
        public string Issuer { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Operator { get; set; }
        public int? ProductType { get; set; }
        public int? ProductId { get; set; }

        public virtual SalesOrder SalesOrder { get; set; }
    }
}
