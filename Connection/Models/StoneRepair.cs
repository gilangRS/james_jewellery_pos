using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StoneRepair
    {
        public StoneRepair()
        {
            DocRepairResult_StoneRepairs = new HashSet<DocRepairResult_StoneRepair>();
            DocRepair_StoneRepairs = new HashSet<DocRepair_StoneRepair>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string Keterangan { get; set; }
        public DateTime Tgl { get; set; }
        public bool Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public bool Disable { get; set; }
        public string KodeParcel { get; set; }
        public int Parcel01 { get; set; }
        public int Parcel02 { get; set; }
        public int StatusCosting { get; set; }
        public int StatusPricing { get; set; }
        public string ImgPicture { get; set; }

        public virtual ICollection<DocRepairResult_StoneRepair> DocRepairResult_StoneRepairs { get; set; }
        public virtual ICollection<DocRepair_StoneRepair> DocRepair_StoneRepairs { get; set; }
    }
}
