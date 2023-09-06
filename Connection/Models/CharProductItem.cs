using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class CharProductItem
    {
        public CharProductItem()
        {
            BudgetStocks = new HashSet<BudgetStock>();
            CalculatorProductDJ_CharProducts = new HashSet<CalculatorProductDJ_CharProduct>();
            DocRepair_CharProducts = new HashSet<DocRepair_CharProduct>();
            DocRepairResult_CharProducts = new HashSet<DocRepairResult_CharProduct>();
            KodeKaretCleansings = new HashSet<KodeKaretCleansing>();
            KodeKaretDJ_CharProducts = new HashSet<KodeKaretDJ_CharProduct>();
            KodeKaretGJ_CharProducts = new HashSet<KodeKaretGJ_CharProduct>();
            PricingTableFFs = new HashSet<PricingTableFF>();
            PricingTableFMs = new HashSet<PricingTableFM>();
            ProductDesign_CharProducts = new HashSet<ProductDesign_CharProduct>();
            ProductDesignGJ_CharProducts = new HashSet<ProductDesignGJ_CharProduct>();
            ProductOrder_CharProducts = new HashSet<ProductOrder_CharProduct>();
            ProductOrderGJ_CharProducts = new HashSet<ProductOrderGJ_CharProduct>();
            PromoDJ_Details = new HashSet<PromoDJ_Detail>();
            PromoGJ_Details = new HashSet<PromoGJ_Detail>();
            PromoPG_Details = new HashSet<PromoPG_Detail>();
            RevalLogProductDJ_CharProducts = new HashSet<RevalLogProductDJ_CharProduct>();
            RevalLogProductGJ_CharProducts = new HashSet<RevalLogProductGJ_CharProduct>();
            RevalProductDJ_CharProducts = new HashSet<RevalProductDJ_CharProduct>();
            RevalProductGJ_CharProducts = new HashSet<RevalProductGJ_CharProduct>();
            StockProductDJ_CharProducts = new HashSet<StockProductDJ_CharProduct>();
            StockProductDJCustomer_CharProducts = new HashSet<StockProductDJCustomer_CharProduct>();
            StockProductGJ_CharProducts = new HashSet<StockProductGJ_CharProduct>();
            StockProductMounting_CharProducts = new HashSet<StockProductMounting_CharProduct>();
            StockProductPGs = new HashSet<StockProductPG>();
            StockReceiveDJ_CharProducts = new HashSet<StockReceiveDJ_CharProduct>();
            StockReceiveGJ_CharProducts = new HashSet<StockReceiveGJ_CharProduct>();
            StockReceiveMounting_CharProducts = new HashSet<StockReceiveMounting_CharProduct>();
            StockReceivePGs = new HashSet<StockReceivePG>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string NamaKode { get; set; }
        public string Keterangan { get; set; }
        public int Sn { get; set; }
        public bool Disable { get; set; }

        public virtual ICollection<BudgetStock> BudgetStocks { get; set; }
        public virtual ICollection<CalculatorProductDJ_CharProduct> CalculatorProductDJ_CharProducts { get; set; }
        public virtual ICollection<DocRepair_CharProduct> DocRepair_CharProducts { get; set; }
        public virtual ICollection<DocRepairResult_CharProduct> DocRepairResult_CharProducts { get; set; }
        public virtual ICollection<KodeKaretCleansing> KodeKaretCleansings { get; set; }
        public virtual ICollection<KodeKaretDJ_CharProduct> KodeKaretDJ_CharProducts { get; set; }
        public virtual ICollection<KodeKaretGJ_CharProduct> KodeKaretGJ_CharProducts { get; set; }
        public virtual ICollection<PricingTableFF> PricingTableFFs { get; set; }
        public virtual ICollection<PricingTableFM> PricingTableFMs { get; set; }
        public virtual ICollection<ProductDesign_CharProduct> ProductDesign_CharProducts { get; set; }
        public virtual ICollection<ProductDesignGJ_CharProduct> ProductDesignGJ_CharProducts { get; set; }
        public virtual ICollection<ProductOrder_CharProduct> ProductOrder_CharProducts { get; set; }
        public virtual ICollection<ProductOrderGJ_CharProduct> ProductOrderGJ_CharProducts { get; set; }
        public virtual ICollection<PromoDJ_Detail> PromoDJ_Details { get; set; }
        public virtual ICollection<PromoGJ_Detail> PromoGJ_Details { get; set; }
        public virtual ICollection<PromoPG_Detail> PromoPG_Details { get; set; }
        public virtual ICollection<RevalLogProductDJ_CharProduct> RevalLogProductDJ_CharProducts { get; set; }
        public virtual ICollection<RevalLogProductGJ_CharProduct> RevalLogProductGJ_CharProducts { get; set; }
        public virtual ICollection<RevalProductDJ_CharProduct> RevalProductDJ_CharProducts { get; set; }
        public virtual ICollection<RevalProductGJ_CharProduct> RevalProductGJ_CharProducts { get; set; }
        public virtual ICollection<StockProductDJ_CharProduct> StockProductDJ_CharProducts { get; set; }
        public virtual ICollection<StockProductDJCustomer_CharProduct> StockProductDJCustomer_CharProducts { get; set; }
        public virtual ICollection<StockProductGJ_CharProduct> StockProductGJ_CharProducts { get; set; }
        public virtual ICollection<StockProductMounting_CharProduct> StockProductMounting_CharProducts { get; set; }
        public virtual ICollection<StockProductPG> StockProductPGs { get; set; }
        public virtual ICollection<StockReceiveDJ_CharProduct> StockReceiveDJ_CharProducts { get; set; }
        public virtual ICollection<StockReceiveGJ_CharProduct> StockReceiveGJ_CharProducts { get; set; }
        public virtual ICollection<StockReceiveMounting_CharProduct> StockReceiveMounting_CharProducts { get; set; }
        public virtual ICollection<StockReceivePG> StockReceivePGs { get; set; }
    }
}
