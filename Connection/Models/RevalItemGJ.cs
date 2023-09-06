using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class RevalItemGJ
    {
        public RevalItemGJ()
        {
            RevalProductGjs = new HashSet<RevalProductGJ>();
        }

        public int Id { get; set; }
        public int Idproduct { get; set; }

        public virtual StockProductGJ IdproductNavigation { get; set; }
        public virtual ICollection<RevalProductGJ> RevalProductGjs { get; set; }
    }
}
