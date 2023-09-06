using System;
using System.Collections.Generic;

#nullable disable

namespace Connection.Models
{
    public partial class StockProductLD_CharDesign
    {
        public int Id { get; set; }
        public int DesignCategory { get; set; }
        public int DesignConcept { get; set; }
        public int DesignProcess { get; set; }
        public int TargetAge { get; set; }
        public int TargetGender { get; set; }
        public bool SetItem { get; set; }
        public bool Special { get; set; }

        public virtual CharDesignCategory CharDesignCategory { get; set; }
        public virtual CharDesignConcept CharDesignConcept { get; set; }
        public virtual CharDesignProcess CharDesignProcess { get; set; }
        public virtual StockProductLD StockProductLD { get; set; }
        public virtual CharTargetAge CharTargetAge { get; set; }
        public virtual CharTargetGender CharTargetGender { get; set; }
    }
}
