using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockProductDJCustomer
    {
        public StockProductDJCustomer()
        {
            DocQCDJCustomers = new HashSet<DocQCDJCustomer>();
            DocRepairResults = new HashSet<DocRepairResult>();
            DocRepairs = new HashSet<DocRepair>();
            DocTitipan_Products = new HashSet<DocTitipan_Product>();
            StockProductDJCustomer_Stone1As = new HashSet<StockProductDJCustomer_Stone1A>();
            StockProductDJCustomer_Stone1Bs = new HashSet<StockProductDJCustomer_Stone1B>();
            StockProductDJCustomer_Stone2s = new HashSet<StockProductDJCustomer_Stone2>();
            StockProductDJCustomer_Stone3s = new HashSet<StockProductDJCustomer_Stone3>();
            StockProductDJCustomer_Stone4s = new HashSet<StockProductDJCustomer_Stone4>();
            StockProductDJCustomer_Stone5s = new HashSet<StockProductDJCustomer_Stone5>();
        }

        public int Id { get; set; }
        public string Keterangan { get; set; }
        public DateTime? Tgl { get; set; }
        public string Nomor { get; set; }
        public bool? Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }
        public string ImgPicture { get; set; }

        public virtual StockProductDJCustomer_CharProduct StockProductDJCustomer_CharProduct { get; set; }
        public virtual ICollection<DocQCDJCustomer> DocQCDJCustomers { get; set; }
        public virtual ICollection<DocRepairResult> DocRepairResults { get; set; }
        public virtual ICollection<DocRepair> DocRepairs { get; set; }
        public virtual ICollection<DocTitipan_Product> DocTitipan_Products { get; set; }
        public virtual ICollection<StockProductDJCustomer_Stone1A> StockProductDJCustomer_Stone1As { get; set; }
        public virtual ICollection<StockProductDJCustomer_Stone1B> StockProductDJCustomer_Stone1Bs { get; set; }
        public virtual ICollection<StockProductDJCustomer_Stone2> StockProductDJCustomer_Stone2s { get; set; }
        public virtual ICollection<StockProductDJCustomer_Stone3> StockProductDJCustomer_Stone3s { get; set; }
        public virtual ICollection<StockProductDJCustomer_Stone4> StockProductDJCustomer_Stone4s { get; set; }
        public virtual ICollection<StockProductDJCustomer_Stone5> StockProductDJCustomer_Stone5s { get; set; }
    }
}
