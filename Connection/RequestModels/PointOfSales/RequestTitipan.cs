using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestTitipan
    {
        public int id_lokasi { get; set; }
        public int tipe_lokasi { get; set; }
        public string kode_lokasi { get; set; }
        public int id_customer { get; set; }
        public string customer_nama { get; set; }
        public int id_sales { get; set; }
        public string sales_nama { get; set; }
        public string operator_nama { get; set; }
        public DateTime operator_tgl { get; set; }
        public DateTime tgl_selesai { get; set; }
        public string keterangan { get; set; }

        public RequestTitipanProduct product { get; set; }
        public IFormFile files { get; set; }
    }
}
