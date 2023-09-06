using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class BungaBank
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Keterangan { get; set; }
        public decimal? Persen { get; set; }
    }
}
