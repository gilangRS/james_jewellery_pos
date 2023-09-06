using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestDocQCPG
    {
        public string qc_nama { get; set; }
        public string kode_lokasi { get; set; }
        public int id_product { get; set; }
        public string nomor { get; set; }
        public string logo { get; set; }
        public string kadar_logam { get; set; }
        public string warna_emas { get; set; }
        public string fisik_keseluruhan { get; set; }
        public string keterangan { get; set; }
        public decimal gross_weight { get; set; }
        public string kadar_karatimeter { get; set; }
    }
}
