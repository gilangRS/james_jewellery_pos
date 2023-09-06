using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockBasic
    {
        public int Id { get; set; }
        public string ProtoNomor { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
    }
}
