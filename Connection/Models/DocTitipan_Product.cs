using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DocTitipan_Product
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int? Idproduct { get; set; }
        public int? IdproductTitipan { get; set; }
        public int? IddocQc { get; set; }
        public string Keterangan { get; set; }
        public string ImgPicture { get; set; }

        public virtual DocQCDJ DocQCDJ { get; set; }
        public virtual DocTitipan DocTitipan { get; set; }
        public virtual StockProductDJ StockProductDJ { get; set; }
        public virtual StockProductDJCustomer StockProductDJCustomer { get; set; }
    }
}
