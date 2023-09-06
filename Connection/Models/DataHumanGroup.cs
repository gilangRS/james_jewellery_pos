using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DataHumanGroup
    {
        public DataHumanGroup()
        {
            DataHumans = new HashSet<DataHuman>();
        }

        public int Id { get; set; }
        public string Nama { get; set; }
        public string NamaKode { get; set; }
        public string Keterangan { get; set; }
        public int Sn { get; set; }
        public bool Disable { get; set; }

        public virtual ICollection<DataHuman> DataHumans { get; set; }
    }
}
