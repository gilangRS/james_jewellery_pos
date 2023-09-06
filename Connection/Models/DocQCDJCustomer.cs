using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DocQCDJCustomer
    {
        public DocQCDJCustomer()
        {
            DocQCDJCustomer_Stone1As = new HashSet<DocQCDJCustomer_Stone1A>();
            DocQCDJCustomer_Stone1Bs = new HashSet<DocQCDJCustomer_Stone1B>();
            DocQCDJCustomer_Stone2s = new HashSet<DocQCDJCustomer_Stone2>();
            DocQCDJCustomer_Stone3s = new HashSet<DocQCDJCustomer_Stone3>();
            DocQCDJCustomer_Stone4s = new HashSet<DocQCDJCustomer_Stone4>();
            DocQCDJCustomer_Stone5s = new HashSet<DocQCDJCustomer_Stone5>();
        }

        public int Id { get; set; }
        public string Qcnama { get; set; }
        public int IdproductTitipan { get; set; }
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

        public virtual StockProductDJCustomer StockProductDJCustomer { get; set; }
        public virtual ICollection<DocQCDJCustomer_Stone1A> DocQCDJCustomer_Stone1As { get; set; }
        public virtual ICollection<DocQCDJCustomer_Stone1B> DocQCDJCustomer_Stone1Bs { get; set; }
        public virtual ICollection<DocQCDJCustomer_Stone2> DocQCDJCustomer_Stone2s { get; set; }
        public virtual ICollection<DocQCDJCustomer_Stone3> DocQCDJCustomer_Stone3s { get; set; }
        public virtual ICollection<DocQCDJCustomer_Stone4> DocQCDJCustomer_Stone4s { get; set; }
        public virtual ICollection<DocQCDJCustomer_Stone5> DocQCDJCustomer_Stone5s { get; set; }
    }
}
