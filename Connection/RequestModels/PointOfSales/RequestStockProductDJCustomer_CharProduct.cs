using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestStockProductDJCustomer_CharProduct
    {
        public int product_item { get; set; }
        public decimal gross_weight { get; set; }
        public decimal stone_carat { get; set; }
        public decimal stone_weight { get; set; }
        public int stone_qty { get; set; }
        public decimal netto_weight { get; set; }
        public decimal dimensi_d { get; set; }
        public decimal dimensi_p { get; set; }
        public decimal dimensi_l { get; set; }
        public decimal dimensi_r { get; set; }
    }
}
