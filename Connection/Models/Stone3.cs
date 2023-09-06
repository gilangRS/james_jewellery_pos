using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class Stone3
    {
        public Stone3()
        {
            NoteRepair_Stone3s = new HashSet<NoteRepair_Stone3>();
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
        public int Parcel05 { get; set; }
        public int Parcel06 { get; set; }
        public int Parcel07 { get; set; }
        public int Parcel08 { get; set; }
        public int StatusCosting { get; set; }
        public int StatusPricing { get; set; }
        public string ImgPicture { get; set; }
        public int Parcel09 { get; set; }
        public int Parcel10 { get; set; }
        public int Parcel11 { get; set; }
        public int Parcel12 { get; set; }

        public virtual ICollection<NoteRepair_Stone3> NoteRepair_Stone3s { get; set; }
    }
}
