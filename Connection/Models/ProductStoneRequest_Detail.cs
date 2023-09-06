using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class ProductStoneRequest_Detail
    {
        public int Id { get; set; }
        public int IdproductStoneRequest { get; set; }
        public string Nomor { get; set; }
        public int IdproductOrder { get; set; }

        public virtual ProductOrder ProductOrder { get; set; }
        public virtual ProductStoneRequest ProductStoneRequest { get; set; }
    }
}
