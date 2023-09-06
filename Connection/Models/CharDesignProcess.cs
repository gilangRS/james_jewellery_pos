using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class CharDesignProcess
    {
        public CharDesignProcess()
        {
            KodeKaretDJ_CharDesigns = new HashSet<KodeKaretDJ_CharDesign>();
            KodeKaretGJ_CharDesigns = new HashSet<KodeKaretGJ_CharDesign>();
            ProductDesign_CharDesigns = new HashSet<ProductDesign_CharDesign>();
            ProductDesignGJ_CharDesigns = new HashSet<ProductDesignGJ_CharDesign>();
            ProductOrder_CharDesigns = new HashSet<ProductOrder_CharDesign>();
            ProductOrderGJ_CharDesigns = new HashSet<ProductOrderGJ_CharDesign>();
            RevalLogReceiveDJ_CharDesigns = new HashSet<RevalLogReceiveDJ_CharDesign>();
            RevalProductDJ_CharDesigns = new HashSet<RevalProductDJ_CharDesign>();
            RevalProductGJ_CharDesigns = new HashSet<RevalProductGJ_CharDesign>();
            RevalReceiveDJ_CharDesigns = new HashSet<RevalReceiveDJ_CharDesign>();
            StockProductDJ_CharDesigns = new HashSet<StockProductDJ_CharDesign>();
            StockProductGJ_CharDesigns = new HashSet<StockProductGJ_CharDesign>();
            StockProductLD_CharDesigns = new HashSet<StockProductLD_CharDesign>();
            StockProductMounting_CharDesigns = new HashSet<StockProductMounting_CharDesign>();
            StockReceiveDJ_CharDesigns = new HashSet<StockReceiveDJ_CharDesign>();
            StockReceiveGJ_CharDesigns = new HashSet<StockReceiveGJ_CharDesign>();
            StockReceiveLD_CharDesigns = new HashSet<StockReceiveLD_CharDesign>();
            StockReceiveMounting_CharDesigns = new HashSet<StockReceiveMounting_CharDesign>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string NamaKode { get; set; }
        public string Keterangan { get; set; }
        public int Sn { get; set; }
        public bool Disable { get; set; }

        public virtual ICollection<KodeKaretDJ_CharDesign> KodeKaretDJ_CharDesigns { get; set; }
        public virtual ICollection<KodeKaretGJ_CharDesign> KodeKaretGJ_CharDesigns { get; set; }
        public virtual ICollection<ProductDesign_CharDesign> ProductDesign_CharDesigns { get; set; }
        public virtual ICollection<ProductDesignGJ_CharDesign> ProductDesignGJ_CharDesigns { get; set; }
        public virtual ICollection<ProductOrder_CharDesign> ProductOrder_CharDesigns { get; set; }
        public virtual ICollection<ProductOrderGJ_CharDesign> ProductOrderGJ_CharDesigns { get; set; }
        public virtual ICollection<RevalLogReceiveDJ_CharDesign> RevalLogReceiveDJ_CharDesigns { get; set; }
        public virtual ICollection<RevalProductDJ_CharDesign> RevalProductDJ_CharDesigns { get; set; }
        public virtual ICollection<RevalProductGJ_CharDesign> RevalProductGJ_CharDesigns { get; set; }
        public virtual ICollection<RevalReceiveDJ_CharDesign> RevalReceiveDJ_CharDesigns { get; set; }
        public virtual ICollection<StockProductDJ_CharDesign> StockProductDJ_CharDesigns { get; set; }
        public virtual ICollection<StockProductGJ_CharDesign> StockProductGJ_CharDesigns { get; set; }
        public virtual ICollection<StockProductLD_CharDesign> StockProductLD_CharDesigns { get; set; }
        public virtual ICollection<StockProductMounting_CharDesign> StockProductMounting_CharDesigns { get; set; }
        public virtual ICollection<StockReceiveDJ_CharDesign> StockReceiveDJ_CharDesigns { get; set; }
        public virtual ICollection<StockReceiveGJ_CharDesign> StockReceiveGJ_CharDesigns { get; set; }
        public virtual ICollection<StockReceiveLD_CharDesign> StockReceiveLD_CharDesigns { get; set; }
        public virtual ICollection<StockReceiveMounting_CharDesign> StockReceiveMounting_CharDesigns { get; set; }
    }
}
