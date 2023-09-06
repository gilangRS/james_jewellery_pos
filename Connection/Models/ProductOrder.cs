using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class ProductOrder
    {
        public ProductOrder()
        {
            KodeKaret_Details = new HashSet<KodeKaret_Detail>();
            ProductOrder_Finishings = new HashSet<ProductOrder_Finishing>();
            ProductOrder_Stone1As = new HashSet<ProductOrder_Stone1A>();
            ProductOrder_Stone1Bs = new HashSet<ProductOrder_Stone1B>();
            ProductOrder_Stone2s = new HashSet<ProductOrder_Stone2>();
            ProductOrder_Stone3s = new HashSet<ProductOrder_Stone3>();
            ProductOrder_Stone4s = new HashSet<ProductOrder_Stone4>();
            ProductOrder_Stone5s = new HashSet<ProductOrder_Stone5>();
            ProductStoneRequest_Details = new HashSet<ProductStoneRequest_Detail>();
        }

        public int Id { get; set; }
        public int? Iddesigner { get; set; }
        public int? Idbrand { get; set; }
        public int? IdproductDesign { get; set; }
        public int? Idsegmen { get; set; }
        public string KodeKaret { get; set; }
        public int? IdkodeKaret { get; set; }
        public string NoSpk { get; set; }
        public string Keterangan { get; set; }
        public DateTime Tgl { get; set; }
        public string Nomor { get; set; }
        public bool Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public int StatusPenerimaan { get; set; }
        public int? StatusFps { get; set; }
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
        public DateTime? TanggalJatuhTempoRangka { get; set; }
        public DateTime? TanggalJatuhTempoSetting { get; set; }
        public DateTime? TanggalJatuhTempoDj { get; set; }
        public DateTime? TanggalJatuhTempoKonsumen { get; set; }
        public string NoLdkp { get; set; }
        public int? JlhCopy { get; set; }
        public int? StatusOrder { get; set; }
        public string KodeKaretLama { get; set; }
        public string NoTitipan { get; set; }
        public string NoPo { get; set; }
        public string NoInvoice { get; set; }
        public int? Idfps { get; set; }
        public DateTime? TglLdkp { get; set; }
        public string ApprovalGm { get; set; }
        public DateTime? ApprovalGmtanggal { get; set; }
        public int? JenisSpk { get; set; }
        public bool StatusPesanan { get; set; }
        public string StatusBarang { get; set; }
        public string StatusBarangKeterangan { get; set; }
        public int? StatusBarangId { get; set; }
        public int? KodeKaretRepeat { get; set; }
        public int? RequestExhibition { get; set; }
        public string RequestExhibitionNama { get; set; }

        public virtual CompanyBrand CompanyBrand { get; set; }
        public virtual DataHuman DataHuman { get; set; }
        public virtual KodeKaretDJ KodeKaretDJ { get; set; }
        public virtual ProductDesign ProductDesign { get; set; }
        public virtual CharProductSegmen CharProductSegmen { get; set; }
        public virtual ProductOrder_CharDesign ProductOrder_CharDesign { get; set; }
        public virtual ProductOrder_CharProduct ProductOrder_CharProduct { get; set; }
        public virtual ProductOrder_Costing ProductOrder_Costing { get; set; }
        public virtual ProductOrder_CostingProduct ProductOrder_CostingProduct { get; set; }
        public virtual ProductOrder_PricingBiaya ProductOrder_PricingBiaya { get; set; }
        public virtual ProductOrder_PricingMU ProductOrder_PricingMU { get; set; }
        public virtual ProductOrder_PricingProduct ProductOrder_PricingProduct { get; set; }
        public virtual ProductOrder_PricingSegmen ProductOrder_PricingSegmen { get; set; }
        public virtual ICollection<KodeKaret_Detail> KodeKaret_Details { get; set; }
        public virtual ICollection<ProductOrder_Finishing> ProductOrder_Finishings { get; set; }
        public virtual ICollection<ProductOrder_Stone1A> ProductOrder_Stone1As { get; set; }
        public virtual ICollection<ProductOrder_Stone1B> ProductOrder_Stone1Bs { get; set; }
        public virtual ICollection<ProductOrder_Stone2> ProductOrder_Stone2s { get; set; }
        public virtual ICollection<ProductOrder_Stone3> ProductOrder_Stone3s { get; set; }
        public virtual ICollection<ProductOrder_Stone4> ProductOrder_Stone4s { get; set; }
        public virtual ICollection<ProductOrder_Stone5> ProductOrder_Stone5s { get; set; }
        public virtual ICollection<ProductStoneRequest_Detail> ProductStoneRequest_Details { get; set; }
    }
}
