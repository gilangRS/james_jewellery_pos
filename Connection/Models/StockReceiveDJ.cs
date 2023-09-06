using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockReceiveDJ
    {
        public StockReceiveDJ()
        {
            StockReceiveDJ_Finishings = new HashSet<StockReceiveDJ_Finishing>();
            StockReceiveDJ_Stone1As = new HashSet<StockReceiveDJ_Stone1A>();
            StockReceiveDJ_Stone1Bs = new HashSet<StockReceiveDJ_Stone1B>();
            StockReceiveDJ_Stone2s = new HashSet<StockReceiveDJ_Stone2>();
            StockReceiveDJ_Stone3s = new HashSet<StockReceiveDJ_Stone3>();
            StockReceiveDJ_Stone4s = new HashSet<StockReceiveDJ_Stone4>();
            StockReceiveDJ_Stone5s = new HashSet<StockReceiveDJ_Stone5>();
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

        public virtual LocWarehouse LocWarehouse { get; set; }
        public virtual StockReceiveDJ_CharDesign StockReceiveDJ_CharDesign { get; set; }
        public virtual StockReceiveDJ_CharProduct StockReceiveDJ_CharProduct { get; set; }
        public virtual StockReceiveDJ_Costing StockReceiveDJ_Costing { get; set; }
        public virtual StockReceiveDJ_CostingProduct StockReceiveDJ_CostingProduct { get; set; }
        public virtual StockReceiveDJ_PricingBiaya StockReceiveDJ_PricingBiaya { get; set; }
        public virtual StockReceiveDJ_PricingMU StockReceiveDJ_PricingMU { get; set; }
        public virtual StockReceiveDJ_PricingProduct StockReceiveDJ_PricingProduct { get; set; }
        public virtual StockReceiveDJ_PricingSegmen StockReceiveDJ_PricingSegmen { get; set; }
        public virtual ICollection<StockReceiveDJ_Finishing> StockReceiveDJ_Finishings { get; set; }
        public virtual ICollection<StockReceiveDJ_Stone1A> StockReceiveDJ_Stone1As { get; set; }
        public virtual ICollection<StockReceiveDJ_Stone1B> StockReceiveDJ_Stone1Bs { get; set; }
        public virtual ICollection<StockReceiveDJ_Stone2> StockReceiveDJ_Stone2s { get; set; }
        public virtual ICollection<StockReceiveDJ_Stone3> StockReceiveDJ_Stone3s { get; set; }
        public virtual ICollection<StockReceiveDJ_Stone4> StockReceiveDJ_Stone4s { get; set; }
        public virtual ICollection<StockReceiveDJ_Stone5> StockReceiveDJ_Stone5s { get; set; }
    }
}
