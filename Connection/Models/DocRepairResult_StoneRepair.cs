using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DocRepairResult_StoneRepair
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
        public DateTime? Efektif { get; set; }
        public string Gia { get; set; }
        public decimal? Setting { get; set; }
        public decimal? HargaTotalRupiah { get; set; }

        public virtual DocRepairResult DocRepairResult { get; set; }
        public virtual StoneRepair StoneRepair { get; set; }
    }
}
