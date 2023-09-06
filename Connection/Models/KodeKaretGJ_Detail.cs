using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class KodeKaretGJ_Detail
    {
        public int Id { get; set; }
        public int IdkodeKaret { get; set; }
        public int StatusOrder { get; set; }
        public int Increment { get; set; }
        public string KodeKaretDetail { get; set; }
        public string NoSpk { get; set; }
        public int? IdproductOrder { get; set; }

        public virtual KodeKaretGJ KodeKaretGJ { get; set; }
        public virtual ProductOrderGJ ProductOrderGJ { get; set; }
    }
}
