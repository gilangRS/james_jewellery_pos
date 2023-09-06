using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestSalesOrderRepair
    {
        public int id_repair_result { get; set; }
        public decimal harga_rupiah { get; set; }
        public decimal discount { get; set; }
        public decimal total_bayar { get; set; }

        public List<RequestSalesReceiptDetail> payment { get; set; }
    }
}
