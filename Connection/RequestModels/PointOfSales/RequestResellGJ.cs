using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestResellGJ
    {
        public int id_form { get; set; }
        public string id_sales_order { get; set; }
        public int id_product { get; set; }
        public int id_doc_qc { get; set; }
        public string nomor { get; set; }
        public decimal harga_acuan { get; set; }
        public decimal harga_rupiah { get; set; }
        public decimal nilai_trade_in { get; set; }
        public DateTime operator_tgl { get; set; }
        public string operator_nama { get; set; }
        public decimal berat_timbang { get; set; }
        public decimal tgp { get; set; }
    }
}
