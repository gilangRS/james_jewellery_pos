using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DataSales
    {
        public DataSales()
        {
            DocRepairResults = new HashSet<DocRepairResult>();
            DocRepairs = new HashSet<DocRepair>();
            DocTitipans = new HashSet<DocTitipan>();
            Resells = new HashSet<Resell>();
            SalesOrders = new HashSet<SalesOrder>();
            SalesOrderRepairs = new HashSet<SalesOrderRepair>();
            SalesReceiptDPPOs = new HashSet<SalesReceiptDPPO>();
            TradeIns = new HashSet<TradeIn>();
        }

        public int Id { get; set; }
        public int Idgroup { get; set; }
        public int Idbrand { get; set; }
        public string Nama { get; set; }
        public string Keterangan { get; set; }
        public DateTime Tgl { get; set; }
        public bool Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public bool Disable { get; set; }
        public string AddrAlamat { get; set; }
        public string AddrNoTelp { get; set; }
        public string AddrNoFax { get; set; }
        public string AddrEmail { get; set; }
        public string ImgPicture { get; set; }
        public int? Iduser { get; set; }
        public string Nik { get; set; }

        public virtual CompanyBrand CompanyBrand { get; set; }
        public virtual DataSalesGroup DataSalesGroup { get; set; }
        public virtual ICollection<DocRepairResult> DocRepairResults { get; set; }
        public virtual ICollection<DocRepair> DocRepairs { get; set; }
        public virtual ICollection<DocTitipan> DocTitipans { get; set; }
        public virtual ICollection<Resell> Resells { get; set; }
        public virtual ICollection<SalesOrder> SalesOrders { get; set; }
        public virtual ICollection<SalesOrderRepair> SalesOrderRepairs { get; set; }
        public virtual ICollection<SalesReceiptDPPO> SalesReceiptDPPOs { get; set; }
        public virtual ICollection<TradeIn> TradeIns { get; set; }
    }
}
