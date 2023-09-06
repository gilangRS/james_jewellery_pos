using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class ProductStoneRequest
    {
        public ProductStoneRequest()
        {
            ProductStoneRequest_Details = new HashSet<ProductStoneRequest_Detail>();
        }

        public int Id { get; set; }
        public string NomorDokumen { get; set; }
        public DateTime Tgl { get; set; }
        public string Keterangan { get; set; }
        public DateTime TglJatuhTempo { get; set; }
        public int? Idbrand { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }

        public virtual CompanyBrand CompanyBrand { get; set; }
        public virtual ICollection<ProductStoneRequest_Detail> ProductStoneRequest_Details { get; set; }
    }
}
