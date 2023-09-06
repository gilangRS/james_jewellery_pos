using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class BundleItemMaster
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int? TipeProduct { get; set; }
        public int? Idproduct { get; set; }

        public virtual BundleItem BundleItem { get; set; }
    }
}
