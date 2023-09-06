using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class CharProcessFinishing
    {
        public CharProcessFinishing()
        {
            CalculatorProductDJ_Finishings = new HashSet<CalculatorProductDJ_Finishing>();
            KodeKaretDJ_Finishings = new HashSet<KodeKaretDJ_Finishing>();
            KodeKaretGJ_Finishings = new HashSet<KodeKaretGJ_Finishing>();
            PricingTableFFs = new HashSet<PricingTableFF>();
            ProductDesign_Finishings = new HashSet<ProductDesign_Finishing>();
            ProductDesignGJ_Finishings = new HashSet<ProductDesignGJ_Finishing>();
            ProductOrder_Finishings = new HashSet<ProductOrder_Finishing>();
            ProductOrderGJ_Finishings = new HashSet<ProductOrderGJ_Finishing>();
            RevalLogProductDJ_Finishings = new HashSet<RevalLogProductDJ_Finishing>();
            RevalLogProductGJ_Finishings = new HashSet<RevalLogProductGJ_Finishing>();
            RevalProductDJ_Finishings = new HashSet<RevalProductDJ_Finishing>();
            RevalProductGJ_Finishings = new HashSet<RevalProductGJ_Finishing>();
            StockProductDJ_Finishings = new HashSet<StockProductDJ_Finishing>();
            StockProductGJ_Finishings = new HashSet<StockProductGJ_Finishing>();
            StockProductMounting_Finishings = new HashSet<StockProductMounting_Finishing>();
            StockReceiveDJ_Finishings = new HashSet<StockReceiveDJ_Finishing>();
            StockReceiveGJ_Finishings = new HashSet<StockReceiveGJ_Finishing>();
            StockReceiveMounting_Finishings = new HashSet<StockReceiveMounting_Finishing>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string NamaKode { get; set; }
        public string Keterangan { get; set; }
        public int Sn { get; set; }
        public bool Disable { get; set; }

        public virtual ICollection<CalculatorProductDJ_Finishing> CalculatorProductDJ_Finishings { get; set; }
        public virtual ICollection<KodeKaretDJ_Finishing> KodeKaretDJ_Finishings { get; set; }
        public virtual ICollection<KodeKaretGJ_Finishing> KodeKaretGJ_Finishings { get; set; }
        public virtual ICollection<PricingTableFF> PricingTableFFs { get; set; }
        public virtual ICollection<ProductDesign_Finishing> ProductDesign_Finishings { get; set; }
        public virtual ICollection<ProductDesignGJ_Finishing> ProductDesignGJ_Finishings { get; set; }
        public virtual ICollection<ProductOrder_Finishing> ProductOrder_Finishings { get; set; }
        public virtual ICollection<ProductOrderGJ_Finishing> ProductOrderGJ_Finishings { get; set; }
        public virtual ICollection<RevalLogProductDJ_Finishing> RevalLogProductDJ_Finishings { get; set; }
        public virtual ICollection<RevalLogProductGJ_Finishing> RevalLogProductGJ_Finishings { get; set; }
        public virtual ICollection<RevalProductDJ_Finishing> RevalProductDJ_Finishings { get; set; }
        public virtual ICollection<RevalProductGJ_Finishing> RevalProductGJ_Finishings { get; set; }
        public virtual ICollection<StockProductDJ_Finishing> StockProductDJ_Finishings { get; set; }
        public virtual ICollection<StockProductGJ_Finishing> StockProductGJ_Finishings { get; set; }
        public virtual ICollection<StockProductMounting_Finishing> StockProductMounting_Finishings { get; set; }
        public virtual ICollection<StockReceiveDJ_Finishing> StockReceiveDJ_Finishings { get; set; }
        public virtual ICollection<StockReceiveGJ_Finishing> StockReceiveGJ_Finishings { get; set; }
        public virtual ICollection<StockReceiveMounting_Finishing> StockReceiveMounting_Finishings { get; set; }
    }
}
