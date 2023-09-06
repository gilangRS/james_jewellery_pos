using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class RevalLogProductGJ
    {
        public RevalLogProductGJ()
        {
            RevalLogProductGJ_Finishings = new HashSet<RevalLogProductGJ_Finishing>();
        }

        public int Id { get; set; }
        public string Nomor { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }
        public string ImgPicture { get; set; }

        public virtual RevalLogProductGJ_CharProduct RevalLogProductGJ_CharProduct { get; set; }
        public virtual RevalLogProductGJ_Costing RevalLogProductGJ_Costing { get; set; }
        public virtual RevalLogProductGJ_CostingProduct RevalLogProductGJ_CostingProduct { get; set; }
        public virtual RevalLogProductGJ_PricingBiaya RevalLogProductGJ_PricingBiaya { get; set; }
        public virtual RevalLogProductGJ_PricingMU RevalLogProductGJ_PricingMU { get; set; }
        public virtual RevalLogProductGJ_PricingProduct RevalLogProductGJ_PricingProduct { get; set; }
        public virtual RevalLogProductGJ_PricingSegmen RevalLogProductGJ_PricingSegmen { get; set; }
        public virtual ICollection<RevalLogProductGJ_Finishing> RevalLogProductGJ_Finishings { get; set; }
    }
}
