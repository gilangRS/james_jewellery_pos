using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestAddPLUPG
    {
        public string Nomor { get; set; }
        public int ProductItem { get; set; }
        public int GoldLevel { get; set; }
        public int GoldModel { get; set; }
        public int FrameColor { get; set; }
        public int TargetAge { get; set; }
        public string NoCert { get; set; }
        public decimal Weight { get; set; }
        public decimal Tgp { get; set; }
        public decimal KadarLogam { get; set; }
        public decimal Harga { get; set; }
        public string Invoice { get; set; }
        public DateTime TglInvoice { get; set; }
        public int TipeLokasi { get; set; }
        public int IDLokasi { get; set; }
        public string NamaLokasi { get; set; }
        public int IDCustomer { get; set; }
        public string NamaCustomer { get; set; }
        public string Keterangan { get; set; }
    }
}
