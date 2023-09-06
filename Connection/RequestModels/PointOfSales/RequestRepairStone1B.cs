﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestRepairStone1B
    {
        public int id_form { get; set; }
        public int id_stone { get; set; }
        public string keterangan { get; set; }
        public int total_butir { get; set; }
        public decimal total_carat { get; set; }
        public decimal carat_butir { get; set; }
        public decimal dimensi_p { get; set; }
        public decimal dimensi_l { get; set; }
        public decimal dimesni_t { get; set; }
        public string gia { get; set; }
        public decimal harga_satuan { get; set; }
        public decimal harga_total { get; set; }
        public decimal harga_input_h { get; set; }
        public decimal harga_satuan_m { get; set; }
        public decimal harga_total_m { get; set; }
        public decimal harga_input_p { get; set; }
        public DateTime efektif { get; set; }
        public decimal setting { get; set; }
        public decimal harga_total_rupiah { get; set; }
        public int status_terpasang { get; set; }
    }
}
