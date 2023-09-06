using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockProductDJLD
    {
        public int Id { get; set; }
        public int? IdproductDj { get; set; }
        public int? IdproductLd { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string OperatorNama { get; set; }
        public string Keterangan { get; set; }
        public bool? Draft { get; set; }
        public DateTime? DraftDate { get; set; }

        public virtual StockProductDJ StockProductDJ { get; set; }
        public virtual StockProductLD_Stone1B StockProductLD_Stone1B { get; set; }
    }
}
