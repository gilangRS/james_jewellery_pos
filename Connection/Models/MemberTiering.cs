using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class MemberTiering
    {
        public int Id { get; set; }
        public int TipeCustomer { get; set; }
        public decimal Rupiah { get; set; }
        public decimal? RupiahPending { get; set; }
        public decimal? Discount { get; set; }
        public decimal? DiscountPending { get; set; }
        public decimal? BirthdayRupiah { get; set; }
        public decimal? BirthdayRupiahPending { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }
    }
}
