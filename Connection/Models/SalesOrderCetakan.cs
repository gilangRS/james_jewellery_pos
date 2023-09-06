using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class SalesOrderCetakan
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int Idproduct { get; set; }
        public string Invoice { get; set; }
        public decimal? ModalRupiah { get; set; }
        public decimal? TotalRupiah { get; set; }
        public decimal? Qty { get; set; }
        public decimal? TotalModalRupiah { get; set; }

        public virtual SalesOrder SalesOrder { get; set; }
        public virtual Cetakan Cetakan { get; set; }
    }
}
