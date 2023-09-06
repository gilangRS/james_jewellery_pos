using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class SalesOrderPGLEI
    {
        public int Id { get; set; }
        public int Idproduct { get; set; }
        public int IdsalesOrder { get; set; }
        public decimal? Tgpjual { get; set; }
        public decimal? Tgpbeli { get; set; }
        public DateTime? OperatorTgl { get; set; }
    }
}
