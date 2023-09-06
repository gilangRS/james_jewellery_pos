using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class PrintCertificate_Detail
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int TypeProduct { get; set; }
        public int Idproduct { get; set; }
        public string Url { get; set; }
        public string Plu { get; set; }
        public string Item { get; set; }

        public virtual PrintCertificate PrintCertificate { get; set; }
    }
}
