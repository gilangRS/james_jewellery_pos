using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class RevalProductDJ
    {
        public RevalProductDJ()
        {
            RevalProductDJ_Finishings = new HashSet<RevalProductDJ_Finishing>();
            RevalProductDJ_Stone1As = new HashSet<RevalProductDJ_Stone1A>();
            RevalProductDJ_Stone1Bs = new HashSet<RevalProductDJ_Stone1B>();
            RevalProductDJ_Stone2s = new HashSet<RevalProductDJ_Stone2>();
            RevalProductDJ_Stone3s = new HashSet<RevalProductDJ_Stone3>();
            RevalProductDJ_Stone4s = new HashSet<RevalProductDJ_Stone4>();
            RevalProductDJ_Stone5s = new HashSet<RevalProductDJ_Stone5>();
        }

        public int Id { get; set; }
        public int? Idreval { get; set; }
        public int? Idwarehouse { get; set; }
        public int? Sumber { get; set; }
        public string Keterangan { get; set; }
        public DateTime? Tgl { get; set; }
        public string Nomor { get; set; }
        public bool? Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public int? Proto { get; set; }
        public string ProtoNomor { get; set; }
        public int? ProductOrder { get; set; }
        public string ProductOrderNomor { get; set; }
        public int? Supplier { get; set; }
        public string SupplierNama { get; set; }
        public string SupplierNomor { get; set; }
        public int? RequestOutlet { get; set; }
        public string RequestOutletNama { get; set; }
        public int? RequestCustomer { get; set; }
        public string RequestCustomerNama { get; set; }
        public int? HumanDesigner { get; set; }
        public string HumanDesginerNama { get; set; }
        public int? HumanStock { get; set; }
        public string HumanStockNama { get; set; }
        public DateTime? ExpiredProduct { get; set; }
        public DateTime? ExpiredRequest { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }
        public string CatatanManager { get; set; }
        public string ImgPicture { get; set; }

        public virtual RevalItemDJ RevalItemDJ { get; set; }
        public virtual LocWarehouse LocWarehouse { get; set; }
        public virtual RevalProductDJ_CharDesign RevalProductDJ_CharDesign { get; set; }
        public virtual RevalProductDJ_CharProduct RevalProductDJ_CharProduct { get; set; }
        public virtual RevalProductDJ_Costing RevalProductDJ_Costing { get; set; }
        public virtual RevalProductDJ_CostingProduct RevalProductDJ_CostingProduct { get; set; }
        public virtual RevalProductDJ_PricingBiaya RevalProductDJ_PricingBiaya { get; set; }
        public virtual RevalProductDJ_PricingMU RevalProductDJ_PricingMU { get; set; }
        public virtual RevalProductDJ_PricingProduct RevalProductDJ_PricingProduct { get; set; }
        public virtual RevalProductDJ_PricingSegmen RevalProductDJ_PricingSegmen { get; set; }
        public virtual ICollection<RevalProductDJ_Finishing> RevalProductDJ_Finishings { get; set; }
        public virtual ICollection<RevalProductDJ_Stone1A> RevalProductDJ_Stone1As { get; set; }
        public virtual ICollection<RevalProductDJ_Stone1B> RevalProductDJ_Stone1Bs { get; set; }
        public virtual ICollection<RevalProductDJ_Stone2> RevalProductDJ_Stone2s { get; set; }
        public virtual ICollection<RevalProductDJ_Stone3> RevalProductDJ_Stone3s { get; set; }
        public virtual ICollection<RevalProductDJ_Stone4> RevalProductDJ_Stone4s { get; set; }
        public virtual ICollection<RevalProductDJ_Stone5> RevalProductDJ_Stone5s { get; set; }
    }
}
