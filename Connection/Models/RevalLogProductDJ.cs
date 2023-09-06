using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class RevalLogProductDJ
    {
        public RevalLogProductDJ()
        {
            RevalLogProductDJ_Finishings = new HashSet<RevalLogProductDJ_Finishing>();
            RevalLogProductDJ_Stone1As = new HashSet<RevalLogProductDJ_Stone1A>();
            RevalLogProductDJ_Stone1Bs = new HashSet<RevalLogProductDJ_Stone1B>();
            RevalLogProductDJ_Stone2s = new HashSet<RevalLogProductDJ_Stone2>();
            RevalLogProductDJ_Stone3s = new HashSet<RevalLogProductDJ_Stone3>();
            RevalLogProductDJ_Stone4s = new HashSet<RevalLogProductDJ_Stone4>();
            RevalLogProductDJ_Stone5s = new HashSet<RevalLogProductDJ_Stone5>();
        }

        public int Id { get; set; }
        public string Nomor { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }
        public string ImgPicture { get; set; }

        public virtual RevalLogProductDJ_CharProduct RevalLogProductDJ_CharProduct { get; set; }
        public virtual RevalLogProductDJ_Costing RevalLogProductDJ_Costing { get; set; }
        public virtual RevalLogProductDJ_CostingProduct RevalLogProductDJ_CostingProduct { get; set; }
        public virtual RevalLogProductDJ_PricingBiaya RevalLogProductDJ_PricingBiaya { get; set; }
        public virtual RevalLogProductDJ_PricingMU RevalLogProductDJ_PricingMU { get; set; }
        public virtual RevalLogProductDJ_PricingProduct RevalLogProductDJ_PricingProduct { get; set; }
        public virtual RevalLogProductDJ_PricingSegmen RevalLogProductDJ_PricingSegmen { get; set; }
        public virtual ICollection<RevalLogProductDJ_Finishing> RevalLogProductDJ_Finishings { get; set; }
        public virtual ICollection<RevalLogProductDJ_Stone1A> RevalLogProductDJ_Stone1As { get; set; }
        public virtual ICollection<RevalLogProductDJ_Stone1B> RevalLogProductDJ_Stone1Bs { get; set; }
        public virtual ICollection<RevalLogProductDJ_Stone2> RevalLogProductDJ_Stone2s { get; set; }
        public virtual ICollection<RevalLogProductDJ_Stone3> RevalLogProductDJ_Stone3s { get; set; }
        public virtual ICollection<RevalLogProductDJ_Stone4> RevalLogProductDJ_Stone4s { get; set; }
        public virtual ICollection<RevalLogProductDJ_Stone5> RevalLogProductDJ_Stone5s { get; set; }
    }
}
