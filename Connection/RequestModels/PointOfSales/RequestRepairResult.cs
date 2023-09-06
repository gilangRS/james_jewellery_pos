using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestRepairResult
    {
        public int id_doc_repair { get; set; }
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
        public int id_product { get; set; }
        public int sumber { get; set; }
        public int id_product_titipan { get; set; }
        public decimal estimasi_harga { get; set; }
        public int idqc { get; set; }
        public int idqc_titipan { get; set; }
        public string kode_customer_lama { get; set; }
        public bool is_titipan { get; set; }

        public RequestRepairCharProduct char_product_repair { get; set; }
        public List<RequestRepairRepair> process_list_repair { get; set; }
        public List<RequestRepairStone1A> stone1A_repair { get; set; }
        public List<RequestRepairStone1B> stone1B_repair { get; set; }
        public List<RequestRepairStone2> stone2_repair { get; set; }
        public List<RequestRepairStone3> stone3_repair { get; set; }
        public List<RequestRepairStone4> stone4_repair { get; set; }
        public List<RequestRepairStone5> stone5_repair { get; set; }
    }
}
