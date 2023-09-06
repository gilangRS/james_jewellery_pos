using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class KodeKaret_Detail
    {
        public int Id { get; set; }
        public int IdkodeKaret { get; set; }
        public int StatusOrder { get; set; }
        public int Increment { get; set; }
        public string KodeKaretDetail1 { get; set; }
        public string NoSpk { get; set; }
        public int? IdproductOrder { get; set; }

        public virtual KodeKaretDJ KodeKaretDJ { get; set; }
        public virtual ProductOrder ProductOrder { get; set; }
    }
}
