using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockProductDJ
    {
        public StockProductDJ()
        {
            DocQCDJs = new HashSet<DocQCDJ>();
            DocRepairResults = new HashSet<DocRepairResult>();
            DocRepairs = new HashSet<DocRepair>();
            DocTitipan_Products = new HashSet<DocTitipan_Product>();
            PromoDJ_Details = new HashSet<PromoDJ_Detail>();
            ResellDJs = new HashSet<ResellDJ>();
            RevalItemDJs = new HashSet<RevalItemDJ>();
            SaldoStockDJs = new HashSet<SaldoStockDJ>();
            SalesOrderDJs = new HashSet<SalesOrderDJ>();
            SalesOrderRepairs = new HashSet<SalesOrderRepair>();
            StockAuditDJDetails = new HashSet<StockAuditDJDetail>();
            StockAuditItemDJs = new HashSet<StockAuditItemDJ>();
            StockIncomingDJ_Products = new HashSet<StockIncomingDJ_Product>();
            StockOutgoingDJ_Products = new HashSet<StockOutgoingDJ_Product>();
            StockProductDJ_Finishings = new HashSet<StockProductDJ_Finishing>();
            StockProductDJ_Stone1As = new HashSet<StockProductDJ_Stone1A>();
            StockProductDJ_Stone1Bs = new HashSet<StockProductDJ_Stone1B>();
            StockProductDJ_Stone2s = new HashSet<StockProductDJ_Stone2>();
            StockProductDJ_Stone3s = new HashSet<StockProductDJ_Stone3>();
            StockProductDJ_Stone4s = new HashSet<StockProductDJ_Stone4>();
            StockProductDJ_Stone5s = new HashSet<StockProductDJ_Stone5>();
            StockProductDJLDs = new HashSet<StockProductDJLD>();
            StockRetireDJs = new HashSet<StockRetireDJ>();
            CrossBrand_StockIncomingDJ_Products = new HashSet<CrossBrand_StockIncomingDJ_Product>();
            CrossBrand_StockOutgoingDJ_Products = new HashSet<CrossBrand_StockOutgoingDJ_Product>();
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
        public int? Legacy { get; set; }

        public virtual LocWarehouse LocWarehouse { get; set; }
        public virtual StockActualDJ StockActualDj { get; set; }
        public virtual StockProductDJ_CharDesign StockProductDJ_CharDesign { get; set; }
        public virtual StockProductDJ_CharProduct StockProductDJ_CharProduct { get; set; }
        public virtual StockProductDJ_Costing StockProductDJ_Costing { get; set; }
        public virtual StockProductDJ_CostingProduct StockProductDJ_CostingProduct { get; set; }
        public virtual StockProductDJ_PricingBiaya StockProductDJ_PricingBiaya { get; set; }
        public virtual StockProductDJ_PricingMU StockProductDJ_PricingMU { get; set; }
        public virtual StockProductDJ_PricingProduct StockProductDJ_PricingProduct { get; set; }
        public virtual StockProductDJ_PricingSegmen StockProductDJ_PricingSegmen { get; set; }
        public virtual StockReceiveDJLegacy StockReceiveDJLegacy { get; set; }
        public virtual ICollection<DocQCDJ> DocQCDJs { get; set; }
        public virtual ICollection<DocRepairResult> DocRepairResults { get; set; }
        public virtual ICollection<DocRepair> DocRepairs { get; set; }
        public virtual ICollection<DocTitipan_Product> DocTitipan_Products { get; set; }
        public virtual ICollection<PromoDJ_Detail> PromoDJ_Details { get; set; }
        public virtual ICollection<ResellDJ> ResellDJs { get; set; }
        public virtual ICollection<RevalItemDJ> RevalItemDJs { get; set; }
        public virtual ICollection<SaldoStockDJ> SaldoStockDJs { get; set; }
        public virtual ICollection<SalesOrderDJ> SalesOrderDJs { get; set; }
        public virtual ICollection<SalesOrderRepair> SalesOrderRepairs { get; set; }
        public virtual ICollection<StockAuditDJDetail> StockAuditDJDetails { get; set; }
        public virtual ICollection<StockAuditItemDJ> StockAuditItemDJs { get; set; }
        public virtual ICollection<StockIncomingDJ_Product> StockIncomingDJ_Products { get; set; }
        public virtual ICollection<StockOutgoingDJ_Product> StockOutgoingDJ_Products { get; set; }
        public virtual ICollection<StockProductDJ_Finishing> StockProductDJ_Finishings { get; set; }
        public virtual ICollection<StockProductDJ_Stone1A> StockProductDJ_Stone1As { get; set; }
        public virtual ICollection<StockProductDJ_Stone1B> StockProductDJ_Stone1Bs { get; set; }
        public virtual ICollection<StockProductDJ_Stone2> StockProductDJ_Stone2s { get; set; }
        public virtual ICollection<StockProductDJ_Stone3> StockProductDJ_Stone3s { get; set; }
        public virtual ICollection<StockProductDJ_Stone4> StockProductDJ_Stone4s { get; set; }
        public virtual ICollection<StockProductDJ_Stone5> StockProductDJ_Stone5s { get; set; }
        public virtual ICollection<StockProductDJLD> StockProductDJLDs { get; set; }
        public virtual ICollection<StockRetireDJ> StockRetireDJs { get; set; }
        public virtual ICollection<CrossBrand_StockIncomingDJ_Product> CrossBrand_StockIncomingDJ_Products { get; set; }
        public virtual ICollection<CrossBrand_StockOutgoingDJ_Product> CrossBrand_StockOutgoingDJ_Products { get; set; }
    }
}
