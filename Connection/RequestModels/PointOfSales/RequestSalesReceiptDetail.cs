using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestSalesReceiptDetail
    {
        public int id_payment_type { get; set; }
        public int id_card { get; set; }
        public int id_program { get; set; }
        public decimal mdr { get; set; }
        public int id_edc { get; set; }
        public int id_bank_issuer { get; set; }
        public string cc_number { get; set; }
        public string cc_name { get; set; }
        public decimal nominal { get; set; }
        public DateTime operator_tgl { get; set; }
        public string operator_nama { get; set; }
        public int id_jenis_kartu_kredit { get; set; }
        public int void_reference { get; set; }
        public int ecr_verification { get; set; }
        public DateTime ecr_verification_tgl { get; set; }
        public string ecr_response_value { get; set; }
        public bool gc_verification { get; set; }
        public DateTime gc_verification_tgl { get; set; }
        public bool gc_void_verification { get; set; }
        public DateTime gc_void_verification_tgl { get; set; }
        public string approval_code { get; set; }
    }
}
