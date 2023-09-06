using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DocRepairResult
    {
        public DocRepairResult()
        {
            DocRepairLog_Stone4s = new HashSet<DocRepairLog_Stone4>();
            DocRepairResult_Repairs = new HashSet<DocRepairResult_Repair>();
            DocRepairResult_Stone1As = new HashSet<DocRepairResult_Stone1A>();
            DocRepairResult_Stone1Bs = new HashSet<DocRepairResult_Stone1B>();
            DocRepairResult_Stone2s = new HashSet<DocRepairResult_Stone2>();
            DocRepairResult_Stone3s = new HashSet<DocRepairResult_Stone3>();
            DocRepairResult_Stone4s = new HashSet<DocRepairResult_Stone4>();
            DocRepairResult_Stone5s = new HashSet<DocRepairResult_Stone5>();
            DocRepairResult_StoneRepairs = new HashSet<DocRepairResult_StoneRepair>();
            SalesOrderRepairs = new HashSet<SalesOrderRepair>();
            SalesReceipts = new HashSet<SalesReceipt>();
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
        public int? Idproduct { get; set; }
        public int? StatusRepair { get; set; }
        public string ImgPicture { get; set; }
        public int? IdworkOrder { get; set; }
        public decimal? TotalHarga { get; set; }
        public int? Sumber { get; set; }
        public int? IdproductTitipan { get; set; }
        public int? IdnoteRepair { get; set; }
        public string NomorTerima { get; set; }

        public virtual DataCustomer DataCustomer { get; set; }
        public virtual StockProductDJ StockProductDJ { get; set; }
        public virtual StockProductDJCustomer StockProductDJCustomer { get; set; }
        public virtual DataSales DataSales { get; set; }
        public virtual DocRepair DocRepair { get; set; }
        public virtual DocRepairResult_CharProduct DocRepairResult_CharProduct { get; set; }
        public virtual ICollection<DocRepairLog_Stone4> DocRepairLog_Stone4s { get; set; }
        public virtual ICollection<DocRepairResult_Repair> DocRepairResult_Repairs { get; set; }
        public virtual ICollection<DocRepairResult_Stone1A> DocRepairResult_Stone1As { get; set; }
        public virtual ICollection<DocRepairResult_Stone1B> DocRepairResult_Stone1Bs { get; set; }
        public virtual ICollection<DocRepairResult_Stone2> DocRepairResult_Stone2s { get; set; }
        public virtual ICollection<DocRepairResult_Stone3> DocRepairResult_Stone3s { get; set; }
        public virtual ICollection<DocRepairResult_Stone4> DocRepairResult_Stone4s { get; set; }
        public virtual ICollection<DocRepairResult_Stone5> DocRepairResult_Stone5s { get; set; }
        public virtual ICollection<DocRepairResult_StoneRepair> DocRepairResult_StoneRepairs { get; set; }
        public virtual ICollection<SalesOrderRepair> SalesOrderRepairs { get; set; }
        public virtual ICollection<SalesReceipt> SalesReceipts { get; set; }
    }
}
