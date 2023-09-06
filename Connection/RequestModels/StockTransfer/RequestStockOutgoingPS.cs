using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.RequestModels.StockTransfer
{
    public class RequestStockOutgoingPS
    {
        public int ID { get; set; }
        public string NamaKurir { get; set; }
        public int Brand { get; set; }
        public int TipeAsal { get; set; }
        public int TipeTujuan { get; set; }
        public int IDAsal { get; set; }
        public int IDTujuan { get; set; }
        public string NamaAsal { get; set; }
        public string NamaTujuan { get; set; }
        public List<PS> Products { get; set; }
        public string TglETA { get; set; }
        public string Tgl { get; set; }
        public string Keterangan { get; set; }
    }
}
