using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockCutoffInvalid
    {
        public int Id { get; set; }
        public int Idcutoff { get; set; }
        public int? Idproduct { get; set; }
        public string NomorPlu { get; set; }
        public string ProductType { get; set; }
        public int? LokasiTipe { get; set; }
        public int? LokasiId { get; set; }
        public string Keterangan { get; set; }
    }
}
