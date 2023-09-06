using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockReceiveMounting
    {
        public StockReceiveMounting()
        {
            StockReceiveMounting_Finishings = new HashSet<StockReceiveMounting_Finishing>();
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

        public virtual LocWarehouse LocWarehouse { get; set; }
        public virtual StockReceiveMounting_CharDesign StockReceiveMounting_CharDesign { get; set; }
        public virtual StockReceiveMounting_CharProduct StockReceiveMounting_CharProduct { get; set; }
        public virtual StockReceiveMounting_Costing StockReceiveMounting_Costing { get; set; }
        public virtual StockReceiveMounting_CostingProduct StockReceiveMounting_CostingProduct { get; set; }
        public virtual StockReceiveMounting_PricingBiaya StockReceiveMounting_PricingBiaya { get; set; }
        public virtual StockReceiveMounting_PricingMU StockReceiveMounting_PricingMU { get; set; }
        public virtual StockReceiveMounting_PricingProduct StockReceiveMounting_PricingProduct { get; set; }
        public virtual StockReceiveMounting_PricingSegmen StockReceiveMounting_PricingSegmen { get; set; }
        public virtual ICollection<StockReceiveMounting_Finishing> StockReceiveMounting_Finishings { get; set; }
    }
}
