using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestTitipanProduct
    {
        public int id_product { get; set; }
        public int id_product_titipan { get; set; }
        public int id_doc_qc { get; set; }
        public string keterangan { get; set; }
        public string img_picture { get; set; }
        public int tipe_product { get; set; }
    }
}
