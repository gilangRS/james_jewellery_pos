using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class ASPDJ
    {
        public ASPDJ()
        {
            ASPDJLogs = new HashSet<ASPDJLog>();
        }

        public int Id { get; set; }
        public int ProductCategory { get; set; }
        public int MeperiodeMin { get; set; }
        public int MeperiodeMax { get; set; }
        public decimal Merumus { get; set; }
        public int Ti1PeriodeMin { get; set; }
        public int Ti1PeriodeMax { get; set; }
        public decimal Ti1Rumus { get; set; }
        public int Ti2PeriodeMin { get; set; }
        public int Ti2PeriodeMax { get; set; }
        public decimal Ti2Rumus { get; set; }
        public int Ti3PeriodeMin { get; set; }
        public int Ti3PeriodeMax { get; set; }
        public decimal Ti3Rumus { get; set; }
        public int R1PeriodeMin { get; set; }
        public int R1PeriodeMax { get; set; }
        public decimal R1Rumus { get; set; }
        public int R2PeriodeMin { get; set; }
        public int R2PeriodeMax { get; set; }
        public decimal R2Rumus { get; set; }
        public string Keterangan { get; set; }
        public int? StatusBrand { get; set; }
        public int? MeperiodeMaxDay { get; set; }

        public virtual CharProductCategory CharProductCategory { get; set; }
        public virtual ICollection<ASPDJLog> ASPDJLogs { get; set; }
    }
}
