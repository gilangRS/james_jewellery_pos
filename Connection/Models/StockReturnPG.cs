using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockReturnPG
    {
        public StockReturnPG()
        {
            StockReturnPG_Products = new HashSet<StockReturnPG_Product>();
        }

        public int Id { get; set; }
        public string NoDokumen { get; set; }
        public DateTime Tgl { get; set; }
        public int Idwarehouse { get; set; }
        public int? Idbrand { get; set; }
        public int? Supplier { get; set; }
        public string SupplierNama { get; set; }
        public string SupplierNomor { get; set; }
        public string NamaKurir { get; set; }
        public string Keterangan { get; set; }
        public bool? Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }

        public virtual CompanyBrand CompanyBrand { get; set; }
        public virtual LocWarehouse LocWarehouse { get; set; }
        public virtual ICollection<StockReturnPG_Product> StockReturnPG_Products { get; set; }
    }
}
