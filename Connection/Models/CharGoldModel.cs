using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class CharGoldModel
    {
        public CharGoldModel()
        {
            PromoPG_Details = new HashSet<PromoPG_Detail>();
            StockProductPGs = new HashSet<StockProductPG>();
            StockReceivePGs = new HashSet<StockReceivePG>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string NamaKode { get; set; }
        public decimal Margin { get; set; }
        public string Keterangan { get; set; }
        public int Sn { get; set; }
        public bool Disable { get; set; }

        public virtual ICollection<PromoPG_Detail> PromoPG_Details { get; set; }
        public virtual ICollection<StockProductPG> StockProductPGs { get; set; }
        public virtual ICollection<StockReceivePG> StockReceivePGs { get; set; }
    }
}
