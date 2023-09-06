using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class RevalItemDJ
    {
        public RevalItemDJ()
        {
            RevalProductDjs = new HashSet<RevalProductDJ>();
        }

        public int Id { get; set; }
        public int Idproduct { get; set; }

        public virtual StockProductDJ IdproductNavigation { get; set; }
        public virtual ICollection<RevalProductDJ> RevalProductDjs { get; set; }
    }
}
