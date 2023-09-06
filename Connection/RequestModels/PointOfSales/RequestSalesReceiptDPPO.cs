using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestSalesReceiptDPPO
    {
        public int id_customer { get; set; }
        public string customer_nama { get; set; }
        public int id_sales { get; set; }
        public string sales_nama { get; set; }
        public DateTime tgl { get; set; }
        public string kode_lokasi { get; set; }
        public int tipe_lokasi { get; set; }
        public int id_lokasi { get; set; }
        public decimal total_bayar { get; set; }
        public DateTime operator_tgl { get; set; }
        public string operator_nama { get; set; }
        public int status_dp { get; set; }
        public string keterangan { get; set; }
        public decimal estimasi_harga { get; set; }
        public int id_dppo_reference { get; set; }
        public int id_product_sample1 { get; set; }
        public int id_product_sample2 { get; set; }
        public int id_product { get; set; }
        public int tipe_product { get; set; }
        public int id_frame_color { get; set; }
        public decimal gold_weight1 { get; set; }
        public decimal gold_weight2 { get; set; }
        public decimal diamond_weight1 { get; set; }
        public decimal diamond_weight2 { get; set; }
        public decimal ring_size1 { get; set; }
        public decimal ring_size2 { get; set; }
        public decimal incription1 { get; set; }
        public decimal incription2 { get; set; }
        public int id_font_type { get; set; }
        public DateTime delivery_date { get; set; }

        public List<RequestSalesReceiptDPPODetail> listdppo { get; set; }
    }
}
