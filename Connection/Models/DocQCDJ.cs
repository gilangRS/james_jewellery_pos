using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DocQCDJ
    {
        public DocQCDJ()
        {
            DocQCDJ_Stone1As = new HashSet<DocQCDJ_Stone1A>();
            DocQCDJ_Stone1Bs = new HashSet<DocQCDJ_Stone1B>();
            DocQCDJ_Stone2s = new HashSet<DocQCDJ_Stone2>();
            DocQCDJ_Stone3s = new HashSet<DocQCDJ_Stone3>();
            DocQCDJ_Stone4s = new HashSet<DocQCDJ_Stone4>();
            DocQCDJ_Stone5s = new HashSet<DocQCDJ_Stone5>();
            DocTitipan_Products = new HashSet<DocTitipan_Product>();
            ResellDJs = new HashSet<ResellDJ>();
        }

        public int Id { get; set; }
        public string Qcnama { get; set; }
        public int Idproduct { get; set; }
        public string Nomor { get; set; }
        public string Blemish { get; set; }
        public string JumlahButir { get; set; }
        public string Sertifikat { get; set; }
        public string NonCz { get; set; }
        public string Cz { get; set; }
        public string Logo { get; set; }
        public string KadarEmas { get; set; }
        public string Merk { get; set; }
        public string NetWeight { get; set; }
        public string WarnaEmas { get; set; }
        public string FisikKeseluruhan { get; set; }
        public string OperatorNama { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public bool? Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public string Keterangan { get; set; }
        public decimal GrossWeight { get; set; }

        public virtual StockProductDJ StockProductDJ { get; set; }
        public virtual ICollection<DocQCDJ_Stone1A> DocQCDJ_Stone1As { get; set; }
        public virtual ICollection<DocQCDJ_Stone1B> DocQCDJ_Stone1Bs { get; set; }
        public virtual ICollection<DocQCDJ_Stone2> DocQCDJ_Stone2s { get; set; }
        public virtual ICollection<DocQCDJ_Stone3> DocQCDJ_Stone3s { get; set; }
        public virtual ICollection<DocQCDJ_Stone4> DocQCDJ_Stone4s { get; set; }
        public virtual ICollection<DocQCDJ_Stone5> DocQCDJ_Stone5s { get; set; }
        public virtual ICollection<DocTitipan_Product> DocTitipan_Products { get; set; }
        public virtual ICollection<ResellDJ> ResellDJs { get; set; }
    }
}
