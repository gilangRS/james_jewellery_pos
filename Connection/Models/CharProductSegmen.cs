using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class CharProductSegmen
    {
        public CharProductSegmen()
        {
            BudgetStocks = new HashSet<BudgetStock>();
            KodeKaretDJs = new HashSet<KodeKaretDJ>();
            KodeKaretGJs = new HashSet<KodeKaretGJ>();
            PricingTableSSes = new HashSet<PricingTableSS>();
            ProductDesignGJ_PricingSegmens = new HashSet<ProductDesignGJ_PricingSegmen>();
            ProductDesign_PricingSegmens = new HashSet<ProductDesign_PricingSegmen>();
            ProductOrderGJs = new HashSet<ProductOrderGJ>();
            ProductOrder_PricingSegmens = new HashSet<ProductOrder_PricingSegmen>();
            ProductOrders = new HashSet<ProductOrder>();
            RevalLogProductDJ_PricingSegmens = new HashSet<RevalLogProductDJ_PricingSegmen>();
            RevalLogProductGJ_PricingSegmens = new HashSet<RevalLogProductGJ_PricingSegmen>();
            RevalProductDJ_PricingSegmens = new HashSet<RevalProductDJ_PricingSegmen>();
            RevalProductGJ_PricingSegmens = new HashSet<RevalProductGJ_PricingSegmen>();
            StockProductDJ_PricingSegmens = new HashSet<StockProductDJ_PricingSegmen>();
            StockProductGJ_PricingSegmens = new HashSet<StockProductGJ_PricingSegmen>();
            StockProductMounting_PricingSegmens = new HashSet<StockProductMounting_PricingSegmen>();
            StockReceiveDJ_PricingSegmens = new HashSet<StockReceiveDJ_PricingSegmen>();
            StockReceiveGJ_PricingSegmens = new HashSet<StockReceiveGJ_PricingSegmen>();
            StockReceiveMounting_PricingSegmens = new HashSet<StockReceiveMounting_PricingSegmen>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string NamaKode { get; set; }
        public string Keterangan { get; set; }
        public int Sn { get; set; }
        public bool Disable { get; set; }

        public virtual ICollection<BudgetStock> BudgetStocks { get; set; }
        public virtual ICollection<KodeKaretDJ> KodeKaretDJs { get; set; }
        public virtual ICollection<KodeKaretGJ> KodeKaretGJs { get; set; }
        public virtual ICollection<PricingTableSS> PricingTableSSes { get; set; }
        public virtual ICollection<ProductDesignGJ_PricingSegmen> ProductDesignGJ_PricingSegmens { get; set; }
        public virtual ICollection<ProductDesign_PricingSegmen> ProductDesign_PricingSegmens { get; set; }
        public virtual ICollection<ProductOrderGJ> ProductOrderGJs { get; set; }
        public virtual ICollection<ProductOrder_PricingSegmen> ProductOrder_PricingSegmens { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
        public virtual ICollection<RevalLogProductDJ_PricingSegmen> RevalLogProductDJ_PricingSegmens { get; set; }
        public virtual ICollection<RevalLogProductGJ_PricingSegmen> RevalLogProductGJ_PricingSegmens { get; set; }
        public virtual ICollection<RevalProductDJ_PricingSegmen> RevalProductDJ_PricingSegmens { get; set; }
        public virtual ICollection<RevalProductGJ_PricingSegmen> RevalProductGJ_PricingSegmens { get; set; }
        public virtual ICollection<StockProductDJ_PricingSegmen> StockProductDJ_PricingSegmens { get; set; }
        public virtual ICollection<StockProductGJ_PricingSegmen> StockProductGJ_PricingSegmens { get; set; }
        public virtual ICollection<StockProductMounting_PricingSegmen> StockProductMounting_PricingSegmens { get; set; }
        public virtual ICollection<StockReceiveDJ_PricingSegmen> StockReceiveDJ_PricingSegmens { get; set; }
        public virtual ICollection<StockReceiveGJ_PricingSegmen> StockReceiveGJ_PricingSegmens { get; set; }
        public virtual ICollection<StockReceiveMounting_PricingSegmen> StockReceiveMounting_PricingSegmens { get; set; }
    }
}
