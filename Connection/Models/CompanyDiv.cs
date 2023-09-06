using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class CompanyDiv
    {
        public int Id { get; set; }
        public int Idcompany { get; set; }
        public string Nama { get; set; }
        public string NamaKode { get; set; }
        public string Keterangan { get; set; }
        public int Sn { get; set; }
        public bool Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public bool Disable { get; set; }
        public string AddrAlamat { get; set; }
        public string AddrNoTelp { get; set; }
        public string AddrNoFax { get; set; }
        public string AddrEmail { get; set; }

        public virtual Company Company { get; set; }
    }
}
