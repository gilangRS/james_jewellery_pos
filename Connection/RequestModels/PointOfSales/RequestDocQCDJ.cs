using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestDocQCDJ
    {
        public string qc_nama { get; set; }
        public string kode_lokasi { get; set; }
        public int id_product { get; set; }
        public string nomor { get; set; }
        public string logo { get; set; }
        public string kadar_emas { get; set; }
        public string warna_emas { get; set; }
        public string fisik_keseluruhan { get; set; }
        public string keterangan { get; set; }
        public decimal gross_weight { get; set; }

        public List<RequestDocQCDJ_Stone1A> stone1A { get; set; }
        public List<RequestDocQCDJ_Stone1B> stone1B { get; set; }
        public List<RequestDocQCDJ_Stone2> stone2 { get; set; }
        public List<RequestDocQCDJ_Stone3> stone3 { get; set; }
        public List<RequestDocQCDJ_Stone4> stone4 { get; set; }
        public List<RequestDocQCDJ_Stone5> stone5 { get; set; }
    }
}
