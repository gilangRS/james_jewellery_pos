using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DataHuman
    {
        public DataHuman()
        {
            KodeKaretDJs = new HashSet<KodeKaretDJ>();
            KodeKaretGJs = new HashSet<KodeKaretGJ>();
            ProductDesignGJs = new HashSet<ProductDesignGJ>();
            ProductDesigns = new HashSet<ProductDesign>();
            ProductOrderGJs = new HashSet<ProductOrderGJ>();
            ProductOrders = new HashSet<ProductOrder>();
        }

        public int Id { get; set; }
        public int Idgroup { get; set; }
        public int Idbrand { get; set; }
        public string Nama { get; set; }
        public string NoNpwp { get; set; }
        public string Keterangan { get; set; }
        public DateTime Tgl { get; set; }
        public bool Draft { get; set; }
        public DateTime? DraftDate { get; set; }
        public bool Disable { get; set; }
        public string AddrAlamat { get; set; }
        public string AddrNoTelp { get; set; }
        public string AddrNoFax { get; set; }
        public string AddrEmail { get; set; }
        public string ImgPicture { get; set; }
        public int? Iduser { get; set; }
        public decimal? Point { get; set; }
        public string Nik { get; set; }

        public virtual CompanyBrand CompanyBrand { get; set; }
        public virtual DataHumanGroup DataHumanGroup { get; set; }
        public virtual ICollection<KodeKaretDJ> KodeKaretDJs { get; set; }
        public virtual ICollection<KodeKaretGJ> KodeKaretGJs { get; set; }
        public virtual ICollection<ProductDesignGJ> ProductDesignGJs { get; set; }
        public virtual ICollection<ProductDesign> ProductDesigns { get; set; }
        public virtual ICollection<ProductOrderGJ> ProductOrderGJs { get; set; }
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
