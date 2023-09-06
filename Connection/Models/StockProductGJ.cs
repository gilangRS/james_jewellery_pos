using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockProductGJ
    {
        public StockProductGJ()
        {
            DocQCGJs = new HashSet<DocQCGJ>();
            PromoGJ_Details = new HashSet<PromoGJ_Detail>();
            ResellGJs = new HashSet<ResellGJ>();
            RevalItemGJs = new HashSet<RevalItemGJ>();
            SaldoStockGJs = new HashSet<SaldoStockGJ>();
            SalesOrderGJs = new HashSet<SalesOrderGJ>();
            StockAuditGJDetails = new HashSet<StockAuditGJDetail>();
            StockAuditItemGJs = new HashSet<StockAuditItemGJ>();
            StockIncomingGJ_Products = new HashSet<StockIncomingGJ_Product>();
            StockOutgoingGJ_Products = new HashSet<StockOutgoingGJ_Product>();
            StockProductGJ_Finishings = new HashSet<StockProductGJ_Finishing>();
            StockRetireGJs = new HashSet<StockRetireGJ>();
            StockReturnGJ_Products = new HashSet<StockReturnGJ_Product>();
        }

        public int Id { get; set; }
        public int? Idwarehouse { get; set; }
        public int? Sumber { get; set; }
        public string Keterangan { get; set; }
        public DateTime? Tgl { get; set; }
        public string Nomor { get; set; }
        public bool? Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public int? Proto { get; set; }
        public string ProtoNomor { get; set; }
        public int? ProductOrder { get; set; }
        public string ProductOrderNomor { get; set; }
        public int? Supplier { get; set; }
        public string SupplierNama { get; set; }
        public string SupplierNomor { get; set; }
        public int? RequestOutlet { get; set; }
        public string RequestOutletNama { get; set; }
        public int? RequestCustomer { get; set; }
        public string RequestCustomerNama { get; set; }
        public int? HumanDesigner { get; set; }
        public string HumanDesginerNama { get; set; }
        public int? HumanStock { get; set; }
        public string HumanStockNama { get; set; }
        public DateTime? ExpiredProduct { get; set; }
        public DateTime? ExpiredRequest { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }
        public string CatatanManager { get; set; }
        public string ImgPicture { get; set; }
        public bool? ReturnProduct { get; set; }
        public int? StatusPenjualan { get; set; }
        public bool? StatusLebur { get; set; }

        public virtual LocWarehouse LocWarehouse { get; set; }
        public virtual StockActualGJ StockActualGJ { get; set; }
        public virtual StockProductGJ_CharDesign StockProductGJ_CharDesign { get; set; }
        public virtual StockProductGJ_CharProduct StockProductGJ_CharProduct { get; set; }
        public virtual StockProductGJ_Costing StockProductGJ_Costing { get; set; }
        public virtual StockProductGJ_CostingProduct StockProductGJ_CostingProduct { get; set; }
        public virtual StockProductGJ_PricingBiaya StockProductGJ_PricingBiaya { get; set; }
        public virtual StockProductGJ_PricingMu StockProductGJ_PricingMu { get; set; }
        public virtual StockProductGJ_PricingProduct StockProductGJ_PricingProduct { get; set; }
        public virtual StockProductGJ_PricingSegmen StockProductGJ_PricingSegmen { get; set; }
        public virtual StockReceiveGJLegacy StockReceiveGJLegacy { get; set; }
        public virtual ICollection<DocQCGJ> DocQCGJs { get; set; }
        public virtual ICollection<PromoGJ_Detail> PromoGJ_Details { get; set; }
        public virtual ICollection<ResellGJ> ResellGJs { get; set; }
        public virtual ICollection<RevalItemGJ> RevalItemGJs { get; set; }
        public virtual ICollection<SaldoStockGJ> SaldoStockGJs { get; set; }
        public virtual ICollection<SalesOrderGJ> SalesOrderGJs { get; set; }
        public virtual ICollection<StockAuditGJDetail> StockAuditGJDetails { get; set; }
        public virtual ICollection<StockAuditItemGJ> StockAuditItemGJs { get; set; }
        public virtual ICollection<StockIncomingGJ_Product> StockIncomingGJ_Products { get; set; }
        public virtual ICollection<StockOutgoingGJ_Product> StockOutgoingGJ_Products { get; set; }
        public virtual ICollection<StockProductGJ_Finishing> StockProductGJ_Finishings { get; set; }
        public virtual ICollection<StockRetireGJ> StockRetireGJs { get; set; }
        public virtual ICollection<StockReturnGJ_Product> StockReturnGJ_Products { get; set; }
    }
}
