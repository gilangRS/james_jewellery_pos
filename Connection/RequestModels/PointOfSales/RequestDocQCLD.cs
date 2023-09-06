using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestDocQCLD
    {
        public string qc_nama { get; set; }
        public string kode_lokasi { get; set; }
        public int id_product { get; set; }
        public int jumlah_butir { get; set; }
        public string sertifikat { get; set; }
        public string nomor { get; set; }
        public string logo { get; set; }
        public string kadar_emas { get; set; }
        public string warna_emas { get; set; }
        public string fisik_keseluruhan { get; set; }
        public string keterangan { get; set; }
        public decimal gross_weight { get; set; }
        public decimal carat { get; set; }
        public string colour { get; set; }
        public string clarity { get; set; }
        public string cutting { get; set; }
        public decimal harga_jual_customer { get; set; }
        public string item { get; set; }
        public string shape { get; set; }
        public string brand { get; set; }
        public string check_sertifikat { get; set; }
        public string check_invoice { get; set; }
        public string check_laser_incription { get; set; }
        public string check_measurement { get; set; }
        public string check_kondisi_batu { get; set; }
        public string tradein_or_resell { get; set; }

        public List<RequestExtensionLD> extension_ld { get; set; }
    }
}
