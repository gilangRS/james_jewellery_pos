using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestResell
    {
        public int tipe_lokasi { get; set; }
        public int id_lokasi { get; set; }
        public string kode_lokasi { get; set; }
        public int id_customer { get; set; }
        public string customer_nama { get; set; }
        public int id_sales { get; set; }
        public string sales_nama { get; set; }
        public string nomor { get; set; }
        public DateTime tgl { get; set; }
        public decimal total_harga { get; set; }
        public string operator_nama { get; set; }
        public string keterangan { get; set; }
        public bool tradein { get; set; }
        public bool status_void { get; set; }
        public string keterangan_void { get; set; }
        public string kode_customer_lama { get; set; }
        public string group_resell { get; set; }

        public List<RequestResellDJ> resell_dj { get; set; }
        public List<RequestResellGJ> resell_gj { get; set; }
        public List<RequestResellPG> resell_pg { get; set; }
        public List<RequestResellLD> resell_ld { get; set; }
    }
}
