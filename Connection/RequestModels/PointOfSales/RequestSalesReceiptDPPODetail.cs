using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestSalesReceiptDPPODetail
    {
        public int id_po { get; set; }
        public int id_payment { get; set; }
        public int id_card { get; set; }
        public int id_program { get; set; }
        public decimal mdr { get; set; }
        public int id_edc { get; set; }
        public int id_bank_issuer { get; set; }
        public string cc_number { get; set; }
        public string cc_nama { get; set; }
        public decimal nominal { get; set; }
        public DateTime operator_tgl { get; set; }
        public string operator_nama { get; set; }
        public int id_jenis_kartu_kredit { get; set; }
        public string approval_code { get; set; }
    }
}
