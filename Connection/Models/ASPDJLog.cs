using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class ASPDJLog
    {
        public int Id { get; set; }
        public int? Idmaster { get; set; }
        public int ProductCategory { get; set; }
        public int MeperiodeMin { get; set; }
        public int MeperiodeMinLama { get; set; }
        public int MeperiodeMax { get; set; }
        public int MeperiodeMaxLama { get; set; }
        public decimal Merumus { get; set; }
        public decimal MerumusLama { get; set; }
        public int Ti1PeriodeMin { get; set; }
        public int Ti1PeriodeMinLama { get; set; }
        public int Ti1PeriodeMax { get; set; }
        public int Ti1PeriodeMaxLama { get; set; }
        public decimal Ti1Rumus { get; set; }
        public decimal Ti1RumusLama { get; set; }
        public int Ti2PeriodeMin { get; set; }
        public int Ti2PeriodeMinLama { get; set; }
        public int Ti2PeriodeMax { get; set; }
        public int Ti2PeriodeMaxLama { get; set; }
        public decimal Ti2Rumus { get; set; }
        public decimal Ti2RumusLama { get; set; }
        public int Ti3PeriodeMin { get; set; }
        public int Ti3PeriodeMinLama { get; set; }
        public int Ti3PeriodeMax { get; set; }
        public int Ti3PeriodeMaxLama { get; set; }
        public decimal Ti3Rumus { get; set; }
        public decimal Ti3RumusLama { get; set; }
        public int R1PeriodeMin { get; set; }
        public int R1PeriodeMinLama { get; set; }
        public int R1PeriodeMax { get; set; }
        public int R1PeriodeMaxLama { get; set; }
        public decimal R1Rumus { get; set; }
        public decimal R1RumusLama { get; set; }
        public int R2PeriodeMin { get; set; }
        public int R2PeriodeMinLama { get; set; }
        public int R2PeriodeMax { get; set; }
        public int R2PeriodeMaxLama { get; set; }
        public decimal R2Rumus { get; set; }
        public decimal R2RumusLama { get; set; }
        public DateTime? Tgl { get; set; }

        public virtual ASPDJ ASPDJ { get; set; }
        public virtual CharProductCategory CharProductCategory { get; set; }
    }
}
