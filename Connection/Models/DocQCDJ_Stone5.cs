using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DocQCDJ_Stone5
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idstone { get; set; }
        public string Keterangan { get; set; }
        public decimal? TotalButirActual { get; set; }
        public decimal? TotalCaratActual { get; set; }
        public bool? SesuaiSertifikat { get; set; }

        public virtual DocQCDJ DocQCDJ { get; set; }
        public virtual StockProductDJ_Stone5 StockProductDJ_Stone5 { get; set; }
    }
}
