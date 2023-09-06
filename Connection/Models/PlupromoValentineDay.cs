using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PLUPromoValentineDay
    {
        public int Id { get; set; }
        public string Nomor { get; set; }
        public DateTime? Tgl { get; set; }
        public DateTime? TglStart { get; set; }
        public DateTime? TglEnd { get; set; }
        public decimal? Discount { get; set; }
        public string Brand { get; set; }
    }
}
