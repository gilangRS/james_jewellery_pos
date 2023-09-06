using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockActualDJRepair
    {
        public int IdrepairWorkOrder { get; set; }
        public int Status { get; set; }
        public int RepairSpkid { get; set; }
        public string RepairSpknomor { get; set; }
        public string RepairReceiveNomor { get; set; }
        public int? RepairBonId { get; set; }
        public string RepairBonNomor { get; set; }
        public int? RepairBrjid { get; set; }
        public string RepairBrjnomor { get; set; }
        public int? RepairInvoiceId { get; set; }
        public string RepairInvoiceNomor { get; set; }
    }
}
