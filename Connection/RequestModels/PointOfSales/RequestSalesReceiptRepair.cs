using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestSalesReceiptRepair
    {
        public int id_repair_result { get; set; }
        public decimal total_bayar { get; set; }
        public string operator_nama { get; set; }
        public List<RequestSalesReceiptDetail> details { get; set; }
    }
}
