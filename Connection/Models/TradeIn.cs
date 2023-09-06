using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class TradeIn
    {
        public int Id { get; set; }
        public int? Idcustomer { get; set; }
        public string CustomerNama { get; set; }
        public int? Idsales { get; set; }
        public string SalesNama { get; set; }
        //public int? Idsales2 { get; set; }
        public string SalesNama2 { get; set; }
        public int? IdsalesOrder { get; set; }
        public int? Idresell { get; set; }
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
        public int? StatusVoid { get; set; }
        public string KodeCustomerLama { get; set; }

        public virtual DataCustomer DataCustomer { get; set; }
        public virtual Resell Resell { get; set; }
        public virtual DataSales DataSales { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
    }
}
