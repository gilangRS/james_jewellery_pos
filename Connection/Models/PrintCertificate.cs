using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PrintCertificate
    {
        public PrintCertificate()
        {
            PrintCertificate_Details = new HashSet<PrintCertificate_Detail>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string Nomor { get; set; }
        public string Keterangan { get; set; }
        public DateTime Tgl { get; set; }
        public DateTime TglExpire { get; set; }
        public string Operator { get; set; }
        public DateTime OperatorTgl { get; set; }
        public int StatusFinish { get; set; }

        public virtual ICollection<PrintCertificate_Detail> PrintCertificate_Details { get; set; }
    }
}
