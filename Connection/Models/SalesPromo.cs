using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class SalesPromo
    {
        public int Id { get; set; }
        public int? IdsalesOrder { get; set; }
        public int? Idpromo { get; set; }
    }
}
