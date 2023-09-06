using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockReceiveGJ
    {
        public StockReceiveGJ()
        {
            StockReceiveGjFinishings = new HashSet<StockReceiveGJ_Finishing>();
        }

        public int Id { get; set; }
        public int Idwarehouse { get; set; }
        public int Sumber { get; set; }
        public string Keterangan { get; set; }
        public DateTime Tgl { get; set; }
        public string Nomor { get; set; }
        public bool Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public int StatusReceive { get; set; }
        public int Proto { get; set; }
        public string ProtoNomor { get; set; }
        public int? Idmounting { get; set; }
        public int ProductOrder { get; set; }
        public string ProductOrderNomor { get; set; }
        public int Supplier { get; set; }
        public string SupplierNama { get; set; }
        public string SupplierNomor { get; set; }
        public int RequestOutlet { get; set; }
        public string RequestOutletNama { get; set; }
        public int RequestCustomer { get; set; }
        public string RequestCustomerNama { get; set; }
        public int HumanDesigner { get; set; }
        public string HumanDesignerNama { get; set; }
        public int HumanStock { get; set; }
        public string HumanStockNama { get; set; }
        public DateTime? ExpiredProduct { get; set; }
        public DateTime? ExpiredRequest { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }
        public string CatatanManager { get; set; }
        public string ImgPicture { get; set; }
        public string NoValidasi { get; set; }

        public virtual LocWarehouse IdwarehouseNavigation { get; set; }
        public virtual StockReceiveGJ_CharDesign StockReceiveGjCharDesign { get; set; }
        public virtual StockReceiveGJ_CharProduct StockReceiveGjCharProduct { get; set; }
        public virtual StockReceiveGJ_Costing StockReceiveGjCosting { get; set; }
        public virtual StockReceiveGJ_CostingProduct StockReceiveGjCostingProduct { get; set; }
        public virtual StockReceiveGJ_PricingBiaya StockReceiveGjPricingBiaya { get; set; }
        public virtual StockReceiveGJ_PricingMU StockReceiveGjPricingMu { get; set; }
        public virtual StockReceiveGJ_PricingProduct StockReceiveGjPricingProduct { get; set; }
        public virtual StockReceiveGJ_PricingSegmen StockReceiveGjPricingSegman { get; set; }
        public virtual ICollection<StockReceiveGJ_Finishing> StockReceiveGjFinishings { get; set; }
    }
}
