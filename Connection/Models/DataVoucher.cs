using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DataVoucher
    {
        public int Id { get; set; }
        public int Idbrand { get; set; }
        public DateTime Tgl { get; set; }
        public string Nomor { get; set; }
        public DateTime TglExpired { get; set; }
        public decimal Nominal { get; set; }
        public string CustomerNama { get; set; }
        public string Keterangan { get; set; }
        public int JenisVoucher { get; set; }
        public int CustomerTipe { get; set; }
        public int Status { get; set; }
        public int Idcustomer { get; set; }
        public string Operator { get; set; }
        public DateTime? OperatorTgl { get; set; }
        public string Approval { get; set; }
        public DateTime? ApprovalTgl { get; set; }

        public virtual CompanyBrand CompanyBrand { get; set; }
    }
}
