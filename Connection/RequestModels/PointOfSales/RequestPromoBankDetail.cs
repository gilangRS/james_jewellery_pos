using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestPromoBankDetail
    {
        public string nama { get; set; }
        public int id_payment_type { get; set; }
        public int id_bank { get; set; }
        public decimal min_value { get; set; }
        public decimal max_value { get; set;}
        public decimal discount { get; set; }
        public int order_number { get; set; }
    }
}
