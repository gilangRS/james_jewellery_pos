using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PricingLogUS
    {
        public int Id { get; set; }
        public int Idmaster { get; set; }
        public DateTime Tgl { get; set; }
        public string Approval { get; set; }
        public decimal HargaLama { get; set; }
        public decimal HargaBaru { get; set; }

        public virtual PricingTableUS PricingTableUS { get; set; }
    }
}
