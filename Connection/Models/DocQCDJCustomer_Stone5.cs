using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DocQCDJCustomer_Stone5
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idstone { get; set; }
        public string Keterangan { get; set; }

        public virtual DocQCDJCustomer DocQCDJCustomer { get; set; }
        public virtual StockProductDJCustomer_Stone5 StockProductDJCustomer_Stone5 { get; set; }
    }
}
