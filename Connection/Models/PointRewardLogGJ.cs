using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PointRewardLogGJ
    {
        public int Id { get; set; }
        public int Idmaster { get; set; }
        public DateTime Tgl { get; set; }
        public string Approval { get; set; }
        public decimal RupiahLama { get; set; }
        public decimal RupiahBaru { get; set; }

        public virtual PointRewardGJ PointRewardGJ { get; set; }
    }
}
