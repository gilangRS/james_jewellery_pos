using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class MemberTieringLog
    {
        public int Id { get; set; }
        public int Idmaster { get; set; }
        public DateTime Tgl { get; set; }
        public string Approval { get; set; }
        public decimal RupiahLama { get; set; }
        public decimal RupiahBaru { get; set; }
        public decimal? DiscountLama { get; set; }
        public decimal? DiscountBaru { get; set; }
        public decimal? BirthdayLama { get; set; }
        public decimal? BirthdayBaru { get; set; }
    }
}
