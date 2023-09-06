using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestSalesReceipt
    {
        public int id_so { get; set; }
        public decimal total_bayar { get; set; }
        public string operator_nama { get; set; }
        public bool is_require_email { get; set; }
        public List<RequestSalesReceiptDetail> details { get; set; }
    }
}
