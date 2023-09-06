using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockCutoff
    {
        public int Id { get; set; }
        public DateTime TglCutoffAwal { get; set; }
        public DateTime TglCutoffAkhir { get; set; }
        public int? IdcutoffAkhir { get; set; }
        public string Keterangan { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }
    }
}
