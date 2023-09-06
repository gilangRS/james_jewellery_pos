using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestDocQCDJ_Stone5
    {
        public int id_stone { get; set; }
        public string keterangan { get; set; }
        public int total_butir_actual { get; set; }
        public decimal total_carat_actual { get; set; }
        public bool sesuai_sertifikat { get; set; }
    }
}
