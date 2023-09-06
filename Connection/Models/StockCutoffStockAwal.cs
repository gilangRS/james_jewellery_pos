using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockCutoffStockAwal
    {
        public int Id { get; set; }
        public int Idcutoff { get; set; }
        public int Idproduct { get; set; }
        public string NomorPlu { get; set; }
        public string ProductType { get; set; }
        public string ProductItem { get; set; }
        public string ProductLevel { get; set; }
        public string ProductCategory { get; set; }
        public string ProductSegmen { get; set; }
        public string Supplier { get; set; }
        public int LokasiTipe { get; set; }
        public int LokasiId { get; set; }
        public int Qty { get; set; }
        public decimal HargaM { get; set; }
        public decimal HargaJual { get; set; }
        public decimal TotalButir { get; set; }
        public decimal TotalCarat { get; set; }
        public decimal TotalNetto { get; set; }
        public decimal TotalGross { get; set; }
    }
}
