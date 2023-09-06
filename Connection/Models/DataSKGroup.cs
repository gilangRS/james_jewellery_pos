using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DataSKGroup
    {
        public DataSKGroup()
        {
            DataSKs = new HashSet<DataSK>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string NamaKode { get; set; }
        public string Keterangan { get; set; }
        public int Sn { get; set; }
        public bool Disable { get; set; }

        public virtual ICollection<DataSK> DataSKs { get; set; }
    }
}
