using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class CompanyBrand
    {
        public CompanyBrand()
        {
            CrossBrandStockOutgoingDJ_BrarandAsals = new HashSet<CrossBrand_StockOutgoingDJ>();
            CrossBrandStockOutgoingDJ_BrandTujuans = new HashSet<CrossBrand_StockOutgoingDJ>();
            CrossBrandStockOutgoingPG_BrandAsals = new HashSet<CrossBrand_StockOutgoingPG>();
            CrossBrandStockOutgoingPG_BrandTujuans = new HashSet<CrossBrand_StockOutgoingPG>();
            CrossBrandStockOutgoingLD_BrandAsals = new HashSet<CrossBrand_StockOutgoingLD>();
            CrossBrandStockOutgoingLD_BrandTujuans = new HashSet<CrossBrand_StockOutgoingLD>();
            DataCustomers = new HashSet<DataCustomer>();
            DataHumans = new HashSet<DataHuman>();
            DataSales = new HashSet<DataSales>();
            DataSuppliers = new HashSet<DataSupplier>();
            DataVouchers = new HashSet<DataVoucher>();
            KodeKaretDjs = new HashSet<KodeKaretDJ>();
            KodeKaretGjs = new HashSet<KodeKaretGJ>();
            LocExhibitions = new HashSet<LocExhibition>();
            LocOutlets = new HashSet<LocOutlet>();
            LocWarehouses = new HashSet<LocWarehouse>();
            Packagings = new HashSet<Packaging>();
            Cetakans = new HashSet<Cetakan>();
            PricingTableFMs = new HashSet<PricingTableFM>();
            ProductOrderGJs = new HashSet<ProductOrderGJ>();
            ProductOrders = new HashSet<ProductOrder>();
            ProductStoneRequests = new HashSet<ProductStoneRequest>();
            Souvenirs = new HashSet<Souvenir>();
            StockActualDJs = new HashSet<StockActualDJ>();
            StockActualGJs = new HashSet<StockActualGJ>();
            StockActualLD_Stone1Bs = new HashSet<StockActualLD_Stone1B>();
            StockActualLDs = new HashSet<StockActualLD>();
            StockActualMountings = new HashSet<StockActualMounting>();
            StockActualPGs = new HashSet<StockActualPG>();
            StockOutgoingDJs = new HashSet<StockOutgoingDJ>();
            StockOutgoingGJs = new HashSet<StockOutgoingGJ>();
            StockOutgoingLDs = new HashSet<StockOutgoingLD>();
            StockOutgoingPackagings = new HashSet<StockOutgoingPackaging>();
            StockOutgoingCetakans = new HashSet<StockOutgoingCetakan>();
            StockOutgoingPGs = new HashSet<StockOutgoingPG>();
            StockOutgoingSouvenirs = new HashSet<StockOutgoingSouvenir>();
            StockProductPGs = new HashSet<StockProductPG>();
            StockReturnDJs = new HashSet<StockReturnDJ>();
            StockReturnGJs = new HashSet<StockReturnGJ>();
            StockReturnLDs = new HashSet<StockReturnLD>();
            StockReturnPGs = new HashSet<StockReturnPG>();
        }

        public int Id { get; set; }
        public int Idcompany { get; set; }
        public string Nama { get; set; }
        public string NamaKode { get; set; }
        public string Keterangan { get; set; }
        public int Sn { get; set; }
        public bool Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public bool Disable { get; set; }
        public string AddrAlamat { get; set; }
        public string AddrNoTelp { get; set; }
        public string AddrNoFax { get; set; }
        public string AddrEmail { get; set; }
        public string ImgLogo { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<CrossBrand_StockOutgoingDJ> CrossBrandStockOutgoingDJ_BrarandAsals { get; set; }
        public virtual ICollection<CrossBrand_StockOutgoingDJ> CrossBrandStockOutgoingDJ_BrandTujuans { get; set; }
        public virtual ICollection<CrossBrand_StockOutgoingPG> CrossBrandStockOutgoingPG_BrandAsals { get; set; }
        public virtual ICollection<CrossBrand_StockOutgoingPG> CrossBrandStockOutgoingPG_BrandTujuans { get; set; }
        public virtual ICollection<CrossBrand_StockOutgoingLD> CrossBrandStockOutgoingLD_BrandAsals { get; set; }
        public virtual ICollection<CrossBrand_StockOutgoingLD> CrossBrandStockOutgoingLD_BrandTujuans { get; set; }
        public virtual ICollection<DataCustomer> DataCustomers { get; set; }
        public virtual ICollection<DataHuman> DataHumans { get; set; }
        public virtual ICollection<DataSales> DataSales { get; set; }
        public virtual ICollection<DataSupplier> DataSuppliers { get; set; }
        public virtual ICollection<DataVoucher> DataVouchers { get; set; }
        public virtual ICollection<KodeKaretDJ> KodeKaretDjs { get; set; }
        public virtual ICollection<KodeKaretGJ> KodeKaretGjs { get; set; }
        public virtual ICollection<LocExhibition> LocExhibitions { get; set; }
        public virtual ICollection<LocOutlet> LocOutlets { get; set; }
        public virtual ICollection<LocWarehouse> LocWarehouses { get; set; }
        public virtual ICollection<Packaging> Packagings { get; set; }
        public virtual ICollection<Cetakan> Cetakans { get; set; }
        public virtual ICollection<PricingTableFM> PricingTableFMs { get; set; }
        public virtual ICollection<ProductOrderGJ> ProductOrderGJs { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        public virtual ICollection<ProductStoneRequest> ProductStoneRequests { get; set; }
        public virtual ICollection<Souvenir> Souvenirs { get; set; }
        public virtual ICollection<StockActualDJ> StockActualDJs { get; set; }
        public virtual ICollection<StockActualGJ> StockActualGJs { get; set; }
        public virtual ICollection<StockActualLD_Stone1B> StockActualLD_Stone1Bs { get; set; }
        public virtual ICollection<StockActualLD> StockActualLDs { get; set; }
        public virtual ICollection<StockActualMounting> StockActualMountings { get; set; }
        public virtual ICollection<StockActualPG> StockActualPGs { get; set; }
        public virtual ICollection<StockOutgoingDJ> StockOutgoingDJs { get; set; }
        public virtual ICollection<StockOutgoingGJ> StockOutgoingGJs { get; set; }
        public virtual ICollection<StockOutgoingLD> StockOutgoingLDs { get; set; }
        public virtual ICollection<StockOutgoingPackaging> StockOutgoingPackagings { get; set; }
        public virtual ICollection<StockOutgoingCetakan> StockOutgoingCetakans { get; set; }
        public virtual ICollection<StockOutgoingPG> StockOutgoingPGs { get; set; }
        public virtual ICollection<StockOutgoingSouvenir> StockOutgoingSouvenirs { get; set; }
        public virtual ICollection<StockProductPG> StockProductPGs { get; set; }
        public virtual ICollection<StockReturnDJ> StockReturnDJs { get; set; }
        public virtual ICollection<StockReturnGJ> StockReturnGJs { get; set; }
        public virtual ICollection<StockReturnLD> StockReturnLDs { get; set; }
        public virtual ICollection<StockReturnPG> StockReturnPGs { get; set; }
    }
}
