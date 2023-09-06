using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockReceiveLD
    {
        public StockReceiveLD()
        {
            StockReceiveLdStone1As = new HashSet<StockReceiveLD_Stone1A>();
            StockReceiveLdStone1Bs = new HashSet<StockReceiveLD_Stone1B>();
        }

        public int Id { get; set; }
        public int Idwarehouse { get; set; }
        public string Keterangan { get; set; }
        public DateTime Tgl { get; set; }
        public string Nomor { get; set; }
        public bool Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public int StatusReceive { get; set; }
        public int Supplier { get; set; }
        public string SupplierNama { get; set; }
        public string SupplierNomor { get; set; }
        public int RequestOutlet { get; set; }
        public string RequestOutletNama { get; set; }
        public int RequestCustomer { get; set; }
        public string RequestCustomerNama { get; set; }
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

        public virtual LocWarehouse IdwarehouseNavigation { get; set; }
        public virtual StockReceiveLD_CharDesign StockReceiveLdCharDesign { get; set; }
        public virtual ICollection<StockReceiveLD_Stone1A> StockReceiveLdStone1As { get; set; }
        public virtual ICollection<StockReceiveLD_Stone1B> StockReceiveLdStone1Bs { get; set; }
    }
}
