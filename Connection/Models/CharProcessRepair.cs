using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class CharProcessRepair
    {
        public CharProcessRepair()
        {
            DocRepair_Repairs = new HashSet<DocRepair_Repair>();
            DocRepairResult_Repairs = new HashSet<DocRepairResult_Repair>();
            NoteRepair_Repairs = new HashSet<NoteRepair_Repair>();
            PricingTableRepairs = new HashSet<PricingTableRepair>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string NamaKode { get; set; }
        public string Keterangan { get; set; }
        public int Sn { get; set; }
        public bool Disable { get; set; }

        public virtual ICollection<DocRepair_Repair> DocRepair_Repairs { get; set; }
        public virtual ICollection<DocRepairResult_Repair> DocRepairResult_Repairs { get; set; }
        public virtual ICollection<NoteRepair_Repair> NoteRepair_Repairs { get; set; }
        public virtual ICollection<PricingTableRepair> PricingTableRepairs { get; set; }
    }
}
