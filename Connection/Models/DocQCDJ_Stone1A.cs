using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DocQCDJ_Stone1A
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idstone { get; set; }
        public string Keterangan { get; set; }
        public decimal? TotalButirActual { get; set; }
        public decimal? TotalCaratActual { get; set; }
        public bool? SesuaiSertifikat { get; set; }

        public virtual DocQCDJ DocQCDJ { get; set; }
        public virtual StockProductDJ_Stone1A StockProductDJ_Stone1A { get; set; }
    }
}
