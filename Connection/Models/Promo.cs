using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class Promo
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? Draft { get; set; }
        public bool? Disable { get; set; }
        public string Keterangan { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
