using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PricingLogFF
    {
        public int Id { get; set; }
        public int Idmaster { get; set; }
        public DateTime Tgl { get; set; }
        public string Approval { get; set; }
        public decimal BiayaLama { get; set; }
        public decimal BiayaBaru { get; set; }

        public virtual PricingTableFF PricingTableFF { get; set; }
    }
}
