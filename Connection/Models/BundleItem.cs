using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class BundleItem
    {
        public BundleItem()
        {
            BundleItemMasters = new HashSet<BundleItemMaster>();
            BundleItemPasangans = new HashSet<BundleItemPasangan>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string Keterangan { get; set; }
        public bool? Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string ApprovalNama { get; set; }
        public DateTime? ApprovalTgl { get; set; }
        public DateTime? TglStart { get; set; }
        public DateTime? TglExpire { get; set; }
        public int? StatusActive { get; set; }

        public virtual ICollection<BundleItemMaster> BundleItemMasters { get; set; }
        public virtual ICollection<BundleItemPasangan> BundleItemPasangans { get; set; }
    }
}
