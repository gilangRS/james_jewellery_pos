using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class NoteRepair_Repair
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idrepair { get; set; }
        public decimal Biaya { get; set; }
        public DateTime Efektif { get; set; }
        public string Keterangan { get; set; }

        public virtual NoteRepair NoteRepair { get; set; }
        public virtual CharProcessRepair CharProcessRepair { get; set; }
    }
}
