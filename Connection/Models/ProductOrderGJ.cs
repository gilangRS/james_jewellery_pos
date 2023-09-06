using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class ProductOrderGJ
    {
        public ProductOrderGJ()
        {
            KodeKaretGJ_Details = new HashSet<KodeKaretGJ_Detail>();
            ProductOrderGJ_Finishings = new HashSet<ProductOrderGJ_Finishing>();
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
        public int? StatusBarangId { get; set; }
        public int? KodeKaretRepeat { get; set; }

        public virtual CompanyBrand CompanyBrand { get; set; }
        public virtual DataHuman DataHuman { get; set; }
        public virtual KodeKaretGJ KodeKaretGJ { get; set; }
        public virtual ProductDesignGJ ProductDesignGJ { get; set; }
        public virtual CharProductSegmen CharProductSegmen { get; set; }
        public virtual ProductOrderGJ_CharDesign ProductOrderGJ_CharDesign { get; set; }
        public virtual ProductOrderGJ_CharProduct ProductOrderGJ_CharProduct { get; set; }
        public virtual ICollection<KodeKaretGJ_Detail> KodeKaretGJ_Details { get; set; }
        public virtual ICollection<ProductOrderGJ_Finishing> ProductOrderGJ_Finishings { get; set; }
    }
}
