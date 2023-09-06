using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestStockProductDJ_CharDesign
    {
        public int design_category { get; set; }
        public int design_concept { get; set; }
        public int design_process { get; set; }
        public int target_age { get; set; }
        public int target_gender { get; set; }
        public string naming { get; set; }
        public bool set_item { get; set; }
        public bool special { get; set; }
        public string grafir { get; set; }
    }
}
