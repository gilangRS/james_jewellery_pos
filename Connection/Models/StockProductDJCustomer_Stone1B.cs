using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockProductDJCustomer_Stone1B
    {
        public StockProductDJCustomer_Stone1B()
        {
            DocQCDJCustomer_Stone1Bs = new HashSet<DocQCDJCustomer_Stone1B>();
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
        public string Gia { get; set; }

        public virtual StockProductDJCustomer StockProductDJCustomer { get; set; }
        public virtual ICollection<DocQCDJCustomer_Stone1B> DocQCDJCustomer_Stone1Bs { get; set; }
    }
}
