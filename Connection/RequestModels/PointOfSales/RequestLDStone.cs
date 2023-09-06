using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestLDStone
    {
        public int IDStone { get; set; }
        public int Butir { get; set; }
        public decimal Carat { get; set; }
        public decimal DimensiP { get; set; }
        public decimal DimensiL { get; set; }
        public decimal DimensiT { get; set; }
        public string GIA { get; set; }
    }
}
