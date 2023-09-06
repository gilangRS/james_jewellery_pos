using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class KodeKaretGJ
    {
        public KodeKaretGJ()
        {
            KodeKaretGJ_Details = new HashSet<KodeKaretGJ_Detail>();
            KodeKaretGJ_Finishings = new HashSet<KodeKaretGJ_Finishing>();
            ProductOrderGJs = new HashSet<ProductOrderGJ>();
        }

        public int Id { get; set; }
        public int? Iddesigner { get; set; }
        public int IdproductOrder { get; set; }
        public int? Idbrand { get; set; }
        public int? Idsegmen { get; set; }
        public string Keterangan { get; set; }
        public DateTime Tgl { get; set; }
        public string Nomor { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }
        public string ImgPicture { get; set; }
        public string KodeKaretLama { get; set; }

        public virtual CompanyBrand CompanyBrand { get; set; }
        public virtual DataHuman DataHuman { get; set; }
        public virtual CharProductSegmen CharProductSegmen { get; set; }
        public virtual KodeKaretGJ_CharDesign KodeKaretGJ_CharDesign { get; set; }
        public virtual KodeKaretGJ_CharProduct KodeKaretGJ_CharProduct { get; set; }
        public virtual ICollection<KodeKaretGJ_Detail> KodeKaretGJ_Details { get; set; }
        public virtual ICollection<KodeKaretGJ_Finishing> KodeKaretGJ_Finishings { get; set; }
        public virtual ICollection<ProductOrderGJ> ProductOrderGJs { get; set; }
    }
}
