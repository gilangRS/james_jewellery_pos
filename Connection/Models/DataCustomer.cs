using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DataCustomer
    {
        public DataCustomer()
        {
            DocRepairResults = new HashSet<DocRepairResult>();
            DocRepairs = new HashSet<DocRepair>();
            DocTitipans = new HashSet<DocTitipan>();
            Resells = new HashSet<Resell>();
            SalesOrder_Customers = new HashSet<SalesOrder>();
            SalesOrder_CustomerReferences = new HashSet<SalesOrder>();
            SalesOrderRepairs = new HashSet<SalesOrderRepair>();
            SalesReceiptDPPOs = new HashSet<SalesReceiptDPPO>();
            TradeIns = new HashSet<TradeIn>();
        }

        public int Id { get; set; }
        public int Idbrand { get; set; }
        public string Nama { get; set; }
        public string Keterangan { get; set; }
        public DateTime Tgl { get; set; }
        public bool Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public bool Disable { get; set; }
        public string NoCustomer { get; set; }
        public string NoMember { get; set; }
        public string NoNpwp { get; set; }
        public int? TipeCustomer { get; set; }
        public string AddrAlamat { get; set; }
        public string AddrNoTelp { get; set; }
        public string AddrNoFax { get; set; }
        public string AddrEmail { get; set; }
        public string PinBb { get; set; }
        public string ImgPicture { get; set; }
        public DateTime? TglLahir { get; set; }
        public int? Agama { get; set; }
        public bool? Prospect { get; set; }
        public string NamaPasangan { get; set; }
        public DateTime? TglLahirPasangan { get; set; }
        public DateTime? WeddingAnniversarry { get; set; }
        public string AddrNoTelp2 { get; set; }
        public string AddrNoTelp3 { get; set; }
        public string AddrMobile { get; set; }
        public decimal? RewardRemaining { get; set; }
        public decimal? RewardTaken { get; set; }
        public decimal? TotalReward { get; set; }
        public decimal? TotalPurchase { get; set; }

        public virtual CompanyBrand CompanyBrand { get; set; }
        public virtual ICollection<DocRepairResult> DocRepairResults { get; set; }
        public virtual ICollection<DocRepair> DocRepairs { get; set; }
        public virtual ICollection<DocTitipan> DocTitipans { get; set; }
        public virtual ICollection<Resell> Resells { get; set; }
        public virtual ICollection<SalesOrder> SalesOrder_Customers { get; set; }
        public virtual ICollection<SalesOrder> SalesOrder_CustomerReferences { get; set; }
        public virtual ICollection<SalesOrderRepair> SalesOrderRepairs { get; set; }
        public virtual ICollection<SalesReceiptDPPO> SalesReceiptDPPOs { get; set; }
        public virtual ICollection<TradeIn> TradeIns { get; set; }
    }
}
