using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class DataAreaManagerLokasi
    {
        public int Id { get; set; }
        public int Idform { get; set; }
        public int TipeLokasi { get; set; }
        public int Idlokasi { get; set; }

        public virtual DataAreaManager DataAreaManager { get; set; }
    }
}
