using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockProductMounting
    {
        public StockProductMounting()
        {
            StockProductMounting_Finishings = new HashSet<StockProductMounting_Finishing>();
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
        public bool? StatusReceive { get; set; }
        public string ImgPicture { get; set; }

        public virtual LocWarehouse LocWarehouse { get; set; }
        public virtual StockActualMounting StockActualMounting { get; set; }
        public virtual StockProductMounting_CharDesign StockProductMounting_CharDesign { get; set; }
        public virtual StockProductMounting_CharProduct StockProductMounting_CharProduct { get; set; }
        public virtual StockProductMounting_Costing StockProductMounting_Costing { get; set; }
        public virtual StockProductMounting_CostingProduct StockProductMounting_CostingProduct { get; set; }
        public virtual StockProductMounting_PricingBiaya StockProductMounting_PricingBiaya { get; set; }
        public virtual StockProductMounting_PricingMU StockProductMounting_PricingMU { get; set; }
        public virtual StockProductMounting_PricingProduct StockProductMounting_PricingProduct { get; set; }
        public virtual StockProductMounting_PricingSegmen StockProductMounting_PricingSegmen { get; set; }
        public virtual ICollection<StockProductMounting_Finishing> StockProductMounting_Finishings { get; set; }
    }
}
