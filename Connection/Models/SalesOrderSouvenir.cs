using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class SalesOrderSouvenir
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int? Idproduct { get; set; }
        public string Invoice { get; set; }
        public decimal? ModalRupiah { get; set; }
        public decimal? TotalRupiah { get; set; }
        public decimal? Qty { get; set; }
        public decimal? TotalModalRupiah { get; set; }
        public int? IdproductDj { get; set; }
        public int? IdproductPg { get; set; }
        public int? IdproductGj { get; set; }
        public int? IdproductLd { get; set; }
        public int? TipeProduct { get; set; }
        public int? IdproductSouvenir { get; set; }

        public virtual SalesOrder SalesOrder { get; set; }
        public virtual Souvenir Souvenir { get; set; }
    }
}
