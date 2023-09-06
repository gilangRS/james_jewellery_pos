using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class Stone1A
    {
        public Stone1A()
        {
            NoteRepair_Stone1As = new HashSet<NoteRepair_Stone1A>();
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
        public int Parcel03 { get; set; }
        public int Parcel04 { get; set; }
        public int StatusCosting { get; set; }
        public int StatusPricing { get; set; }
        public string ImgPicture { get; set; }

        public virtual ICollection<NoteRepair_Stone1A> NoteRepair_Stone1As { get; set; }
    }
}
