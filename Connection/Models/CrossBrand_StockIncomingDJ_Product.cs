using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class CrossBrand_StockIncomingDJ_Product
    {
        public int Idform { get; set; }
        public int Idproduct { get; set; }
        public string Nomor { get; set; }
        public int SubStorageTo { get; set; }
        public int? SubStorageResult { get; set; }
        public int Status { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }

        public virtual CrossBrand_StockIncomingDJ CrossBrand_StockIncomingDJ { get; set; }
        public virtual StockActualDJ StockActualDJ { get; set; }
        public virtual StockProductDJ StockProductDJ { get; set; }
    }
}
