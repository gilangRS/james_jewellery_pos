using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class ResellLD
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int? IdsalesOrder { get; set; }
        public int Idproduct { get; set; }
        public int? IddocQc { get; set; }
        public string Nomor { get; set; }
        public DateTime? TglResell { get; set; }
        public decimal? HargaAcuan { get; set; }
        public decimal? HargaRupiah { get; set; }
        public decimal? NilaiTradeIn { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string OperatorNama { get; set; }

        public virtual DocQCLD IddocQcNavigation { get; set; }
        public virtual Resell IdformNavigation { get; set; }
        public virtual StockProductLD_Stone1B IdproductNavigation { get; set; }
        public virtual SalesOrder IdsalesOrderNavigation { get; set; }
    }
}
