using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestAddPLULD
    {
        public string Nomor { get; set; }
        public decimal TotalCarat { get; set; }
        public decimal Harga { get; set; }
        public string Invoice { get; set; }
        public DateTime TglInvoice { get; set; }
        public int TipeLokasi { get; set; }
        public int IDLokasi { get; set; }
        public string NamaLokasi { get; set; }
        public int IDCustomer { get; set; }
        public string NamaCustomer { get; set; }
        public RequestLDStone stone1B { get; set; }
    }
}
