using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class ResellPG
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int IdsalesOrder { get; set; }
        public int Idproduct { get; set; }
        public int? IddocQc { get; set; }
        public string Nomor { get; set; }
        public DateTime? TglResell { get; set; }
        public decimal? HargaAcuan { get; set; }
        public decimal? HargaRupiah { get; set; }
        public decimal? NilaiTradeIn { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string OperatorNama { get; set; }
        public decimal? BeratTimbang { get; set; }
        public decimal? Tgp { get; set; }

        public virtual DocQCPG IddocQcNavigation { get; set; }
        public virtual Resell IdformNavigation { get; set; }
        public virtual StockProductPG IdproductNavigation { get; set; }
        public virtual SalesOrder IdsalesOrderNavigation { get; set; }
    }
}
