using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.RequestModels.PointOfSales
{
    public class RequestStockProductDJCustomer
    {
        public string keterangan { get; set; }
        public string operator_nama { get; set; }
        public IFormFile images { get; set; }
        public string char_product { get; set; }
    }

    public class RequestCharProductDJCustomer
    {
        public RequestStockProductDJCustomer_CharProduct char_product { get; set; }
        public List<RequestStockProductDJCustomer_Stone1A> stone1A { get; set; }
        public List<RequestStockProductDJCustomer_Stone1B> stone1B { get; set; }
        public List<RequestStockProductDJCustomer_Stone2> stone2 { get; set; }
        public List<RequestStockProductDJCustomer_Stone3> stone3 { get; set; }
        public List<RequestStockProductDJCustomer_Stone4> stone4 { get; set; }
        public List<RequestStockProductDJCustomer_Stone5> stone5 { get; set; }
    }
}
