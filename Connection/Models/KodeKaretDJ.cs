using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class KodeKaretDJ
    {
        public KodeKaretDJ()
        {
            KodeKaret_Details = new HashSet<KodeKaret_Detail>();
            KodeKaretDJ_Finishings = new HashSet<KodeKaretDJ_Finishing>();
            KodeKaretDJ_Stone1As = new HashSet<KodeKaretDJ_Stone1A>();
            KodeKaretDJ_Stone1Bs = new HashSet<KodeKaretDJ_Stone1B>();
            KodeKaretDJ_Stone2s = new HashSet<KodeKaretDJ_Stone2>();
            KodeKaretDJ_Stone3s = new HashSet<KodeKaretDJ_Stone3>();
            KodeKaretDJ_Stone4s = new HashSet<KodeKaretDJ_Stone4>();
            KodeKaretDJ_Stone5s = new HashSet<KodeKaretDJ_Stone5>();
            ProductOrders = new HashSet<ProductOrder>();
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
        public virtual KodeKaretDJ_CharDesign KodeKaretDJ_CharDesign { get; set; }
        public virtual KodeKaretDJ_CharProduct KodeKaretDJ_CharProduct { get; set; }
        public virtual ICollection<KodeKaret_Detail> KodeKaret_Details { get; set; }
        public virtual ICollection<KodeKaretDJ_Finishing> KodeKaretDJ_Finishings { get; set; }
        public virtual ICollection<KodeKaretDJ_Stone1A> KodeKaretDJ_Stone1As { get; set; }
        public virtual ICollection<KodeKaretDJ_Stone1B> KodeKaretDJ_Stone1Bs { get; set; }
        public virtual ICollection<KodeKaretDJ_Stone2> KodeKaretDJ_Stone2s { get; set; }
        public virtual ICollection<KodeKaretDJ_Stone3> KodeKaretDJ_Stone3s { get; set; }
        public virtual ICollection<KodeKaretDJ_Stone4> KodeKaretDJ_Stone4s { get; set; }
        public virtual ICollection<KodeKaretDJ_Stone5> KodeKaretDJ_Stone5s { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
