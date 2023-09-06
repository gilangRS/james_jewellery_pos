using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class LocWarehouse
    {
        public LocWarehouse()
        {
            RevalProductDJs = new HashSet<RevalProductDJ>();
            RevalProductGJs = new HashSet<RevalProductGJ>();
            StockProductDJs = new HashSet<StockProductDJ>();
            StockProductGJs = new HashSet<StockProductGJ>();
            StockProductLDs = new HashSet<StockProductLD>();
            StockProductMountings = new HashSet<StockProductMounting>();
            StockProductPGs = new HashSet<StockProductPG>();
            StockReceiveDJs = new HashSet<StockReceiveDJ>();
            StockReceiveGJs = new HashSet<StockReceiveGJ>();
            StockReceiveLDs = new HashSet<StockReceiveLD>();
            StockReceiveMountings = new HashSet<StockReceiveMounting>();
            StockReceivePackagings = new HashSet<StockReceivePackaging>();
            StockReceiveCetakans = new HashSet<StockReceiveCetakan>();
            StockReceivePgs = new HashSet<StockReceivePG>();
            StockReceiveSouvenirs = new HashSet<StockReceiveSouvenir>();
            StockReturnDJs = new HashSet<StockReturnDJ>();
            StockReturnGJs = new HashSet<StockReturnGJ>();
            StockReturnLDs = new HashSet<StockReturnLD>();
            StockReturnPGs = new HashSet<StockReturnPG>();
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

        public virtual CompanyBrand CompanyBrand { get; set; }
        public virtual LocWarehouseGroup LocWarehouseGroup { get; set; }
        public virtual ICollection<RevalProductDJ> RevalProductDJs { get; set; }
        public virtual ICollection<RevalProductGJ> RevalProductGJs { get; set; }
        public virtual ICollection<StockProductDJ> StockProductDJs { get; set; }
        public virtual ICollection<StockProductGJ> StockProductGJs { get; set; }
        public virtual ICollection<StockProductLD> StockProductLDs { get; set; }
        public virtual ICollection<StockProductMounting> StockProductMountings { get; set; }
        public virtual ICollection<StockProductPG> StockProductPGs { get; set; }
        public virtual ICollection<StockReceiveDJ> StockReceiveDJs { get; set; }
        public virtual ICollection<StockReceiveGJ> StockReceiveGJs { get; set; }
        public virtual ICollection<StockReceiveLD> StockReceiveLDs { get; set; }
        public virtual ICollection<StockReceiveMounting> StockReceiveMountings { get; set; }
        public virtual ICollection<StockReceivePackaging> StockReceivePackagings { get; set; }
        public virtual ICollection<StockReceiveCetakan> StockReceiveCetakans { get; set; }
        public virtual ICollection<StockReceivePG> StockReceivePgs { get; set; }
        public virtual ICollection<StockReceiveSouvenir> StockReceiveSouvenirs { get; set; }
        public virtual ICollection<StockReturnDJ> StockReturnDJs { get; set; }
        public virtual ICollection<StockReturnGJ> StockReturnGJs { get; set; }
        public virtual ICollection<StockReturnLD> StockReturnLDs { get; set; }
        public virtual ICollection<StockReturnPG> StockReturnPGs { get; set; }
    }
}
