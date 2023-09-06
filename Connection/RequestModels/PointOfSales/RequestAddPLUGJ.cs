using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestAddPLUGJ
    {
        public int TipeLokasi { get; set; }
        public int IDLokasi { get; set; }
        public string NamaLokasi { get; set; }
        public int IDCustomer { get; set; }
        public string NamaCustomer { get; set; }
    }
}
