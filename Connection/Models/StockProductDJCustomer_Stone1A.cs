using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockProductDJCustomer_Stone1A
    {
        public StockProductDJCustomer_Stone1A()
        {
            DocQCDJCustomer_Stone1As = new HashSet<DocQCDJCustomer_Stone1A>();
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
        public virtual ICollection<DocQCDJCustomer_Stone1A> DocQCDJCustomer_Stone1As { get; set; }
    }
}
