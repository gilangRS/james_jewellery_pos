using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestStockProductDJ
    {
        public DateTime tgl { get; set; }
        public string nomor { get; set; }
        public string operator_nama { get; set; }
        public RequestSalesOrder so { get; set; }
        public RequestStockProductDJ_CharProduct char_product { get; set; }
    }
}
