using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connection.RequestModels.PCS
{
    public  class PCS
    {
        public int ID { get; set; }
        public string Nama { get; set; }
        public string Kode { get; set; }
        public string Keterangan { get; set; }
        public bool Disable { get; set; }
        public string Satuan { get; set; }
        public decimal Harga { get; set; }
        public string Image { get; set; }
        public int Qty { get; set; }
        public int Received { get; set; }
        public int Damaged { get; set; }
        public int NeverArrived { get; set; }

        public IFormFile files { get; set; }

    }
}
