using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestSalesSouvenir
    {
        public int tipe_lokasi { get; set; }
        public int id_lokasi { get; set; }
        public string kode_lokasi { get; set; }
        public int id_customer { get; set; }
        public string customer_nama { get; set; }
        public int id_sales { get; set; }
        public string sales_nama { get; set; }
        public string nomor { get; set; }
        public decimal modal_rupiah { get; set; }
        public decimal harga_rupiah { get; set; }
        public decimal paid { get; set; }
        public decimal unpaid { get; set; }
        public decimal total_bayar { get; set; }
        public decimal total_rupiah { get; set; }
        public decimal total_resell { get; set; }
        public bool status_void { get; set; }
        public bool status_pembayaran { get; set; }
        public DateTime tgl { get; set; }
        public bool draft { get; set; }
        public DateTime draft_date { get; set; }
        public string keterangan { get; set; }
        public string operator_nama { get; set; }
        public DateTime operator_tgl { get; set; }
        public bool trade_in { get; set; }
        public DateTime tgl_lunas { get; set; }
        public string customer_reference_nama { get; set; }
        public string e_receipt_hp { get; set; }
        public string e_receipt_email { get; set; }
        public string kode_customer_lama { get; set; }
        public bool npwp { get; set; }
        public string link_packaging_sales_order { get; set; }
        public string kode_brand_cross { get; set; }
        public int tipe_lokasi_cross { get; set; }
        public int id_lokasi_cross { get; set; }
        public int id_sales_cross { get; set; }
        public string nama_sales_cross { get; set; }
        public string nik_sales_cross { get; set; }
        public string link_packaging_down_payment { get; set; }
        public string link_packaging_repair { get; set; }
        public string membership { get; set; }
        public int id_event { get; set; }

        public List<RequestSalesOrderSouvenir> sales_order_souvenir { get; set; }
    }
}
