using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PointRewardLogDJ
    {
        public int Id { get; set; }
        public int Idmaster { get; set; }
        public DateTime Tgl { get; set; }
        public string Approval { get; set; }
        public decimal RupiahLama { get; set; }
        public decimal RupiahBaru { get; set; }

        public virtual PointRewardDJ PointRewardDJ { get; set; }
    }
}
