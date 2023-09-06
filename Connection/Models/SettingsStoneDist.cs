using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class SettingsStoneDist
    {
        public int Idcategory { get; set; }
        public int Idlevel { get; set; }
        public int Iddist { get; set; }

        public virtual CharProductCategory CharProductCategory { get; set; }
        public virtual CharStoneDist CharStoneDist { get; set; }
        public virtual CharProductLevel CharProductLevel { get; set; }
    }
}
