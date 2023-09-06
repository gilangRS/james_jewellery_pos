using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockProductDJCustomer_Stone4
    {
        public StockProductDJCustomer_Stone4()
        {
            DocQCDJCustomer_Stone4s = new HashSet<DocQCDJCustomer_Stone4>();
        }

        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idstone { get; set; }
        public int TotalButir { get; set; }
        public decimal TotalCarat { get; set; }
        public decimal CaratButir { get; set; }
        public decimal DimensiP { get; set; }
        public decimal? DimensiL { get; set; }
        public decimal? DimensiT { get; set; }

        public virtual StockProductDJCustomer StockProductDJCustomer { get; set; }
        public virtual ICollection<DocQCDJCustomer_Stone4> DocQCDJCustomer_Stone4s { get; set; }
    }
}
