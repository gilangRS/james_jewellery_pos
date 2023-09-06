using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DataSK
    {
        public int Id { get; set; }
        public int Idgroup { get; set; }
        public int? TipeLokasi { get; set; }
        public int Idlokasi { get; set; }
        public string Nama { get; set; }
        public string Keterangan { get; set; }
        public DateTime Tgl { get; set; }
        public bool Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public bool Disable { get; set; }
        public string AddrAlamat { get; set; }
        public string AddrNoTelp { get; set; }
        public string AddrNoFax { get; set; }
        public string AddrEmail { get; set; }
        public string ImgPicture { get; set; }
        public int? Iduser { get; set; }
        public string Nik { get; set; }

        public virtual DataSKGroup DataSKGroup { get; set; }
    }
}
