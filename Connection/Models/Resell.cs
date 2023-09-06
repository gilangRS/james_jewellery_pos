using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class Resell
    {
        public Resell()
        {
            ResellDjs = new HashSet<ResellDJ>();
            ResellGjs = new HashSet<ResellGJ>();
            ResellLds = new HashSet<ResellLD>();
            ResellPgs = new HashSet<ResellPG>();
            TradeIns = new HashSet<TradeIn>();
        }

        public int Id { get; set; }
        public int? Idcustomer { get; set; }
        public string CustomerNama { get; set; }
        public int TipeLokasi { get; set; }
        public int Idlokasi { get; set; }
        public bool Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public string Nomor { get; set; }
        public decimal? TotalHarga { get; set; }
        public DateTime? Tgl { get; set; }
        public string Keterangan { get; set; }
        public DateTime OperatorTgl { get; set; }
        public string OperatorNama { get; set; }
        public bool? TradeIn { get; set; }
        public int? StatusVoid { get; set; }
        public int? Idsales { get; set; }
        public string SalesNama { get; set; }
        public string VoidKeterangan { get; set; }
        public string KodeCustomerLama { get; set; }
        public string GroupResell { get; set; }

        public virtual DataCustomer IdcustomerNavigation { get; set; }
        public virtual DataSales IdsalesNavigation { get; set; }
        public virtual ICollection<ResellDJ> ResellDjs { get; set; }
        public virtual ICollection<ResellGJ> ResellGjs { get; set; }
        public virtual ICollection<ResellLD> ResellLds { get; set; }
        public virtual ICollection<ResellPG> ResellPgs { get; set; }
        public virtual ICollection<TradeIn> TradeIns { get; set; }
    }
}
