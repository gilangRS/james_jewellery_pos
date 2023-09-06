using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestSalesOrderPackaging
    {
        public int id_product { get; set; }
        public string invoice { get; set; }
        public decimal modal_rupiah { get; set; }
        public decimal total_rupiah { get; set; }
        public decimal qty { get; set; }
        public decimal total_modal_rupiah { get; set; }
        public int id_product_dj { get; set; }
        public int id_product_pg { get; set; }
        public int id_product_gj { get; set; }
        public int id_product_ld { get; set; }
    }
}
