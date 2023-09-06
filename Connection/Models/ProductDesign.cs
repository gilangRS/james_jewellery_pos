using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class ProductDesign
    {
        public ProductDesign()
        {
            ProductDesign_Finishings = new HashSet<ProductDesign_Finishing>();
            ProductDesign_Stone1As = new HashSet<ProductDesign_Stone1A>();
            ProductDesign_Stone1Bs = new HashSet<ProductDesign_Stone1B>();
            ProductDesign_Stone2s = new HashSet<ProductDesign_Stone2>();
            ProductDesign_Stone3s = new HashSet<ProductDesign_Stone3>();
            ProductDesign_Stone4s = new HashSet<ProductDesign_Stone4>();
            ProductDesign_Stone5s = new HashSet<ProductDesign_Stone5>();
            ProductOrders = new HashSet<ProductOrder>();
        }

        public int Id { get; set; }
        public int Iddesigner { get; set; }
        public string Keterangan { get; set; }
        public DateTime Tgl { get; set; }
        public string Nomor { get; set; }
        public bool Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public int StatusReceive { get; set; }
        public string DesignKode { get; set; }
        public int? RequestOutlet { get; set; }
        public string RequestOutletNama { get; set; }
        public int RequestCustomer { get; set; }
        public string RequestCustomerNama { get; set; }
        public int HumanDesigner { get; set; }
        public string HumanDesignerNama { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }
        public string CatatanManager { get; set; }
        public string ImgPicture { get; set; }
        public bool? StatusSpk { get; set; }

        public virtual DataHuman DataHuman { get; set; }
        public virtual ProductDesign_CharDesign ProductDesign_CharDesign { get; set; }
        public virtual ProductDesign_CharProduct ProductDesign_CharProduct { get; set; }
        public virtual ProductDesign_PricingBiaya ProductDesign_PricingBiaya { get; set; }
        public virtual ProductDesign_PricingMU ProductDesign_PricingMU { get; set; }
        public virtual ProductDesign_PricingProduct ProductDesign_PricingProduct { get; set; }
        public virtual ProductDesign_PricingSegmen ProductDesign_PricingSegmen { get; set; }
        public virtual ICollection<ProductDesign_Finishing> ProductDesign_Finishings { get; set; }
        public virtual ICollection<ProductDesign_Stone1A> ProductDesign_Stone1As { get; set; }
        public virtual ICollection<ProductDesign_Stone1B> ProductDesign_Stone1Bs { get; set; }
        public virtual ICollection<ProductDesign_Stone2> ProductDesign_Stone2s { get; set; }
        public virtual ICollection<ProductDesign_Stone3> ProductDesign_Stone3s { get; set; }
        public virtual ICollection<ProductDesign_Stone4> ProductDesign_Stone4s { get; set; }
        public virtual ICollection<ProductDesign_Stone5> ProductDesign_Stone5s { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
