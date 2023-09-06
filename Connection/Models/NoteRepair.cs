using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class NoteRepair
    {
        public NoteRepair()
        {
            NoteRepair_Repairs = new HashSet<NoteRepair_Repair>();
            NoteRepair_Stone1As = new HashSet<NoteRepair_Stone1A>();
            NoteRepair_Stone1Bs = new HashSet<NoteRepair_Stone1B>();
            NoteRepair_Stone2s = new HashSet<NoteRepair_Stone2>();
            NoteRepair_Stone3s = new HashSet<NoteRepair_Stone3>();
            NoteRepair_Stone4s = new HashSet<NoteRepair_Stone4>();
            NoteRepair_Stone5s = new HashSet<NoteRepair_Stone5>();
        }

        public int Id { get; set; }
        public string Nomor { get; set; }
        public DateTime? Tgl { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public bool? Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public string Keterangan { get; set; }
        public int? IdworkOrder { get; set; }
        public int? Idreference { get; set; }
        public decimal? BalikEmas { get; set; }
        public decimal? BalikEmasIdr { get; set; }
        public DateTime? TglBerlakuEmas { get; set; }
        public decimal? JatahSusut { get; set; }
        public DateTime? TglBerlakuJatahSusut { get; set; }
        public decimal? Susut { get; set; }
        public int? NomorRevisi { get; set; }
        public decimal? TotalHargaEmas { get; set; }
        public decimal? TotalHargaJasa { get; set; }
        public decimal? TotalHargaStone { get; set; }
        public decimal? GrandTotalHarga { get; set; }
        public string NomorKirim { get; set; }

        public virtual NoteRepair_CharProduct NoteRepair_CharProduct { get; set; }
        public virtual ICollection<NoteRepair_Repair> NoteRepair_Repairs { get; set; }
        public virtual ICollection<NoteRepair_Stone1A> NoteRepair_Stone1As { get; set; }
        public virtual ICollection<NoteRepair_Stone1B> NoteRepair_Stone1Bs { get; set; }
        public virtual ICollection<NoteRepair_Stone2> NoteRepair_Stone2s { get; set; }
        public virtual ICollection<NoteRepair_Stone3> NoteRepair_Stone3s { get; set; }
        public virtual ICollection<NoteRepair_Stone4> NoteRepair_Stone4s { get; set; }
        public virtual ICollection<NoteRepair_Stone5> NoteRepair_Stone5s { get; set; }
    }
}
