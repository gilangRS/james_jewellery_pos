using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class ASPPG
    {
        public ASPPG()
        {
            ASPPGLogs = new HashSet<ASPPGLog>();
        }

        public int Id { get; set; }
        public int MeperiodeMin { get; set; }
        public int MeperiodeMax { get; set; }
        public decimal Merumus { get; set; }
        public int Ti1PeriodeMin { get; set; }
        public decimal Ti1Rumus { get; set; }
        public int Ti2PeriodeMin { get; set; }
        public decimal Ti2Rumus { get; set; }
        public int RPeriodeMin { get; set; }
        public decimal RRumus { get; set; }
        public string Keterangan { get; set; }

        public virtual ICollection<ASPPGLog> ASPPGLogs { get; set; }
    }
}
