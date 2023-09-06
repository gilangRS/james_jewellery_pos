using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class SettingsSegmen
    {
        public int Idcategory { get; set; }
        public int Idlevel { get; set; }
        public int Sistem { get; set; }

        public virtual CharProductCategory CharProductCategory { get; set; }
        public virtual CharProductLevel CharProductLevel { get; set; }
    }
}
