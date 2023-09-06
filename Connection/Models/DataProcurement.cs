using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DataProcurement
    {
        public int Id { get; set; }
        public string Nik { get; set; }
        public string Nama { get; set; }
        public bool? Draft { get; set; }
        public bool? Disable { get; set; }
        public string AddrEmail { get; set; }
    }
}
