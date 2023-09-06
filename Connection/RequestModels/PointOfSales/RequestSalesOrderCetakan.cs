using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestSalesOrderCetakan
    {
        public int id_product { get; set; }
        public decimal modal_rupiah { get; set; }
        public decimal total_rupiah { get; set; }
        public int qty { get; set; }
        public decimal total_modal_rupiah { get; set; }
    }
}
