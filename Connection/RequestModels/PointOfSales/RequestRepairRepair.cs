using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestRepairRepair
    {
        public int id_repair { get; set; }
        public decimal biaya { get; set; }
        public DateTime efektif { get; set; }
        public string keterangan { get; set; }
    }
}
