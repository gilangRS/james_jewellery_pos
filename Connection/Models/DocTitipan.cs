using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DocTitipan
    {
        public DocTitipan()
        {
            DocTitipan_Products = new HashSet<DocTitipan_Product>();
        }

        public int Id { get; set; }
        public string Nomor { get; set; }
        public DateTime? Tgl { get; set; }
        public int? TipeLokasi { get; set; }
        public int? Idlokasi { get; set; }
        public int? Idcustomer { get; set; }
        public int? Idsales { get; set; }
        public string SalesNama { get; set; }
        public string CustomerNama { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public bool? Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public DateTime? TglSelesai { get; set; }
        public string Keterangan { get; set; }
        public int? StatusTitipan { get; set; }

        public virtual DataCustomer DataCustomer { get; set; }
        public virtual DataSales DataSales { get; set; }
        public virtual ICollection<DocTitipan_Product> DocTitipan_Products { get; set; }
    }
}
