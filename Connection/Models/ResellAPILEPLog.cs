using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class ResellAPILEPLog
    {
        public int Id { get; set; }
        public int? Idresell { get; set; }
        public string KodeCustomer { get; set; }
        public string NamaCustomer { get; set; }
        public string Plu { get; set; }
        public decimal? Weight { get; set; }
        public int? Status { get; set; }
        public string Message { get; set; }
        public string IdtransactionLe { get; set; }
    }
}
