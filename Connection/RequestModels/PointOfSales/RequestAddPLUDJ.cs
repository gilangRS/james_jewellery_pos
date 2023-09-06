using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestAddPLUDJ
    {
        public string Nomor { get; set; }
        public int ProductItem { get; set; }
        public int ProductCategory { get; set; }
        public int ProductLevel { get; set; }
        public int StoneDist { get; set; }
        public int FrameMaterial { get; set; }
        public int FrameColor { get; set; }
        public int FrameFinishing { get; set; }
        public int ConsProcess { get; set; }
        public decimal Weight { get; set; }
        public decimal Size { get; set; }
        public decimal Harga { get; set; }
        public string Invoice { get; set; }
        public DateTime TglInvoice { get; set; }
        public int TipeLokasi { get; set; }
        public int IDLokasi { get; set; }
        public string NamaLokasi { get; set; }
        public int IDCustomer { get; set; }
        public string NamaCustomer { get; set; }
        public List<RequestFinishing> Finishing { get; set; }
        public List<RequestDJStone> Stone { get; set; }
    }
}
