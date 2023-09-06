using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestSalesVoucher
    {
        public string id_type_voucher { get; set; }
        public string type_voucher { get; set; }
        public string nomor_voucher { get; set; }
        public string keterangan { get; set; }
        public decimal nominal { get; set; }
        public string issuer { get; set; }
        public DateTime operator_tgl { get; set; }
        public string operator_nama { get; set; }
        public int product_type { get; set; }
        public int product_id { get; set; }
    }
}
