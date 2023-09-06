using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestStockProductDJ_CharProduct
    {
        public int product_item { get; set; }
        public int product_category { get; set; }
        public int product_level { get; set; }
        public int stone_dist { get; set; }
        public int frame_material { get; set; }
        public int frame_finishing { get; set; }
        public int frame_color { get; set; }
        public int process_cons { get; set; }
        public decimal gross_weight { get; set; }
        public decimal stone_carat { get; set; }
        public decimal stone_weight { get; set; }
        public int stone_qty { get; set; }
        public decimal netto_weight { get; set; }
        public decimal kadar_logam { get; set; }
        public decimal kadar_tukaran { get; set; }
        public decimal dimensi_d { get; set; }
        public decimal dimensi_p { get; set; }
        public decimal dimensi_l { get; set; }
        public decimal dimensi_r { get; set; }
        public decimal tukar_b2 { get; set; }
        public int product_category2 { get; set; }
        public decimal carat_size { get; set; }
    }
}
