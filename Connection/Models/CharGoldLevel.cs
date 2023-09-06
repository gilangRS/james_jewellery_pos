using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class CharGoldLevel
    {
        public CharGoldLevel()
        {
            PromoPG_Details = new HashSet<PromoPG_Detail>();
            StockProductPGs = new HashSet<StockProductPG>();
            StockReceivePGs = new HashSet<StockReceivePG>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string NamaKode { get; set; }
        public string Keterangan { get; set; }
        public int Sn { get; set; }
        public bool Disable { get; set; }
        public int? Grup { get; set; }

        public virtual ICollection<PromoPG_Detail> PromoPG_Details { get; set; }
        public virtual ICollection<StockProductPG> StockProductPGs { get; set; }
        public virtual ICollection<StockReceivePG> StockReceivePGs { get; set; }
    }
}
