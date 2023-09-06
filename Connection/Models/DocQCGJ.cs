﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DocQCGJ
    {
        public DocQCGJ()
        {
            ResellGJs = new HashSet<ResellGJ>();
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

        public virtual StockProductGJ StockProductGJ { get; set; }
        public virtual ICollection<ResellGJ> ResellGJs { get; set; }
    }
}
