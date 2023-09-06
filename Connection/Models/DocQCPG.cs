using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DocQCPG
    {
        public DocQCPG()
        {
            ResellPGs = new HashSet<ResellPG>();
        }

        public int Id { get; set; }
        public string Qcnama { get; set; }
        public int Idproduct { get; set; }
        public string Nomor { get; set; }
        public string Logo { get; set; }
        public string KadarLogam { get; set; }
        public string Merk { get; set; }
        public string FisikKeseluruhan { get; set; }
        public string NetWeight { get; set; }
        public string WarnaEmas { get; set; }
        public string OperatorNama { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public bool? Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public string Keterangan { get; set; }
        public decimal GrossWeight { get; set; }
        public string KadarKaratimeter { get; set; }

        public virtual StockProductPG StockProductPG { get; set; }
        public virtual ICollection<ResellPG> ResellPGs { get; set; }
    }
}
