using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class ListUploadEDC
    {
        public int Id { get; set; }
        public string NomorEdc { get; set; }
        public decimal? Nominal { get; set; }
        public int? Idbank { get; set; }
        public DateTime? TanggalUpload { get; set; }
        public string Operator { get; set; }
        public DateTime? TanggalUpdate { get; set; }
        public string UpdateBy { get; set; }
        public string Keterangan { get; set; }
        public bool? Status { get; set; }
        public bool? StatusPostGl { get; set; }
        public string NomorSo { get; set; }
        public int? Idform { get; set; }
        public int? TipeForm { get; set; }
        public DateTime? TanggalCair { get; set; }
        public int? Mid { get; set; }
    }
}
