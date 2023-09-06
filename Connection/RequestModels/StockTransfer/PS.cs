using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.RequestModels.StockTransfer
{
    public class PS
    {
        public int ID { get; set; }
        public string Kode { get; set; }
        public int Qty { get; set; }
        public int Receive { get; set; }
        public int Demaged { get; set; }
        public int NeverArrived { get; set; }
    }
}
