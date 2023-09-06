using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class RevalProductGJ
    {
        public RevalProductGJ()
        {
            RevalProductGJ_Finishings = new HashSet<RevalProductGJ_Finishing>();
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

        public virtual RevalItemGJ RevalItemGJ { get; set; }
        public virtual LocWarehouse LocWarehouse { get; set; }
        public virtual RevalProductGJ_CharDesign RevalProductGJ_CharDesign { get; set; }
        public virtual RevalProductGJ_CharProduct RevalProductGJ_CharProduct { get; set; }
        public virtual RevalProductGJ_Costing RevalProductGJ_Costing { get; set; }
        public virtual RevalProductGJ_CostingProduct RevalProductGJ_CostingProduct { get; set; }
        public virtual RevalProductGJ_PricingBiaya RevalProductGJ_PricingBiaya { get; set; }
        public virtual RevalProductGJ_PricingMU RevalProductGJ_PricingMU { get; set; }
        public virtual RevalProductGJ_PricingProduct RevalProductGJ_PricingProduct { get; set; }
        public virtual RevalProductGJ_PricingSegmen RevalProductGJ_PricingSegmen { get; set; }
        public virtual ICollection<RevalProductGJ_Finishing> RevalProductGJ_Finishings { get; set; }
    }
}
