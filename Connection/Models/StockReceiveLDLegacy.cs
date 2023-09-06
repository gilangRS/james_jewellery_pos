using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockReceiveLDLegacy
    {
        public int Id { get; set; }
        public string Plu { get; set; }
        public decimal M { get; set; }

        public virtual StockProductLD_Stone1B IdNavigation { get; set; }
    }
}
