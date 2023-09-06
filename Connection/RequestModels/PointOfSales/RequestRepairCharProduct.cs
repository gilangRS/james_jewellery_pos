using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestRepairCharProduct
    {
        public int id_product_item { get; set; }
        public int id_product_category { get; set; }
        public int id_product_level { get; set; }
        public int id_stone_dist { get; set; }
        public int id_frame_material { get; set; }
        public int id_frame_finishing { get; set; }
        public int id_frame_color { get; set; }
        public int id_process_cons { get; set; }
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
    }
}
