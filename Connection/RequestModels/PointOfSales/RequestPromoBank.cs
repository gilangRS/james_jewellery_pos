using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestPromoBank
    {
        public string nama { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        public string keterangan { get; set; }
        public string operator_nama { get; set; }
        public List<RequestPromoBankDetail> details { get; set; }
    }
}
