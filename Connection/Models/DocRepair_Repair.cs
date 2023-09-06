using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DocRepair_Repair
    {
        public int Id { get; set; }
        public int? Idform { get; set; }
        public int? Idrepair { get; set; }
        public decimal? Biaya { get; set; }
        public DateTime? Efektif { get; set; }
        public string Keterangan { get; set; }

        public virtual DocRepair DocRepair { get; set; }
        public virtual CharProcessRepair CharProcessRepair { get; set; }
    }
}
