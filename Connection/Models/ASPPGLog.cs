using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class ASPPGLog
    {
        public int Id { get; set; }
        public int? Idmaster { get; set; }
        public int MeperiodeMin { get; set; }
        public int MeperiodeMinLama { get; set; }
        public int MeperiodeMax { get; set; }
        public int MeperiodeMaxLama { get; set; }
        public decimal Merumus { get; set; }
        public decimal MerumusLama { get; set; }
        public int Ti1PeriodeMin { get; set; }
        public int Ti1PeriodeMinLama { get; set; }
        public decimal Ti1Rumus { get; set; }
        public decimal Ti1RumusLama { get; set; }
        public int Ti2PeriodeMin { get; set; }
        public int Ti2PeriodeMinLama { get; set; }
        public decimal Ti2Rumus { get; set; }
        public decimal Ti2RumusLama { get; set; }
        public int RPeriodeMin { get; set; }
        public int RPeriodeMinLama { get; set; }
        public decimal RRumus { get; set; }
        public decimal RRumusLama { get; set; }
        public DateTime? Tgl { get; set; }

        public virtual ASPPG ASPPG { get; set; }
    }
}
