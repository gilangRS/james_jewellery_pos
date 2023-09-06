using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockReceiveGJ_Finishing
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idfinishing { get; set; }
        public decimal? Biaya { get; set; }
        public decimal? BiayaModal { get; set; }
        public DateTime? Efektif { get; set; }

        public virtual CharProcessFinishing IdfinishingNavigation { get; set; }
        public virtual StockReceiveGJ IdformNavigation { get; set; }
    }
}
