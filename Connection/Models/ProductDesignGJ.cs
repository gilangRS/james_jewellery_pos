using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class ProductDesignGJ
    {
        public ProductDesignGJ()
        {
            ProductDesignGJ_Finishings = new HashSet<ProductDesignGJ_Finishing>();
            ProductOrderGJs = new HashSet<ProductOrderGJ>();
        }

        public int Id { get; set; }
        public int Iddesigner { get; set; }
        public string Keterangan { get; set; }
        public DateTime Tgl { get; set; }
        public string Nomor { get; set; }
        public bool Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public int StatusReceive { get; set; }
        public string DesignKode { get; set; }
        public int? RequestOutlet { get; set; }
        public string RequestOutletNama { get; set; }
        public int RequestCustomer { get; set; }
        public string RequestCustomerNama { get; set; }
        public int HumanDesigner { get; set; }
        public string HumanDesignerNama { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }
        public string CatatanManager { get; set; }
        public string ImgPicture { get; set; }
        public bool? StatusSpk { get; set; }

        public virtual DataHuman DataHuman { get; set; }
        public virtual ProductDesignGJ_CharDesign ProductDesignGJ_CharDesign { get; set; }
        public virtual ProductDesignGJ_CharProduct ProductDesignGJ_CharProduct { get; set; }
        public virtual ProductDesignGJ_PricingBiaya ProductDesignGJ_PricingBiaya { get; set; }
        public virtual ProductDesignGJ_PricingMU ProductDesignGJ_PricingMU { get; set; }
        public virtual ProductDesignGJ_PricingProduct ProductDesignGJ_PricingProduct { get; set; }
        public virtual ProductDesignGJ_PricingSegmen ProductDesignGJ_PricingSegmen { get; set; }
        public virtual ICollection<ProductDesignGJ_Finishing> ProductDesignGJ_Finishings { get; set; }
        public virtual ICollection<ProductOrderGJ> ProductOrderGJs { get; set; }
    }
}
