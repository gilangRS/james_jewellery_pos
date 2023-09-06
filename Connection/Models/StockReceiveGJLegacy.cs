using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockReceiveGJLegacy
    {
        public int Id { get; set; }
        public string Plu { get; set; }
        public decimal M { get; set; }

        public virtual StockProductGJ IdNavigation { get; set; }
    }
}
