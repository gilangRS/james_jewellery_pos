using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connection.RequestModels.PCS
{
    public class ReceivePCS
    {
        public int ID { get; set; }
        public string NoDo { get; set; }
        public string NoPO { get; set; }
        public int IDWarehouse { get; set; }
        public string Keterangan { get; set; }
        public string Tgl { get; set; }
        public List<PCS> Product { get; set; }
        
    }
}
