using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestSalesOrderPG
    {
        public int id_product { get; set; }
        public string invoice { get; set; }
        public decimal modal_tgp { get; set; }
        public decimal modal_rupiah { get; set; }
        public decimal harga_rupiah { get; set; }
        public decimal discount { get; set; }
        public decimal discount_nominal { get; set; }
        public decimal discount_program { get; set; }
        public decimal discount_program_nominal { get; set; }
        public decimal discount_gift { get; set; }
        public decimal discount_bank { get; set; }
        public decimal discount_other { get; set; }
        public decimal discount_round { get; set; }
        public decimal discount_promo { get; set; }
        public decimal total_rupiah { get; set; }
        public decimal total_bayar { get; set; }
        public decimal total_dp { get; set; }
        public decimal tgp_jual { get; set; }
        public decimal berat_timbang { get; set; }
        public int status_resell { get; set; }
        public decimal ppn { get; set; }
        public int ppn_percentage { get; set; }
        public int id_promo_bank { get; set; }

        public RequestSalesVoucher sales_voucher { get; set; }
    }
}
