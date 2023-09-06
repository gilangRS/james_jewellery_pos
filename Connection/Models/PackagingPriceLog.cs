using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PackagingPriceLog
    {
        public PackagingPriceLog()
        {
           
        }

        public int Id { get; set; }
        public int IDForm { get; set; }
        public string Kode { get; set; }
        public decimal HargaLama { get; set; }
        public decimal HargaBaru { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }
    }
}
