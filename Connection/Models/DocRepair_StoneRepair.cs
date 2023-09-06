using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DocRepair_StoneRepair
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idstone { get; set; }
        public string Keterangan { get; set; }
        public int TotalButir { get; set; }
        public decimal TotalCarat { get; set; }
        public decimal CaratButir { get; set; }
        public decimal? HargaSatuan { get; set; }
        public decimal? HargaTotal { get; set; }
        public string Gia { get; set; }
        public DateTime? Efektif { get; set; }
        public decimal? Setting { get; set; }

        public virtual DocRepair DocRepair { get; set; }
        public virtual StoneRepair StoneRepair { get; set; }
    }
}
